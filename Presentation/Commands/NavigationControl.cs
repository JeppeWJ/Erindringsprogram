using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation.ViewModels;

namespace Presentation.Commands
{
   public class NavigationControl
   {
      private ViewModelBase _currentViewModel;

      public ViewModelBase CurrentViewModel
      {
         get { return _currentViewModel; }
         set
         {
            _currentViewModel = value;
            OnCurrentViewModelChanged();
         }
      }

      private void OnCurrentViewModelChanged()
      {
         CurrentViewModelChanged?.Invoke();
      }

      public event Action CurrentViewModelChanged;

   }
}
