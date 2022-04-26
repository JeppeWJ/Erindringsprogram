using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DTOs;
using Microsoft.Win32;

namespace DataAccess_2._0
{
    public class Database : IDataAccessObserver
    {
        private IDataAccessObserver _dataAccessObserverImplementation;
        private RelativeDTO info;

        public Database()
        {
                info = new RelativeDTO();
        }

        public RelativeDTO PersonInfo()
        {
            return info;
        }

        public void Update(byte[] blob, bool fileType, uint personID)
        {
            _dataAccessObserverImplementation.Update(blob, fileType, personID);
        }

        public List<RelativeDTO> Relatives
        {
            get => _dataAccessObserverImplementation.Relatives;
            set => _dataAccessObserverImplementation.Relatives = value;
        }

        public void UpdateFile(bool fileType, uint id)
        {
            _dataAccessObserverImplementation.UpdateFile(fileType, id);
        }

        public void CreateProfile(RelativeDTO newProfile)
        {
            _dataAccessObserverImplementation.CreateProfile(newProfile);
        }

        public void DeleteProfile(uint id)
        {
            _dataAccessObserverImplementation.DeleteProfile(id);
        }

        public int UpdateProfile(RelativeDTO person)
        {
            // Connection string to the database
            string connString = "Server=tcp:st4prj4.database.windows.net,1433;Initial Catalog=ST4PRJ4;Persist Security Info=False;User ID=azureuser;Password=Katrinebjerg123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"; //Connection string for the database

            SqlConnection connection = new SqlConnection(connString);

            connection.Open(); //Open the connection to the database

            SqlCommand command = connection.CreateCommand();

            // Convert image to byte array
            byte[] soundData;
            byte[] imageData;

            imageData = File.ReadAllBytes(person.Picture); //Reads the content of the audio file and converting it to byte array
            soundData = File.ReadAllBytes(person.Audio); //Reads the content of the audio file and converting it to byte array

            command.Parameters.AddWithValue("@sound", soundData);
            command.Parameters.AddWithValue("@image", imageData);
            //query
            command.CommandText = $"UPDATE Test_table SET Image = @image WHERE PersonID = {person.PersonID}"; //Insert commandtext to database
            command.CommandText = $"UPDATE Test_table SET SOUND = @sound WHERE PersonID = {person.PersonID}";

            person.PersonID = Convert.ToInt32(command.ExecuteScalar());
            //if (command.ExecuteNonQuery() > 0) //Check if the command get executed to the database
            //{
            //    MessageBox.Show("Billedet og lyden blev uploadet til database");
            //}
            //else
            //{
            //    MessageBox.Show("Billedet og lyden blev ikke uploadet til database");
            //}

            connection.Close(); // Close connection to the database

            return person.PersonID;
        }
    }
}
