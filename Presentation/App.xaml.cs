using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using DataAccessLayer;
using LogicLayer.LoginClasses;
using LogicLayer.RelativeManagerClasses;
using Presentation.Commands;
using Presentation.ViewModels;


namespace Presentation
{
   /// <summary>
   /// Interaction logic for App.xaml
   /// </summary>
   public partial class App : Application
   {
      private readonly ILoginManager _loginManager;
      private readonly IDataAccessObserver _relativeManager;
      private readonly NavigationControl _navigationControl;

      public App()
      {
         _loginManager = new TestLoginManager();
         _navigationControl = new NavigationControl();
         _relativeManager = new TestRelativeManager();
      }
      protected override void OnStartup(StartupEventArgs e)
      {
         _navigationControl.CurrentViewModel = new LoginViewModel(_loginManager, _navigationControl, _relativeManager);

         MainWindow = new MainWindow()
         {
            DataContext = new MainViewModel(_loginManager, _navigationControl)
         };
         MainWindow.Show();

         base.OnStartup(e);
      }
   }
         
}

