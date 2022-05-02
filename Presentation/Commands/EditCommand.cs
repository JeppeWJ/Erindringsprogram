using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataAccessLayer;
using Presentation.ViewModels;

namespace Presentation.Commands
{
   public class EditCommand : CommandBase
   {
      private readonly NavigationControl _navigationControl;
      private readonly IDataAccessObserver _relativeManager;

      public EditCommand(NavigationControl navigationControl, IDataAccessObserver relativeManager)
      {
         _navigationControl = navigationControl;
         _relativeManager = relativeManager;
      }
      public override void Execute(object parameter)
      {
         if (parameter != null)
         {
            RelativeViewModel relative = (RelativeViewModel)parameter;
            _navigationControl.CurrentViewModel = new EditingViewModel(_navigationControl, relative, _relativeManager);
         }
         else
         {
            MessageBox.Show("Der er ikke valgt en profil");
         }
         
      }
   }
}
