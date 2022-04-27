using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using LogicLayer;
using LogicLayer.RelativeManagerClasses;
using Microsoft.Win32;
using Presentation.Commands;


namespace Presentation.ViewModels
{
    class EditingViewModel : ViewModelBase
    {
        public ICommand BackCommand { get; }
        public ICommand PictureButtonClickCommand { get; set; }
        public ICommand AudioButtonClickCommand { get; set; }
        public ICommand DeleteProfileButtonClickCommand { get; set; }
        public ICommand SaveButtonClickCommand { get; set; }
        private RelativeViewModel _relative;
        public string RelativeName { get; }
        public int RelativeID { get; }
        private BitmapImage _DisplayImagePath;
        private MediaPlayer mediaPlayer = new MediaPlayer();
        private Logic _logic;
        private Logic _info = new Logic();
        private int personID;
        

        public EditingViewModel(NavigationControl navigationControl, RelativeViewModel relative)
        {
            BackCommand = new ToHomeViewCommand(navigationControl);
            PictureButtonClickCommand = new RelayCommand(PictureButtonClick);
            AudioButtonClickCommand = new RelayCommand(AudioButtonClick);
            DeleteProfileButtonClickCommand = new RelayCommand(DeleteProfileButtonClick);
            SaveButtonClickCommand = new RelayCommand(SaveButtonClick);
            _relative = relative;
            _logic = new Logic();
            personID = new int();

            RelativeName = _relative.Name;
            RelativeID = _relative.ID;

            //******************Getting image from the database for the person*************************************
            //string connString = "Server=tcp:st4prj4.database.windows.net,1433;Initial Catalog=ST4PRJ4;Persist Security Info=False;User ID=azureuser;Password=Katrinebjerg123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"; //Connection string for the database

            //SqlConnection connection = new SqlConnection(connString);

            //connection.Open();

            //SqlCommand command = connection.CreateCommand();

            //command.CommandText = $"Select Image from Test_table WHERE PersonID = {RelativeID}";

            //dataReader = command.ExecuteReader();


            //while (dataReader.Read())
            //{
            //    output = (byte[])dataReader.GetValue(0);
            //}

            //connection.Close();


            //Stream streamObj = new MemoryStream(output);
            //BitmapImage bitObj = new BitmapImage();

            //bitObj.BeginInit();
            //bitObj.StreamSource = streamObj;
            //bitObj.EndInit();

            //_DisplayImagePath = bitObj;
            //*******************************************************
        }

        private void SaveButtonClick(object obj)
        {
            _info.Getinfo().PersonID = (uint) RelativeID; //Adding personID to our relative DTO
            personID = _logic.EditProfile(_info.Getinfo());
        }


        private void DeleteProfileButtonClick(object obj)
        {
            throw new NotImplementedException();
        }

        private void AudioButtonClick(object obj)
        {
            OpenFileDialog openFile = new OpenFileDialog(); //create object for Filedialog

            openFile.FileName = "";

            openFile.Filter = "MP3 files|*.mp3"; // Filter only supported mp3 files

            if (openFile.ShowDialog() == true) //Opens a dialog from the computer and if OK is clicked, the code in the if-statement will be executed
            {
                _info.Getinfo().Audio = openFile.FileName; // Set the filename path for the audio
                mediaPlayer.Open(new Uri(_info.Getinfo().Audio)); //Open the audio from the filepath with the mediaplayer
                                                                  //mediaPlayer.Play(); // Play the audio with mediaplayer
            }
        }

        public BitmapImage DisplayImagePath
        {
            get { return _DisplayImagePath; }
            set
            {
                _DisplayImagePath = value;
                OnPropertyChanged(nameof(DisplayImagePath)); ;
            }
        }

        private void PictureButtonClick(object obj)
        {
            _logic.SelectImageOrAudioFromPC(true, Convert.ToUInt32(RelativeID));

            RelativeManagerDataAccessOpserver relativeManager = new RelativeManagerDataAccessOpserver();
            var person =
            relativeManager.PersonInfo(Convert.ToUInt32(RelativeID));







            //OpenFileDialog openFile = new OpenFileDialog(); //create object for Filedialog

            //openFile.FileName = "";

            //openFile.Filter = "Supported Images|*.jpg;*.jpeg.*png"; // Filter only supported pictures

            //if (openFile.ShowDialog() == true) //Opens a dialog from the computer and if OK is clicked, the code in the if-statement will be executed
            //{
            //    _info.Getinfo().Picture = openFile.FileName; // Set the filename path for the image
            //    DisplayImagePath = new BitmapImage(new Uri(openFile.FileName, UriKind.Relative)); //Adding and showing the image to the image control in the WPF

            //}
        }
    }
}
