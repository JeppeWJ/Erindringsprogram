using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Presentation.Commands;

namespace Presentation.ViewModels
{
   class EditingViewModel : ViewModelBase
   {
      public ICommand BackCommand { get; }

      public EditingViewModel(NavigationControl navigationControl)
      {
         BackCommand = new ToHomeViewCommand(navigationControl);
      }
   }
}
