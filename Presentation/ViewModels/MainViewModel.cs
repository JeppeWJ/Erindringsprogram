using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Presentation.Commands;

namespace Presentation.ViewModels
{
   class MainViewModel : ViewModelBase
   {
      public EditingViewModel EditingVM;
      public HomeViewModel HomeVM;
      public LoginViewModel LoginVM;
      public CreateProfileViewModel CreateProfileVM;

      public LoginCommand LoginPressed { get; }

      private object _currentView;

      public object CurrentView
      {
         get { return _currentView; }
         set { _currentView = value; }
      }

      public MainViewModel()
      {

         EditingVM = new EditingViewModel();
         HomeVM = new HomeViewModel();
         LoginVM = new LoginViewModel();
         CreateProfileVM = new CreateProfileViewModel();

         CurrentView = LoginVM;
      }
   }
}
