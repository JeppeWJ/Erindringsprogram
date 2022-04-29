using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
using System.Data.SqlClient;
using System.IO;
using System.Media;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Drawing;
using DTOs;


namespace DataAccessLayer
{

    public class DataAccess : DataAccessSubject
    {
        private string connString =
            "Server=tcp:st4prj4.database.windows.net,1433;Initial Catalog=ST4PRJ4;Persist Security Info=False;User ID=azureuser;Password=Katrinebjerg123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"; //Connection string for the database

        private string imagePath { get; set; }
        public string audioPath { get; set; }
        private SqlDataReader dataReader;
        private IDataAccessObserver _dataAccessObserverImplementation;


        public static byte[] ImageToByte(BitmapImage bitmapImage)
        {
            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapImage));
                enc.Save(outStream);
                System.Drawing.Bitmap img = new System.Drawing.Bitmap(outStream);
                ImageConverter converter = new ImageConverter();
                return (byte[]) converter.ConvertTo(img, typeof(byte[]));
            }
        } //System.InvalidCastException: 'Unable to cast object of type 'System.Windows.Media.Imaging.BitmapImage' to type 'System.Drawing.Image'.'

        private void LoadImage() //Click on the load button
        {
            OpenFileDialog openFile = new OpenFileDialog(); //create object for Filedialog

            openFile.FileName = "";
        }



        public void SelectImageOrAudioFromPC(bool fileType, uint personID)
        {
            byte[] data = new byte[] { };
            string filetype;

            if (fileType)
            {
                filetype = "Sound";
            }
            else
            {
                filetype = "Image";
            }

            OpenFileDialog openFile = new OpenFileDialog(); //create object for Filedialog

            openFile.FileName = "";

            if (filetype == "Sound")
            {
                openFile.Filter = "MP3 files|*.mp3"; // Filter only supported mp3 files

                if (
                    openFile.ShowDialog() ==
                    true) //Opens a dialog from the computer and if OK is clicked, the code in the if-statement will be executed
                {
                    audioPath = openFile.FileName; // Set the filename path for the audio

                    //var soundFileBA = File.ReadAllBytes(audioPath);


                    RelativeDTO relativeDto = new RelativeDTO();
                    relativeDto.Audio = audioPath;
                    relativeDto.PersonID = personID;
                    
                    NotifyObservers(relativeDto, fileType);
                    
                }
            }
            else if (filetype == "Image")
            {
                openFile.Filter = "Supported Images|*.jpg;*.jpeg.*png"; // Filter only supported pictures

                if (
                    openFile.ShowDialog() ==
                    true) //Opens a dialog from the computer and if OK is clicked, the code in the if-statement will be executed
                {
                    imagePath = openFile.FileName; // Set the filename path for the image

                    RelativeDTO relativeDto = new RelativeDTO();
                    relativeDto.Picture = imagePath;
                    relativeDto.PersonID = personID;

                    NotifyObservers(relativeDto, fileType);
                   
                }
            }


            
        }

        public void UploadImageOrAudioToDB(bool fileType, uint personID) // Upload the sound to the database
        {
                byte[] data = new byte[] { };
                string filetype;

                if (fileType)
                {
                    filetype = "Sound";
                }
                else
                {
                    filetype = "Image";
                }

                OpenFileDialog openFile = new OpenFileDialog(); //create object for Filedialog


                openFile.FileName = $"{filetype}";


                if (filetype == "Sound")
                {
                    openFile.Filter = "MP3 files|*.mp3"; // Filter only supported mp3 files

                    if (openFile.ShowDialog() == true) //Opens a dialog from the computer and if OK is clicked, the code in the if-statement will be executed
                    {
                        audioPath = openFile.FileName; // Set the filename path for the audio

                        var soundFileBA = File.ReadAllBytes(audioPath);

                        RelativeDTO relativeDto = new RelativeDTO();
                        relativeDto.Audio = audioPath;
                        relativeDto.PersonID = personID; 
                        NotifyObservers(relativeDto, fileType);
                        data = soundFileBA;
                    }
                }
                else if (filetype == "Image")
                {
                    openFile.Filter = "Supported Images|*.jpg;*.jpeg.*png"; // Filter only supported pictures

                    if (
                        openFile.ShowDialog() ==
                        true) //Opens a dialog from the computer and if OK is clicked, the code in the if-statement will be executed
                    {
                        imagePath = openFile.FileName; // Set the filename path for the image

                        var imageBA = File.ReadAllBytes(imagePath);

                        RelativeDTO relativeDto = new RelativeDTO();
                        relativeDto.Picture = imagePath;
                        relativeDto.PersonID = personID;
                        
                        NotifyObservers(relativeDto, fileType);
                        data = imageBA;
                    }
                }

                //Create and Open connection to the database
                SqlConnection connection = new SqlConnection(connString);
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                //query
                command.CommandText = $"UPDATE Test_table SET {filetype} = {data} WHERE PersonID = {personID}"; //Insert commandtext to database

                //Close connection to the database
                connection.Close();
        }



            public void GetImageOrAudioFromDB(bool fileType, uint personID) // Receive the sound from database
            {
                byte[] output = new byte[] { };
                string filetype;
                if (fileType == true)
                {
                    filetype = "Sound";
                }
                else
                {
                    filetype = "Image";
                }


                SqlConnection connection = new SqlConnection(connString);
                connection.Open(); // Open connection to database
                SqlCommand command = connection.CreateCommand();
                command.CommandText = $"Select {filetype} from Test_table WHERE PersonID={personID}";
                dataReader = command.ExecuteReader(); // Execute the command text to the database


                while (dataReader.Read()) //Reading from the database and converting the data to byte array
                {
                    output = (byte[]) dataReader.GetValue(0);
                }

                connection.Close();

                

                if (filetype == "Sound")
                {
                    var path = $@"sound-{personID}.mp3"; // Specifying a file name
                    File.WriteAllBytes(path, output); // Save the filename and byte array in a mp3 file
                    string url = $@".\bin\Debug\sound-{personID}.mp3";
                    
                    RelativeDTO relativeDto = new RelativeDTO();
                    relativeDto.Audio = url; // We set the audio path for our audio in the DTO
                    relativeDto.PersonID = personID;
                    NotifyObservers(relativeDto, fileType);

                }
                else if (filetype == "Image")
                {
                    var path = $@"image-{personID}.jpg"; // Specifying a file name
                    File.WriteAllBytes(path, output); // Save the filename and byte array in a mp3 file
                    string url = $@".\bin\Debug\image-{personID}.mp3";

                    RelativeDTO relativeDto = new RelativeDTO();
                    relativeDto.Picture = url; // We set the image path for our image in the DTO
                    relativeDto.PersonID = personID;
                    NotifyObservers(relativeDto, fileType);
                }
                //https://stackoverflow.com/questions/2665362/convert-byte-array-to-wav-file
            }

        
    }
}
