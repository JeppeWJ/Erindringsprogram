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
using DataAccessLayer;

namespace DataAccess_2
{

    public class DataAccess : DataAccessSubject
    {

        private string imagePath { get; set; }
        public string audioPath { get; set; }
        private SqlDataReader dataReader;
        private byte[] output;
        private MediaPlayer mediaPlayer = new MediaPlayer();




        public void ManageFile(byte[] blob, bool fileType, uint personID)
        {
            NotifyObservers(blob, fileType, personID);
        }

        private void LoadImage() //Click on the load button
        {
            OpenFileDialog openFile = new OpenFileDialog(); //create object for Filedialog

            openFile.FileName = "";

            openFile.Filter = "Supported Images|*.jpg;*.jpeg.*png"; // Filter only supported pictures

            if (openFile.ShowDialog() == true) //Opens a dialog from the computer and if OK is clicked, the code in the if-statement will be executed
            {
                imagePath = openFile.FileName; // Set the filename path for the image
                AddImage.Source = new BitmapImage(new Uri(openFile.FileName)); //Adding and showing the image to the image control in the WPF
            }
        }



        private void AddImage() //Click on the add button
        {
            // Connection string to the database
            string connString = "Server=tcp:st4prj4.database.windows.net,1433;Initial Catalog=ST4PRJ4;Persist Security Info=False;User ID=azureuser;Password=Katrinebjerg123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"; //Connection string for the database

            SqlConnection connection = new SqlConnection(connString);

            connection.Open(); //Open the connection to the database

            SqlCommand command = connection.CreateCommand();

            // Convert image to byte array
            byte[] data;

            data = File.ReadAllBytes(imagePath); //Reads the content of the audio file and converting it to byte array

            //Define image parameter
            command.Parameters.AddWithValue("@image", data);

            //query
            command.CommandText = "INSERT INTO Test_table(PersonID, FirstName, LastName, Image) VALUES(4, 'Magnus', 'Andersen', @image)"; //Insert commandtext to database

            if (command.ExecuteNonQuery() > 0) //Check if the command get executed to the database
            {
                MessageBox.Show("Billedet blev uploadet til database");
            }
            else
            {
                MessageBox.Show("Billedet blev ikke uploadet til database");
            }
            connection.Close(); // Close connection to the database

        }

        private void ShowImage()
        {
            string connString = "Server=tcp:st4prj4.database.windows.net,1433;Initial Catalog=ST4PRJ4;Persist Security Info=False;User ID=azureuser;Password=Katrinebjerg123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"; //Connection string for the database

            SqlConnection connection = new SqlConnection(connString);

            connection.Open();

            SqlCommand command = connection.CreateCommand();

            command.CommandText = "Select Image from Test_table WHERE PersonID=4";

            dataReader = command.ExecuteReader();


            while (dataReader.Read())
            {
                output = (byte[])dataReader.GetValue(0);
            }

            connection.Close();

            Stream streamObj = new MemoryStream(output);
            BitmapImage bitObj = new BitmapImage();

            bitObj.BeginInit();
            bitObj.StreamSource = streamObj;
            bitObj.EndInit();

            ShowImage.Source = bitObj;

            //https://stackoverflow.com/questions/14337071/convert-array-of-bytes-to-bitmapimage
            //https://sqltutorialtips.blogspot.com/2016/11/image-vs-varbinarymax.html
            //https://www.c-sharpcorner.com/UploadFile/0f100d/storing-and-retrieving-image-from-sql-server-database-in-wpf/
            //https://www.youtube.com/watch?v=XMhcF-zex6k
            //https://www.youtube.com/watch?v=HIv1_P98Ne8&list=LL&index=2&t=182s
        }

        private void AudioPlay() // Chose the audio file from the computer
        {
            OpenFileDialog openFile = new OpenFileDialog(); //create object for Filedialog

            openFile.FileName = "";

            openFile.Filter = "MP3 files|*.mp3"; // Filter only supported mp3 files

            if (openFile.ShowDialog() == true) //Opens a dialog from the computer and if OK is clicked, the code in the if-statement will be executed
            {
                audioPath = openFile.FileName; // Set the filename path for the audio
                mediaPlayer.Open(new Uri(audioPath)); //Open the audio from the filepath with the mediaplayer
                mediaPlayer.Play(); // Play the audio with mediaplayer
            }
        }

        private void UploadAudio() // Upload the sound to the database
        {
            // Connection string to the database
            string connString = "Server=tcp:st4prj4.database.windows.net,1433;Initial Catalog=ST4PRJ4;Persist Security Info=False;User ID=azureuser;Password=Katrinebjerg123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"; //Connection string for the database

            SqlConnection connection = new SqlConnection(connString);

            connection.Open(); // Open connection to the database

            SqlCommand command = connection.CreateCommand();

            // Convert sound to byte array 
            byte[] data;

            data = File.ReadAllBytes(audioPath); //Reads the content of the audio file and converting it to byte array

            //Define sound parameter
            command.Parameters.AddWithValue("@sound", data);

            //query
            command.CommandText = "INSERT INTO Test_table(PersonID, Sound) VALUES(5, @sound)"; //Insert commandtext to database

            if (command.ExecuteNonQuery() > 0) //Check if the command get executed to the database
            {
                MessageBox.Show("Lyden blev uploadet til database");
            }
            else
            {
                MessageBox.Show("Lyden blev ikke uploadet til database");
            }
            connection.Close(); // Close the connection from the database

        }

        private void GetAudio() // Receive the sound from database
        {
            // Connection string to the database
            string connString = "Server=tcp:st4prj4.database.windows.net,1433;Initial Catalog=ST4PRJ4;Persist Security Info=False;User ID=azureuser;Password=Katrinebjerg123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"; //Connection string for the database

            SqlConnection connection = new SqlConnection(connString);

            connection.Open(); // Open connection to database

            SqlCommand command = connection.CreateCommand();

            command.CommandText = "Select Sound from Test_table WHERE PersonID=5"; // Getting the sound from PersonID 5

            dataReader = command.ExecuteReader(); // Execute the command text to the database

            while (dataReader.Read()) //Reading from the database and converting the data to byte array
            {
                output = (byte[])dataReader.GetValue(0);
            }

            connection.Close(); // Close connection

            var path = @"file.mp3"; // Specifying a file name
            File.WriteAllBytes(path, output); // Save the filename and byte array in a mp3 file

            string url = @"C:\Users\Søren Mehlsen\source\repos\soerenmehlsen\ST4PRJ4_Database_WPF\ST4PRJ4_Database_WPF\bin\Debug\file.mp3"; //file path
            mediaPlayer.Open(new Uri(url)); // Open the music file from the path

            mediaPlayer.Play(); //Play the sound

            //https://stackoverflow.com/questions/2665362/convert-byte-array-to-wav-file
        }


        public void Update(byte[] blob)
        {

        }


    }
}
