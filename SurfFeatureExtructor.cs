//----------------------------------------------------------------------------
//  Copyright (C) 2004-2013 by EMGU. All rights reserved.       
//----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Features2D;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV.GPU;
using PassFace;

namespace SURFFeatureExample
{
   public static class SurfRecognizer
   {
      public static void FindMatch(Image<Gray, Byte> modelImage, Image<Gray, byte> observedImage, out long matchTime, out VectorOfKeyPoint modelKeyPoints, out VectorOfKeyPoint observedKeyPoints, out Matrix<int> indices, out Matrix<byte> mask, out HomographyMatrix homography)
      {
         int k = 2;
         double uniquenessThreshold = 5;
         SURFDetector surfCPU = new SURFDetector(500, false);
         Stopwatch watch;
         homography = null;
         bool mozan = false;
         if (mozan == true)
         {
            GpuSURFDetector surfGPU = new GpuSURFDetector(surfCPU.SURFParams, 0.01f);
            using (GpuImage<Gray, Byte> gpuModelImage = new GpuImage<Gray, byte>(modelImage))
            //extract features from the object image
            using (GpuMat<float> gpuModelKeyPoints = surfGPU.DetectKeyPointsRaw(gpuModelImage, null))
            using (GpuMat<float> gpuModelDescriptors = surfGPU.ComputeDescriptorsRaw(gpuModelImage, null, gpuModelKeyPoints))
            using (GpuBruteForceMatcher<float> matcher = new GpuBruteForceMatcher<float>(DistanceType.L2))
            {
               modelKeyPoints = new VectorOfKeyPoint();
               surfGPU.DownloadKeypoints(gpuModelKeyPoints, modelKeyPoints);
               watch = Stopwatch.StartNew();

               // extract features from the observed image
               using (GpuImage<Gray, Byte> gpuObservedImage = new GpuImage<Gray, byte>(observedImage))
               using (GpuMat<float> gpuObservedKeyPoints = surfGPU.DetectKeyPointsRaw(gpuObservedImage, null))
               using (GpuMat<float> gpuObservedDescriptors = surfGPU.ComputeDescriptorsRaw(gpuObservedImage, null, gpuObservedKeyPoints))
               using (GpuMat<int> gpuMatchIndices = new GpuMat<int>(gpuObservedDescriptors.Size.Height, k, 1, true))
               using (GpuMat<float> gpuMatchDist = new GpuMat<float>(gpuObservedDescriptors.Size.Height, k, 1, true))
               using (GpuMat<Byte> gpuMask = new GpuMat<byte>(gpuMatchIndices.Size.Height, 1, 1))
               using (Stream stream = new Stream())
               {
                  matcher.KnnMatchSingle(gpuObservedDescriptors, gpuModelDescriptors, gpuMatchIndices, gpuMatchDist, k, null, stream);
                  indices = new Matrix<int>(gpuMatchIndices.Size);
                  mask = new Matrix<byte>(gpuMask.Size);

                  //gpu implementation of voteForUniquess
                  using (GpuMat<float> col0 = gpuMatchDist.Col(0))
                  using (GpuMat<float> col1 = gpuMatchDist.Col(1))
                  {
                     GpuInvoke.Multiply(col1, new MCvScalar(uniquenessThreshold), col1, stream);
                     GpuInvoke.Compare(col0, col1, gpuMask, CMP_TYPE.CV_CMP_LE, stream);
                  }

                  observedKeyPoints = new VectorOfKeyPoint();
                  surfGPU.DownloadKeypoints(gpuObservedKeyPoints, observedKeyPoints);

                  //wait for the stream to complete its tasks
                  //We can perform some other CPU intesive stuffs here while we are waiting for the stream to complete.
                  stream.WaitForCompletion();

                  gpuMask.Download(mask);
                  gpuMatchIndices.Download(indices);

                  if (GpuInvoke.CountNonZero(gpuMask) >= 4)
                  {
                     int nonZeroCount = Features2DToolbox.VoteForSizeAndOrientation(modelKeyPoints, observedKeyPoints, indices, mask, 1.5, 20);
                     if (nonZeroCount >= 4)
                        homography = Features2DToolbox.GetHomographyMatrixFromMatchedFeatures(modelKeyPoints, observedKeyPoints, indices, mask, 2);
                  }

                  watch.Stop();
               }
            }
         }
         else
         {
            //extract features from the object image
            modelKeyPoints = new VectorOfKeyPoint();
            Matrix<float> modelDescriptors = surfCPU.DetectAndCompute(modelImage, null, modelKeyPoints);

            watch = Stopwatch.StartNew();

            // extract features from the observed image
            observedKeyPoints = new VectorOfKeyPoint();
            Matrix<float> observedDescriptors = surfCPU.DetectAndCompute(observedImage, null, observedKeyPoints);
            BruteForceMatcher<float> matcher = new BruteForceMatcher<float>(DistanceType.L2);
            matcher.Add(modelDescriptors);

            indices = new Matrix<int>(observedDescriptors.Rows, k);
            using (Matrix<float> dist = new Matrix<float>(observedDescriptors.Rows, k))
            {
               matcher.KnnMatch(observedDescriptors, indices, dist, k, null);
               mask = new Matrix<byte>(dist.Rows, 1);
               mask.SetValue(255);
               Features2DToolbox.VoteForUniqueness(dist, uniquenessThreshold, mask);
            }

            int nonZeroCount = CvInvoke.cvCountNonZero(mask);
            if (nonZeroCount >= 4)
            {
               nonZeroCount = Features2DToolbox.VoteForSizeAndOrientation(modelKeyPoints, observedKeyPoints, indices, mask, 1.5, 20);
               if (nonZeroCount >= 4)
                  homography = Features2DToolbox.GetHomographyMatrixFromMatchedFeatures(modelKeyPoints, observedKeyPoints, indices, mask, 2);
            }

            watch.Stop();
         }
         matchTime = 0;
      }

      /// <summary>
      /// Draw the model image and observed image, the matched features and homography projection.
      /// </summary>
      /// <param name="modelImage">The model image</param>
      /// <param name="observedImage">The observed image</param>
      /// <param name="recPoints">The output total time for computing the homography matrix.</param>
      /// <returns>The model image and observed image, the matched features and homography projection.</returns>
      public static Image<Bgr, Byte> Draw(Image<Gray, Byte> modelImage, Image<Gray, byte> observedImage, out long recPoints)
      {
         HomographyMatrix homography;
         VectorOfKeyPoint modelKeyPoints;
         VectorOfKeyPoint observedKeyPoints;
         Matrix<int> indices;
         Matrix<byte> mask;
         FindMatch(modelImage, observedImage, out recPoints, out modelKeyPoints, out observedKeyPoints, out indices, out mask, out homography);

         //Draw the matched keypoints
         
         Image<Bgr, Byte> result = Features2DToolbox.DrawMatches(modelImage, modelKeyPoints, observedImage, observedKeyPoints,
            indices, new Bgr(0, 255, 0), new Bgr(0, 0, 255), mask, Features2DToolbox.KeypointDrawType.DEFAULT);

         
         #region draw the projected region on the image
         if (homography != null)
         {  //draw a rectangle along the projected model
            Rectangle rect = modelImage.ROI;
            PointF[] pts = new PointF[] { 
               new PointF(rect.Left, rect.Bottom),
               new PointF(rect.Right, rect.Bottom),
               new PointF(rect.Right, rect.Top),
               new PointF(rect.Left, rect.Top)};
            homography.ProjectPoints(pts);
             double mozan = mask.Sum;
            result.DrawPolyline(Array.ConvertAll<PointF, Point>(pts, Point.Round), true, new Bgr(Color.Blue), 5);
            recPoints = Convert.ToInt64(mozan); 
            
         }
         #endregion

         return result;
      }
   }
}
