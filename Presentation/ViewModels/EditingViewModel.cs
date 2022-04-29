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


        public EditingViewModel(NavigationControl navigationControl, RelativeViewModel relative)
        {
            BackCommand = new ToHomeViewCommand(navigationControl);
            //--------Må gerne ændres------
            //PictureButtonClickCommand = new RelayCommand(PictureButtonClick);
            //AudioButtonClickCommand = new RelayCommand(AudioButtonClick);
            //DeleteProfileButtonClickCommand = new RelayCommand(DeleteProfileButtonClick);
            //SaveButtonClickCommand = new RelayCommand(SaveButtonClick);
            
            RelativeName = _relative.Name;
            RelativeID = _relative.ID;

        }
    }
}
