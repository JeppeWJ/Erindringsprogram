using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Logic_2._0.LoginClasses;
using Presentation.Commands;

namespace Presentation.ViewModels
{
   class MainViewModel : ViewModelBase
   {
      private readonly NavigationControl _navigationControl;


      public object CurrentViewModel => _navigationControl.CurrentViewModel;


      public MainViewModel(ILoginManager loginManager, NavigationControl navigationControl)
      {
         _navigationControl = navigationControl;

         _navigationControl.CurrentViewModelChanged += OnCurrentViewModelChanged;
      }

      private void OnCurrentViewModelChanged()
      {
         OnPropertyChanged(nameof(CurrentViewModel));
      }
   }
}
