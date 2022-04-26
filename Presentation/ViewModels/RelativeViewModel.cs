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
      public string Name => _relative.FirstName;
      public int ID => _relative.PersonID;
      //public string PictureString => _relative.PictureString;
      //public Array[] AudioFile => _relative.AudioFile;

      public RelativeViewModel(RelativeDTO relative)
      {
         _relative = relative;
      }
   }
}
