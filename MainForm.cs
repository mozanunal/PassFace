
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Diagnostics;
using FaceDetection;
using SURFFeatureExample;
using Emgu.CV.UI;
using Emgu.CV.GPU;
using Emgu.CV.CvEnum;
using System.IO;

namespace PassFace
{
   public partial class MainForm : Form
   {

      public MainForm()
      {
         InitializeComponent();
         CameraCapture();
         CheckForIllegalCrossThreadCalls = false;
      }
      Image<Bgr, Byte> image;
      private Capture _capture = null;
      private bool _captureInProgress;
      MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);
      //Eigen Parameters
      int eigenTrainedImageCounter;
      List<Image<Gray, byte>> eigenTrainingImages = new List<Image<Gray, byte>>();
      List<int> eigenIntlabels = new List<int>();
      List<string> eigenlabels = new List<string>();
      EigenFaceRecognizer eigenFaceRecognizer;
      //Fisher Parameters
      int fisherTrainedImageCounter;
      List<Image<Gray, byte>> fisherTrainingImages = new List<Image<Gray, byte>>();
      List<int> fisherIntlabels = new List<int>();
      List<string> fisherlabels = new List<string>();
      FisherFaceRecognizer fisherFaceRecognizer;
       //LBPH Parameters
      int lbphTrainedImageCounter;
      List<Image<Gray, byte>> lbphTrainingImages = new List<Image<Gray, byte>>();
      List<int> lbphIntlabels = new List<int>();
      List<string> lbphlabels = new List<string>();
      LBPHFaceRecognizer lbphFaceRecognizer;
       
      private void CameraCapture()
      {
         try
         {
            _capture = new Capture();

            _capture.ImageGrabbed += ProcessFrame2;

        }
         catch (NullReferenceException excpt)
         {
            MessageBox.Show(excpt.Message);
         }
      }

      private void ProcessFrame(object sender, EventArgs arg)
      {
          if (faceRecog.Checked == true)
          {
              long recpoints;
              Image<Bgr, Byte> img = new Image<Bgr, byte>(secondImageBox.Image.Bitmap);
              using (Image<Gray, Byte> modelImage = img.Convert<Gray, Byte>())
              using (Image<Gray, Byte> observedImage = _capture.RetrieveBgrFrame().Convert<Gray, Byte>())
              {
                  Image<Bgr, byte> result = SurfRecognizer.Draw(modelImage, observedImage, out recpoints);
                  captureImageBox.Image = observedImage;
                  if (recpoints > 10)
                  {
                      MCvFont f = new MCvFont(Emgu.CV.CvEnum.FONT.CV_FONT_HERSHEY_COMPLEX, 1.0, 1.0);
                      //Draw "Hello, world." on the image using the specific font
                      result.Draw("Person Recognited, Welcome", ref f, new Point(40, 40), new Bgr(0, 255, 0));
                      ImageViewer.Show(result, String.Format(" {0} Points Recognited", recpoints));
                  }
              }
          }
          ///////////////////////////////////////////////////////////////////////
          if (faceRecog.Checked == false)
          {
              Image<Bgr, Byte> detectedface;
              Image<Bgr, Byte> frame = _capture.RetrieveBgrFrame();
              Image<Bgr, Byte> image = frame.Resize(400, 300, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);//Read the files as an 8-bit Bgr image  
              long detectionTime;
              List<Rectangle> faces = new List<Rectangle>();
              List<Rectangle> eyes = new List<Rectangle>();
              DetectFace.Detect(image, "haarcascade_frontalface_default.xml", "haarcascade_eye.xml", faces, eyes, out detectionTime);
              foreach (Rectangle face in faces)
              {
                  image.Draw(face, new Bgr(Color.Red), 2);
                  image.ROI = face;
                  detectedface = image;
                  if (eqHisChecked.Checked == false)
                      secondImageBox.Image = detectedface.Convert<Gray, Byte>().Resize(2, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                  CvInvoke.cvResetImageROI(image);

              }
              foreach (Rectangle eye in eyes)
              {
                  image.Draw(eye, new Bgr(Color.Blue), 2);
              }
              captureImageBox.Image = image;
          }
      }
      private void ProcessFrame2(object sender, EventArgs arg)
      {
          if (comboBoxCapture.Text == "Camera")
          {
              image = _capture.RetrieveBgrFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
          }
          

          if (comboBoxCapture.Text == "Single Image")
          {
            OpenFileDialog Openfile = new OpenFileDialog();
            if (Openfile.ShowDialog() == DialogResult.OK)
            {
                image = new Image<Bgr, byte>(Openfile.FileName);
            }
          }

          List<Rectangle> faces = new List<Rectangle>();
          List<Rectangle> eyes = new List<Rectangle>();
          long detectionTime;
          DetectFace.Detect(image, "haarcascade_frontalface_default.xml", "haarcascade_eye.xml", faces, eyes, out detectionTime);
          foreach (Rectangle face in faces)
          {
              //Image ROI selected as each face in image 
              if (workCorruptedImages.Checked == true)
              {
                  image.ROI = face;
              }
              if (faceRecog.Checked == true)
              {
                  //now program apply selected algorithm if recognition has started

                  //For SURF Algorithm
                  if (comboBoxAlgorithm.Text == "SURF Feature Extractor")
                  {
                      string dataDirectory=Directory.GetCurrentDirectory()+"\\TrainedFaces";
                      string[] files = Directory.GetFiles(dataDirectory, "*.jpg", SearchOption.AllDirectories);

                      foreach (var file in files)
                      {
                          richTextBox1.Text += file.ToString();
                          long recpoints;
                          Image<Bgr,Byte>sampleImage = new Image<Bgr, Byte>(file);
                          secondImageBox.Image = sampleImage;
                          using (Image<Gray, Byte> modelImage = sampleImage.Convert<Gray, Byte>())
                          using (Image<Gray, Byte> observedImage = image.Convert<Gray, Byte>())
                          {
                              Image<Bgr, byte> result = SurfRecognizer.Draw(modelImage, observedImage, out recpoints);
                              //captureImageBox.Image = observedImage;
                              if (recpoints > 10)
                              {
                                  MCvFont f = new MCvFont(Emgu.CV.CvEnum.FONT.CV_FONT_HERSHEY_COMPLEX, 1.0, 1.0);
                                  result.Draw("Person Recognited, Welcome", ref f, new Point(40, 40), new Bgr(0, 255, 0));
                                  ImageViewer.Show(result, String.Format(" {0} Points Recognited", recpoints));
                              }
                          }
                      }


                  }
                  //For EigenFaces
                  else if (comboBoxAlgorithm.Text == "EigenFaces")
                  {
                      CvInvoke.cvResetImageROI(image);
                      //image._EqualizeHist();
                      if (eqHisChecked.Checked == true)
                      {
                          image._EqualizeHist();
                      }
                      var result = eigenFaceRecognizer.Predict(image.Convert<Gray, Byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC));
                      if (result.Label != -1)
                      {
                          image.Draw(eigenlabels[result.Label].ToString(), ref font, new Point(face.X - 2, face.Y - 2), new Bgr(Color.LightGreen));
                          label6.Text = result.Distance.ToString();
                      }
                  }
                  //For FisherFaces
                  else if (comboBoxAlgorithm.Text == "FisherFaces")
                  {
                      CvInvoke.cvResetImageROI(image);
                      if (eqHisChecked.Checked == true)
                      {
                          image._EqualizeHist();
                      }
                      var result = fisherFaceRecognizer.Predict(image.Convert<Gray, Byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC));
                      if (result.Label != -1)
                      {
                          image.Draw(fisherlabels[result.Label].ToString(), ref font, new Point(face.X - 2, face.Y - 2), new Bgr(Color.LightGreen));
                          label6.Text = result.Distance.ToString();
                      }

                  }

                  //For LBPH
                  else if (comboBoxAlgorithm.Text == "LBPHFaces")
                  {
                      if (eqHisChecked.Checked == true)
                      {
                          image._EqualizeHist();
                      }
                      var result = lbphFaceRecognizer.Predict(image.Convert<Gray, Byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC));
                      if (result.Label != -1)
                      {
                          CvInvoke.cvResetImageROI(image);
                          image.Draw(lbphlabels[result.Label].ToString(), ref font, new Point(face.X - 2, face.Y - 2), new Bgr(Color.LightGreen));
                          label6.Text = result.Distance.ToString();
                          label7.Text = lbphlabels[result.Label].ToString();
                      }

                  }



              }

              CvInvoke.cvResetImageROI(image);
              image.Draw(face, new Bgr(Color.Red), 2);
          }
          captureImageBox.Image = image;

      }
      private void ReleaseData()
      {
         if (_capture != null)
            _capture.Dispose();
      }

      private void captureButton_Click(object sender, EventArgs e)
      {


          if (comboBoxCapture.Text == "Camera")
          {
              if (_capture != null)
              {
                  if (_captureInProgress)
                  {  //stop the capture
                      comboBoxCapture.Enabled = true;
                      captureButton.Text = "Start Capture";
                      _capture.Pause();
                  }
                  else
                  {
                      //start the capture
                      comboBoxCapture.Enabled = false;
                      captureButton.Text = "Stop";
                      _capture.Start();
                  }

                  _captureInProgress = !_captureInProgress;

              }
          }
          else if (comboBoxCapture.Text == "Single Image")
          {
              ProcessFrame2(null,new EventArgs());
          }



      }

      private void faceRecog_CheckedChanged(object sender, EventArgs e)
      {

      }

      private void addDatabaseButton_Click(object sender, EventArgs e)
      {
          //Take time for save filename
          string fileName = textBox1.Text+"_"+DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString()
          + "-" + DateTime.Now.Hour.ToString() + "-" + DateTime.Now.Minute.ToString()+"-" + DateTime.Now.Second.ToString()+".jpg";

          //First The faces in the Image is detected
          Image<Bgr, Byte> image = _capture.RetrieveBgrFrame().Resize(400, 300, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
          List<Rectangle> faces = new List<Rectangle>();
          List<Rectangle> eyes = new List<Rectangle>();
          long detectionTime;
          DetectFace.Detect(image, "haarcascade_frontalface_default.xml", "haarcascade_eye.xml", faces, eyes, out detectionTime);
          foreach (Rectangle face in faces)
          {

              image.ROI = face;
              
          }
          Directory.CreateDirectory("TrainedFaces");
          image.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC).ToBitmap().Save("TrainedFaces\\" + fileName);

      }

      private void comboBoxAlgorithm_SelectedIndexChanged(object sender, EventArgs e)
      {


      }

      string fileName(string file) 
      {
          string[] fileArr = file.Split('\\');
          var fileName=fileArr[fileArr.Length - 1].Split(comboBoxSplitChar.Text.ToCharArray()[0])[0];
          return fileName;
      }

      string fileNameforExtract(string file)
      {
          string[] fileArr = file.Split('\\');
          var fileName = fileArr[fileArr.Length - 1];
          return fileName;
      }

      private void comboBoxCapture_SelectedIndexChanged(object sender, EventArgs e)
      {

      }

      private void richTextBox1_TextChanged(object sender, EventArgs e)
      {
          richTextBox1.SelectionStart = richTextBox1.Text.Length;
          richTextBox1.ScrollToCaret();
      }

      private void button1_Click(object sender, EventArgs e)
      {
          if (comboBoxAlgorithm.Text == "EigenFaces")
          {
              try
              {
                  string dataDirectory = Directory.GetCurrentDirectory() + "\\TrainedFaces";

                  string[] files = Directory.GetFiles(dataDirectory, "*.jpg", SearchOption.AllDirectories);
                  eigenTrainedImageCounter = 0;
                  foreach (var file in files)
                  {
                      Image<Bgr, Byte> TrainedImage = new Image<Bgr, Byte>(file);
                      if (eqHisChecked.Checked == true)
                      {
                          TrainedImage._EqualizeHist();
                      }
                      eigenTrainingImages.Add(TrainedImage.Convert<Gray, Byte>());
                      eigenlabels.Add(fileName(file));
                      eigenIntlabels.Add(eigenTrainedImageCounter);
                      eigenTrainedImageCounter++;
                      richTextBox1.Text += fileName(file) + "\n";
                  }
                  /*
                      //TermCriteria for face recognition with numbers of trained images like maxIteration
                      MCvTermCriteria termCrit = new MCvTermCriteria(eigenTrainedImageCounter, 0.001);
                        
                      //Eigen face recognizer
                      eigenObjRecognizer=new EigenObjectRecognizer(
                        eigenTrainingImages.ToArray(),
                        eigenlabels.ToArray(),
                        3000,
                        ref termCrit);
                   */
                  eigenFaceRecognizer = new EigenFaceRecognizer(eigenTrainedImageCounter, 2000);
                  eigenFaceRecognizer.Train(eigenTrainingImages.ToArray(), eigenIntlabels.ToArray());
                  //eigenFaceRecognizer.Save(dataDirectory + "\\trainedDataEigen.dat");

              }
              catch (Exception ex)
              {
                  MessageBox.Show(ex.ToString());
                  MessageBox.Show("Nothing in binary database, please add at least a face(Simply train the prototype with the Add Face Button).", "Triained faces load", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
              }
          }

          else if (comboBoxAlgorithm.Text == "FisherFaces")
          {
              try
              {
                  string dataDirectory = Directory.GetCurrentDirectory() + "\\TrainedFaces";

                  string[] files = Directory.GetFiles(dataDirectory, "*.jpg", SearchOption.AllDirectories);
                  fisherTrainedImageCounter = 0;
                  foreach (var file in files)
                  {
                      Image<Bgr, Byte> TrainedImage = new Image<Bgr, Byte>(file);
                      fisherTrainingImages.Add(TrainedImage.Convert<Gray, Byte>());
                      if (eqHisChecked.Checked == true)
                      {
                          TrainedImage._EqualizeHist();
                      }
                      fisherlabels.Add(fileName(file));
                      fisherIntlabels.Add(fisherTrainedImageCounter);
                      fisherTrainedImageCounter++;
                      richTextBox1.Text += fileName(file) + "\n";
                  }
                  fisherFaceRecognizer = new FisherFaceRecognizer(fisherTrainedImageCounter, 2000);
                  fisherFaceRecognizer.Train(fisherTrainingImages.ToArray(), fisherIntlabels.ToArray());
                  //fisherFaceRecognizer.Save(dataDirectory + "\\trainedDataFisher.dat");

              }
              catch (Exception ex)
              {
                  MessageBox.Show(ex.ToString());
                  MessageBox.Show("Nothing in binary database, please add at least a face(Simply train the prototype with the Add Face Button).", "Triained faces load", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
              }



          }

          else if (comboBoxAlgorithm.Text == "LBPHFaces")
          {
              try
              {
                  string dataDirectory = Directory.GetCurrentDirectory() + "\\TrainedFaces";

                  string[] files = Directory.GetFiles(dataDirectory, "*.jpg", SearchOption.AllDirectories);
                  lbphTrainedImageCounter = 0;
                  foreach (var file in files)
                  {
                      Image<Bgr, Byte> TrainedImage = new Image<Bgr, Byte>(file);
                      if (eqHisChecked.Checked == true)
                      {
                          TrainedImage._EqualizeHist();
                      }
                      lbphTrainingImages.Add(TrainedImage.Convert<Gray, Byte>());
                      lbphlabels.Add(fileName(file));
                      lbphIntlabels.Add(lbphTrainedImageCounter);
                      lbphTrainedImageCounter++;
                      richTextBox1.Text += fileName(file) + "\n";
                  }
                  lbphFaceRecognizer = new LBPHFaceRecognizer(1, 8, 8, 8, 400);
                  lbphFaceRecognizer.Train(lbphTrainingImages.ToArray(), lbphIntlabels.ToArray());
                  lbphFaceRecognizer.Save(dataDirectory + "\\trainedDataLBPH.dat");

              }
              catch (Exception ex)
              {
                  MessageBox.Show(ex.ToString());
                  MessageBox.Show("Nothing in binary database, please add at least a face(Simply train the prototype with the Add Face Button).", "Triained faces load", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
              }



          }

      }

      private void button2_Click(object sender, EventArgs e)
      {
          if (comboBoxAlgorithm.Text == "EigenFaces")
          {
              try
              {
                  string dataDirectory = Directory.GetCurrentDirectory() + "\\TrainedFaces\\trainedDataEigen.dat";
                  eigenFaceRecognizer = new EigenFaceRecognizer(eigenTrainedImageCounter, 3000);
                  eigenFaceRecognizer.Load(dataDirectory);
                  richTextBox1.Text += "Trained Database Loaded.";

              }
              catch (Exception ex)
              {
                  MessageBox.Show(ex.ToString());
                  MessageBox.Show("Nothing in binary database, please add at least a face(Simply train the prototype with the Add Face Button).", "Triained faces load", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
              }
          }

          else if (comboBoxAlgorithm.Text == "FisherFaces")
          {
              try
              {
                  string dataDirectory = Directory.GetCurrentDirectory() + "\\TrainedFaces\\trainedDataFisher.dat";

                  fisherFaceRecognizer = new FisherFaceRecognizer(fisherTrainedImageCounter, 3000);
                  fisherFaceRecognizer.Load(dataDirectory);
                  richTextBox1.Text += "Trained Database Loaded.";
              }
              catch (Exception ex)
              {
                  MessageBox.Show(ex.ToString());
                  MessageBox.Show("Nothing in binary database, please add at least a face(Simply train the prototype with the Add Face Button).", "Triained faces load", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
              }



          }

          else if (comboBoxAlgorithm.Text == "LBPHFaces")
          {
              try
              {
                  string dataDirectory = Directory.GetCurrentDirectory() + "\\TrainedFaces\\trainedDataLBPH.dat";
                  lbphFaceRecognizer = new LBPHFaceRecognizer(1, 8, 8, 8, 400);
                  lbphFaceRecognizer.Load(dataDirectory);
                  richTextBox1.Text += "Trained Database Loaded.";
              }
              catch (Exception ex)
              {
                  MessageBox.Show(ex.ToString());
                  MessageBox.Show("Nothing in binary database, please add at least a face(Simply train the prototype with the Add Face Button).", "Triained faces load", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
              }



          }

      }

      private void buttonFaceExtract_Click(object sender, EventArgs e)
      {
          string dataDirectory = directoryFaceExtract.Text;

          string[] files = Directory.GetFiles(dataDirectory, "*.jpg", SearchOption.AllDirectories);

          foreach (var file in files)
          {
            Image<Bgr, byte>  fullImage = new Image<Bgr, byte>(file);
             
            List<Rectangle> faces = new List<Rectangle>();
            List<Rectangle> eyes = new List<Rectangle>();
            long detectionTime;
            DetectFace.Detect(fullImage, "haarcascade_frontalface_default.xml", "haarcascade_eye.xml", faces, eyes, out detectionTime);
            foreach (Rectangle face in faces)
            {
                string fileNameImage = fileNameforExtract(file);
                fullImage.ROI = face;
                Directory.CreateDirectory("TrainedFaces");
                fullImage.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC).ToBitmap().Save("TrainedFaces\\" + fileNameImage);
                richTextBox1.Text += fileNameImage + "\n";
                secondImageBox.Image = fullImage;
            }

          }
      }







   }
}
