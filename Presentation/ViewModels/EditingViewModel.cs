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
       private RelativeViewModel _relative;
       public string Picture { get; }

       public EditingViewModel(NavigationControl navigationControl, RelativeViewModel relative)
       {
           _relative = relative;
           Picture = _relative.PictureString;
       }
   }
}
