using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Input;
using DataAccessLayer;
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


      public EditingViewModel(NavigationControl navigationControl, RelativeViewModel relative, IDataAccessObserver relativeManager)
      {
         BackCommand = new ToHomeViewCommand(navigationControl, relativeManager);
         _relative = relative;
         RelativeName = _relative.Name;
      }
   }
}
