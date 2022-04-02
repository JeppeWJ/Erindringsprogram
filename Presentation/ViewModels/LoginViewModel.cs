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
   class LoginViewModel : ViewModelBase
   {
      public ICommand LoginPressed { get; }

      private string _username;

      public string Username
      {
         get
         {
            return _username;
         }
         set
         {
            _username = value;
            OnPropertyChanged(nameof(Username));
         }
      }
      private string _password;
      public string Password
      {
         get { return _password; }
         set
         {
            _password = value;
            OnPropertyChanged(nameof(Password));
         }
      }

      public LoginViewModel(ILoginManager loginManager)
      {
         LoginPressed = new LoginCommand(this, loginManager);
      }
   }
}
