using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DTOs;

namespace Presentation.ViewModels
{
   public class RelativeViewModel : ViewModelBase
   {
      private readonly RelativeDTO _relative;

      public string Name { get; }

      public RelativeViewModel(RelativeDTO relative)
      {
         _relative = relative;
         Name = _relative.FirstName + " " + _relative.LastName;

      }
   }
}
