using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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
      private int _password;
      public int Password
      {
         get { return _password; }
         set
         {
            _password = value;
            OnPropertyChanged(nameof(Password));
         }
      }

   }
}
