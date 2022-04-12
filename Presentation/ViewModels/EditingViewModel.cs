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
      private RelativeViewModel _relative;
      public string RelativeName { get; }
      public string Picture { get; }

      public EditingViewModel(NavigationControl navigationControl, RelativeViewModel relative)
      {
         BackCommand = new ToHomeViewCommand(navigationControl);
         _relative = relative;
         RelativeName = _relative.Name;
      }
   }
}
