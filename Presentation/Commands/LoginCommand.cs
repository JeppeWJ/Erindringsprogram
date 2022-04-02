using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Logic_2._0.LoginClasses;

namespace Presentation.Commands
{
   class LoginCommand : CommandBase
   {
      private ILoginManager _loginManager;

      public LoginCommand(ILoginManager loginManager)
      {
         _loginManager = loginManager;
      }
      public override void Execute(object parameter)
      {
         
      }
   }
}
