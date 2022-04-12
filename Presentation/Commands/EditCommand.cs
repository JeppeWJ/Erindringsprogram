using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
         if (parameter != null)
         {
            RelativeViewModel relative = (RelativeViewModel)parameter;
            _navigationControl.CurrentViewModel = new EditingViewModel(_navigationControl, relative);
         }
         else
         {
            MessageBox.Show("Der er ikke valgt en profil");
         }
         
      }
   }
}
