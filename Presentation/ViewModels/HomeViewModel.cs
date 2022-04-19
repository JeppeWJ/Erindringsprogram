﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Logic_2._0.RelativeManagerClasses;
using Presentation.Commands;

namespace Presentation.ViewModels
{
   class HomeViewModel : ViewModelBase
   {
      private readonly ObservableCollection<RelativeViewModel> _relatives;
      public IEnumerable<RelativeViewModel> Relatives => _relatives;
      public ICommand EditProfileCommand { get; }
      public ICommand CreateProfileCommand { get; }

      private RelativeViewModel _selectedProfile;

      public RelativeViewModel SelectedProfile
      {
         get { return _selectedProfile; }
         set
         {
            _selectedProfile = value; 
            OnPropertyChanged(nameof(SelectedProfile));
         }
      }

      public HomeViewModel(NavigationControl navigationControl)
      {
         _relatives = new ObservableCollection<RelativeViewModel>();
         //_relatives.Add(new RelativeViewModel(new RelativeDTO()));
         _relatives.Add(new RelativeViewModel(new RelativeDTO("DTO")));
         _relatives.Add(new RelativeViewModel(new RelativeDTO("Mette")));

         CreateProfileCommand = new CreateCommand(navigationControl);
         EditProfileCommand = new EditCommand(navigationControl);
      }
   }
}
