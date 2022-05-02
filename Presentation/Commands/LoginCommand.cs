using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataAccessLayer;
using LogicLayer.LoginClasses;
using Presentation.ViewModels;

namespace Presentation.Commands
{
   class LoginCommand : CommandBase
   {
      private readonly ILoginManager _loginManager;
      private readonly IDataAccessObserver _relativeManager;
      private readonly LoginViewModel _loginViewModel;
      private readonly NavigationControl _navigationControl;

      public LoginCommand(LoginViewModel loginViewModel, ILoginManager loginManager, NavigationControl navigationControl, IDataAccessObserver relativeManager)
      {
         _loginManager = loginManager;
         _loginViewModel = loginViewModel;
         _navigationControl = navigationControl;
         _relativeManager = relativeManager;

      }
      public override void Execute(object parameter)
      {
         if (_loginManager.CheckLogin(new LoginInfoDTO(_loginViewModel.Username, _loginViewModel.Password, "123")))
         {
            _navigationControl.CurrentViewModel = new HomeViewModel(_navigationControl, _relativeManager);
         }
         else
         {
            MessageBox.Show("Login lykkedes ikke", "Login forsøg");
         }
      }
   }
}
