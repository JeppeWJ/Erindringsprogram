using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Presentation.ViewModels;

namespace Presentation.Commands
{
   class ToHomeViewCommand : CommandBase
   {
      private readonly NavigationControl _navigationControl;

      public ToHomeViewCommand(NavigationControl navigationControl)
      {
         _navigationControl = navigationControl;
      }
      public override void Execute(object parameter)
      {
         _navigationControl.CurrentViewModel = new HomeViewModel(_navigationControl);
      }
   }
}
