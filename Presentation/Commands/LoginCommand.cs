using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Logic_2._0.LoginClasses;
using Logic_2._0.RelativeManagerClasses;
using Presentation.ViewModels;

namespace Presentation.Commands
{
   class LoginCommand : CommandBase
   {
      private readonly ILoginManager _loginManager;
      private readonly LoginViewModel _loginViewModel;
      private readonly NavigationControl _navigationControl;

      public LoginCommand(LoginViewModel loginViewModel, ILoginManager loginManager, NavigationControl navigationControl)
      {
         _loginManager = loginManager;
         _loginViewModel = loginViewModel;
         _navigationControl = navigationControl;
         
      }
      public override void Execute(object parameter)
      {
         if (_loginManager.CheckLogin(new LoginInfoDTO(_loginViewModel.Username, _loginViewModel.Password, "123")))
         {
            _navigationControl.CurrentViewModel = new HomeViewModel();
         }
         else
         {
            MessageBox.Show("Login lykkedes ikke", "Login forsøg");
         }
      }
   }
}
