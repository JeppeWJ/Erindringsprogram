using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Presentation.ViewModels;

namespace Presentation.Commands
{
   public class CreateCommand : CommandBase
   {
      private readonly NavigationControl _navigationControl;

      public CreateCommand(NavigationControl navigationControl)
      {
         _navigationControl = navigationControl;
      }
      public override void Execute(object parameter)
      {
         _navigationControl.CurrentViewModel = new CreateProfileViewModel();
      }
   }
}
