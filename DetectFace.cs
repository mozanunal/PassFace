//----------------------------------------------------------------------------
//  Copyright (C) 2004-2013 by EMGU. All rights reserved.       
//----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.GPU;

namespace FaceDetection
{
   public static class DetectFace
   {
       public static void Detect(Image<Bgr, Byte> image, String faceFileName, String eyeFileName, List<Rectangle> faces, List<Rectangle> eyes, out long detectionTime)
       {
           Stopwatch watch;
           //Read the HaarCascade objects
           using (CascadeClassifier face = new CascadeClassifier(faceFileName))
           using (CascadeClassifier eye = new CascadeClassifier(eyeFileName))
           {
               watch = Stopwatch.StartNew();
               using (Image<Gray, Byte> gray = image.Convert<Gray, Byte>()) //Convert it to Grayscale
               {
                   //normalizes brightness and increases contrast of the image
                   gray._EqualizeHist();

                   //Detect the faces  from the gray scale image and store the locations as rectangle
                   //The first dimensional is the channel
                   //The second dimension is the index of the rectangle in the specific channel
                   Rectangle[] facesDetected = face.DetectMultiScale(
                       gray,
                       1.1,
                       10,
                       new Size(20, 20),
                       Size.Empty);
                   faces.AddRange(facesDetected);

                   foreach (Rectangle f in facesDetected)
                   {
                       //Set the region of interest on the faces
                       gray.ROI = f;
                       Rectangle[] eyesDetected = eye.DetectMultiScale(
                       gray,
                       1.1,
                       10,
                       new Size(20, 20),
                       Size.Empty);
                       gray.ROI = Rectangle.Empty;

                       foreach (Rectangle e in eyesDetected)
                       {
                           Rectangle eyeRect = e;
                           eyeRect.Offset(f.X, f.Y);
                           eyes.Add(eyeRect);
                       }
                   }
               }
               watch.Stop();
               detectionTime = watch.ElapsedMilliseconds;
           }

       }


   }
}
