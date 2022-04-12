using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Presentation.Commands;

namespace Presentation.ViewModels
{
   class CreateProfileViewModel : ViewModelBase
   {
      private readonly NavigationControl _navigationControl;
      public ICommand BackCommand { get; }

      public CreateProfileViewModel(NavigationControl navigationControl)
      {
         _navigationControl = navigationControl;
         BackCommand = new ToHomeViewCommand(navigationControl);
      }
   }
}
