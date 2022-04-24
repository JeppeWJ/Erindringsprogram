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


namespace DataAccessLayer
{

    public class DataAccess : DataAccessSubject
    {
        private string connString = "Server=tcp:st4prj4.database.windows.net,1433;Initial Catalog=ST4PRJ4;Persist Security Info=False;User ID=azureuser;Password=Katrinebjerg123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"; //Connection string for the database
        private string imagePath { get; set; }
        public string audioPath { get; set; }
        private SqlDataReader dataReader;

        

        public static byte[] ImageToByte(BitmapImage bitmapImage)
        {
            using (MemoryStream outStream = new MemoryStream())
            { 
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapImage));
                enc.Save(outStream);
                System.Drawing.Bitmap img = new System.Drawing.Bitmap(outStream);
                ImageConverter converter = new ImageConverter();
                return (byte[])converter.ConvertTo(img, typeof(byte[]));
            }
        } //System.InvalidCastException: 'Unable to cast object of type 'System.Windows.Media.Imaging.BitmapImage' to type 'System.Drawing.Image'.'

      private void LoadImage() //Click on the load button
      {
         OpenFileDialog openFile = new OpenFileDialog(); //create object for Filedialog

         openFile.FileName = "";






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

                    ManageFile(soundFileBA, fileType, personID);
                    data = soundFileBA;
                }
            }
            else if (filetype == "Image")
            {
                openFile.Filter = "Supported Images|*.jpg;*.jpeg.*png"; // Filter only supported pictures

                if (openFile.ShowDialog() == true) //Opens a dialog from the computer and if OK is clicked, the code in the if-statement will be executed
                {
                    imagePath = openFile.FileName; // Set the filename path for the image

                    var imageBA = File.ReadAllBytes(imagePath);
                    //image = new BitmapImage(new Uri(openFile.FileName)); //Adding and showing the image to the image control in the WPF
                    //var imageBA = ImageToByte(image);

                    ManageFile(imageBA, fileType, personID);
                    data = imageBA;
                }
            }


            

            SqlConnection connection = new SqlConnection(connString);
            connection.Open(); // Open connection to the database

            SqlCommand command = connection.CreateCommand();

            

            //query
            command.CommandText = $"UPDATE Test_table SET {filetype} = {data} WHERE PersonID = {personID}"; //Insert commandtext to database

            //if (fileType)
            //{
            //    if (/*command.ExecuteNonQuery() > 0*/     ) 
            //    {
            //        MessageBox.Show("Billedet blev uploadet til database");
            //    }
            //    else
            //    {
            //        MessageBox.Show("Billedet blev ikke uploadet til database");
            //    }
            //}
            //else
            //{
            //    if (/*command.ExecuteNonQuery() > 0*/) 
            //    {
            //MessageBox.Show("Lyden blev uploadet til database");
            //    }
            //    else
            //    {
            //        MessageBox.Show("Lyden blev ikke uploadet til database");
            //    }
            //}

            connection.Close(); 
        }



        public string GetImageOrAudioFromDB(bool fileType, uint personID) // Receive the sound from database
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
                output = (byte[])dataReader.GetValue(0);
            }

            connection.Close(); 

            var path = @"file.mp3"; // Specifying a file name
            File.WriteAllBytes(path, output); // Save the filename and byte array in a mp3 file


            string url = @".\bin\Debug\file.mp3";

            ManageFile(output, fileType, personID);

            return path;

            //@"C:\Users\Søren Mehlsen\source\repos\soerenmehlsen\ST4PRJ4_Database_WPF\ST4PRJ4_Database_WPF\bin\Debug\file.mp3"; //file path
            //mediaPlayer.Open(new Uri(url)); // Open the music file from the path
            //mediaPlayer.Play(); //Play the sound

            //https://stackoverflow.com/questions/2665362/convert-byte-array-to-wav-file
        }


        public void Update(byte[] blob)
        {

        }

        //private void ShowImage()
        //{
        //    string connString = "Server=tcp:st4prj4.database.windows.net,1433;Initial Catalog=ST4PRJ4;Persist Security Info=False;User ID=azureuser;Password=Katrinebjerg123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"; //Connection string for the database

        //    SqlConnection connection = new SqlConnection(connString);

        //    connection.Open();

        //    SqlCommand command = connection.CreateCommand();

        //    command.CommandText = "Select Image from Test_table WHERE PersonID=4";

        //    dataReader = command.ExecuteReader();


        //    while (dataReader.Read())
        //    {
        //        output = (byte[])dataReader.GetValue(0);
        //    }

        //    connection.Close();

        //    Stream streamObj = new MemoryStream(output);
        //    BitmapImage bitObj = new BitmapImage();

        //    bitObj.BeginInit();
        //    bitObj.StreamSource = streamObj;
        //    bitObj.EndInit();

        //    ShowImage.Source = bitObj;

        //    //https://stackoverflow.com/questions/14337071/convert-array-of-bytes-to-bitmapimage
        //    //https://sqltutorialtips.blogspot.com/2016/11/image-vs-varbinarymax.html
        //    //https://www.c-sharpcorner.com/UploadFile/0f100d/storing-and-retrieving-image-from-sql-server-database-in-wpf/
        //    //https://www.youtube.com/watch?v=XMhcF-zex6k
        //    //https://www.youtube.com/watch?v=HIv1_P98Ne8&list=LL&index=2&t=182s
        //}


        //private void AddImage(bool fileType, uint personID) //Click on the add button
        //{
        //    // Connection string to the database
        //    //string connString = "Server=tcp:st4prj4.database.windows.net,1433;Initial Catalog=ST4PRJ4;Persist Security Info=False;User ID=azureuser;Password=Katrinebjerg123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"; //Connection string for the database

        //    SqlConnection connection = new SqlConnection(connString);

        //    connection.Open(); //Open the connection to the database

        //    SqlCommand command = connection.CreateCommand();

        //    // Convert image to byte array
        //    byte[] data;

        //    data = File.ReadAllBytes(imagePath); //Reads the content of the audio file and converting it to byte array

        //    //Define image parameter
        //    command.Parameters.AddWithValue("@image", data);

        //    //query
        //    command.CommandText = $"INSERT INTO Test_table(PersonID, Image) VALUES({personID}, @image)"; //Insert commandtext to database

        //    if (command.ExecuteNonQuery() > 0) //Check if the command get executed to the database
        //    {
        //        MessageBox.Show("Billedet blev uploadet til database");
        //    }
        //    else
        //    {
        //        MessageBox.Show("Billedet blev ikke uploadet til database");
        //    }
        //    connection.Close(); // Close connection to the database

        //}
        //private void LoadImageFile(bool fileType, uint personID) //Click on the load button
        //{



        //}
        //private void AudioPlay() // Chose the audio file from the computer
        //{
        //    mediaPlayer.Open(new Uri(audioPath)); //Open the audio from the filepath with the mediaplayer
        //    mediaPlayer.Play(); // Play the audio with mediaplayer
        //}
    }
}
