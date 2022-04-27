using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Presentation.ViewModels;

namespace Presentation.Commands
{
   public class CreateCommand : CommandBase
   {
      private readonly NavigationControl _navigationControl;
      private readonly IDataAccessObserver _relativeManager;

      public CreateCommand(NavigationControl navigationControl, IDataAccessObserver relativeManager)
      {
         _navigationControl = navigationControl;
         _relativeManager = relativeManager;
      }
      public override void Execute(object parameter)
      {
         _navigationControl.CurrentViewModel = new CreateProfileViewModel(_navigationControl, _relativeManager);
      }
   }
}
