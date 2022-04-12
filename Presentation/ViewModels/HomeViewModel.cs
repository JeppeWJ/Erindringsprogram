using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Logic_2._0.RelativeManagerClasses;
using Presentation.Commands;

namespace Presentation.ViewModels
{
   class HomeViewModel : ViewModelBase
   {
      private readonly ObservableCollection<RelativeViewModel> _relatives;
      public IEnumerable<RelativeViewModel> Relatives => _relatives;
      public ICommand EditProfileCommand { get; }
      public ICommand CreateProfileCommand { get; }

      private string _selectedProfile;

      public string SelectedProfile
      {
         get { return _selectedProfile; }
         set
         {
            _selectedProfile = value; 
            OnPropertyChanged(nameof(SelectedProfile));
         }
      }

      public HomeViewModel(NavigationControl navigationControl)
      {
         _relatives = new ObservableCollection<RelativeViewModel>();
         _relatives.Add(new RelativeViewModel(new RelativeDTO(){Name = "Hans"}));
         _relatives.Add(new RelativeViewModel(new RelativeDTO() { Name = "Lotte" }));
         _relatives.Add(new RelativeViewModel(new RelativeDTO() { Name = "Birgit" }));

         CreateProfileCommand = new CreateCommand(navigationControl);
         EditProfileCommand = new EditCommand(navigationControl);
      }
   }
}
