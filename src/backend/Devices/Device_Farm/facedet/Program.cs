using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Emgu.CV.Face;
using System.IO;
using System.Drawing;
using System;
using System.Collections.Generic;
using Emgu.CV.Util;

const int imageWidth = 100;
const int imageHeight = 100;

List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
Dictionary<int, string> labelsDict = new Dictionary<int, string>();

string trainingImagesFolder = @"D:\Farm_Linh_Huy_HUng\Farm\src\backend\Devices\Device_Farm\facedet\";
string personDir = Path.Combine(trainingImagesFolder, "Faces");

int labelCounter = 0;
string[] fileNames = Directory.GetFiles(personDir, "*.jpg");

VectorOfMat vectorOfImages = new VectorOfMat();
Matrix<int> matrixLabels = new Matrix<int>(fileNames.Length, 1);

foreach (var fileName in fileNames)
{
    Image<Gray, byte> trainingImage = new Image<Gray, byte>(fileName).Resize(imageWidth, imageHeight, Inter.Linear);
    vectorOfImages.Push(trainingImage.Mat);

    string labelName = Path.GetFileNameWithoutExtension(fileName);
    if (!labelsDict.ContainsValue(labelName))
    {
        labelsDict.Add(labelCounter, labelName);
        matrixLabels[labelCounter, 0] = labelCounter;
        labelCounter++;
    }
}

LBPHFaceRecognizer recognizer = new LBPHFaceRecognizer();
recognizer.Train(vectorOfImages, matrixLabels);

VideoCapture capture = new VideoCapture(0);
CascadeClassifier faceDetector = new CascadeClassifier(Path.Combine(trainingImagesFolder, "data", "haarcascade_frontalface_default.xml"));

try
{
    while (true)
    {
        using (Mat frame = capture.QueryFrame())
        {
            if (frame != null)
            {
                Image<Bgr, byte> img = frame.ToImage<Bgr, byte>();
                Image<Gray, byte> grayImg = img.Convert<Gray, byte>();
                Rectangle[] faces = faceDetector.DetectMultiScale(grayImg, 1.1, 10, Size.Empty, Size.Empty);

                foreach (var face in faces)
                {
                    grayImg.ROI = face;
                    var result = recognizer.Predict(grayImg);
                    grayImg.ROI = Rectangle.Empty;

                    string labelName;
                    if (result.Label != -1 && result.Distance < 2000 && labelsDict.TryGetValue(result.Label, out labelName))
                    {
                        img.Draw(face, new Bgr(Color.Green), 2);
                        img.Draw(labelName, new Point(face.X - 2, face.Y - 2), FontFace.HersheyComplex, 1.0, new Bgr(Color.Green));
                    }
                    else
                    {
                        img.Draw(face, new Bgr(Color.Red), 2);
                        img.Draw("Unknown", new Point(face.X - 2, face.Y - 2), FontFace.HersheyComplex, 1.0, new Bgr(Color.Red));
                    }
                }

                CvInvoke.Imshow("Face Recognition", img);
            }

            if (CvInvoke.WaitKey(10) == 27) // ESC key
            {
                break;
            }
        }
    }
}
finally
{
    capture.Dispose();
    CvInvoke.DestroyAllWindows();
}
