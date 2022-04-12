using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation.ViewModels;

namespace Presentation.Commands
{
   public class EditCommand : CommandBase
   {
      private readonly NavigationControl _navigationControl;

      public EditCommand(NavigationControl navigationControl)
      {
         _navigationControl = navigationControl;
      }
      public override void Execute(object parameter)
      {
         _navigationControl.CurrentViewModel = new EditingViewModel(_navigationControl);
      }
   }
}
