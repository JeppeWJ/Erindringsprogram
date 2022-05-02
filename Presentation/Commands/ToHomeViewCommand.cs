using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DataAccessLayer;
using Presentation.ViewModels;

namespace Presentation.Commands
{
   class ToHomeViewCommand : CommandBase
   {
      private readonly NavigationControl _navigationControl;
      private readonly IDataAccessObserver _relativeManager;

      public ToHomeViewCommand(NavigationControl navigationControl, IDataAccessObserver relativeManager)
      {
         _navigationControl = navigationControl;
         _relativeManager = relativeManager;
      }
      public override void Execute(object parameter)
      {
         _navigationControl.CurrentViewModel = new HomeViewModel(_navigationControl, _relativeManager);
      }
   }
}
