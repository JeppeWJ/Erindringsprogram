using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Logic_2._0.LoginClasses;
using Logic_2._0.RelativeManagerClasses;
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
      private readonly NavigationControl _navigationControl;

      public App()
      {
         _loginManager = new TestLoginManager();
         _navigationControl = new NavigationControl();
      }
      protected override void OnStartup(StartupEventArgs e)
      {
         _navigationControl.CurrentViewModel = new LoginViewModel(_loginManager, _navigationControl);

         MainWindow = new MainWindow()
         {
            DataContext = new MainViewModel(_loginManager, _navigationControl)
         };
         MainWindow.Show();

         base.OnStartup(e);
      }
   }
         
}

