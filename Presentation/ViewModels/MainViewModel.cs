using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ViewModels
{
   class MainViewModel : ViewModelBase
   {
      public EditingViewModel EditingVM;
      public HomeViewModel HomeVM;
      private object _currentView;

      public object CurrentView
      {
         get { return _currentView; }
         set { _currentView = value; }
      }

      public MainViewModel()
      {
         EditingVM = new EditingViewModel();
         HomeVM = new HomeViewModel();
         CurrentView = EditingVM;
      }
   }
}
