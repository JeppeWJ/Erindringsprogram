using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Logic_2._0.LoginClasses;
using Presentation.ViewModels;

namespace Presentation.Commands
{
   class LoginCommand : CommandBase
   {
      private readonly ILoginManager _loginManager;
      private readonly LoginViewModel _loginViewModel;

      public LoginCommand(LoginViewModel loginViewModel, ILoginManager loginManager)
      {
         _loginManager = loginManager;
         _loginViewModel = loginViewModel;
      }
      public override void Execute(object parameter)
      {
         if (_loginManager.CheckLogin(new LoginInfoDTO(_loginViewModel.Username, _loginViewModel.Password, "123")))
         {
            MessageBox.Show("Login lykkedes", "Login forsøg");
         }
         else
         {
            MessageBox.Show("Login lykkedes ikke", "Login forsøg");
         }
      }
   }
}
