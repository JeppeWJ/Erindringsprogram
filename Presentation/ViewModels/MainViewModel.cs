using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Logic_2._0.LoginClasses;
using Presentation.Commands;

namespace Presentation.ViewModels
{
   class MainViewModel : ViewModelBase
   {
      public EditingViewModel EditingVM;
      public HomeViewModel HomeVM;
      public LoginViewModel LoginVM;
      public CreateProfileViewModel CreateProfileVM;

      private object _currentViewModel;

      public object CurrentViewModel
      {
         get { return _currentViewModel; }
         set { _currentViewModel = value; }
      }

      public MainViewModel(ILoginManager loginManager)
      {
         EditingVM = new EditingViewModel();
         HomeVM = new HomeViewModel();
         LoginVM = new LoginViewModel(loginManager);
         CreateProfileVM = new CreateProfileViewModel();

         CurrentViewModel = LoginVM;

      }
   }
}
