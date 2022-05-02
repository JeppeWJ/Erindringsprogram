using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DataAccessLayer;
using DTOs;
using Presentation.Commands;

namespace Presentation.ViewModels
{
   class HomeViewModel : ViewModelBase
   {
      private readonly IDataAccessObserver _relativeManager;
      private readonly ObservableCollection<RelativeViewModel> _relatives;
      public IEnumerable<RelativeViewModel> Relatives => _relatives;
      public ICommand EditProfileCommand { get; }
      public ICommand CreateProfileCommand { get; }

      private RelativeViewModel _selectedProfile;

      public RelativeViewModel SelectedProfile
      {
         get { return _selectedProfile; }
         set
         {
            _selectedProfile = value;
            OnPropertyChanged(nameof(SelectedProfile));
         }
      }
      public HomeViewModel(NavigationControl navigationControl, IDataAccessObserver relativeManager)
      {
         _relativeManager = relativeManager;
         _relatives = new ObservableCollection<RelativeViewModel>();

         CreateProfileCommand = new CreateCommand(navigationControl, _relativeManager);
         EditProfileCommand = new EditCommand(navigationControl, _relativeManager);

         UpdateRelatives();
      }

      private void UpdateRelatives()
      {
         foreach (RelativeDTO relative in _relativeManager.Relatives)
         {
            RelativeViewModel newRelative = new RelativeViewModel(relative);

            _relatives.Add(newRelative);
         }
      }
   }
}
