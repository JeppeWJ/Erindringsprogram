using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Logic_2._0.LoginClasses;
using Presentation.ViewModels;


namespace Presentation
{
   /// <summary>
   /// Interaction logic for App.xaml
   /// </summary>
   public partial class App : Application
   {
      private readonly ILoginManager _loginManager;

      public App()
      {
         _loginManager = new TestLoginManager();
      }
      protected override void OnStartup(StartupEventArgs e)
      {
         MainWindow = new MainWindow()
         {
            DataContext = new MainViewModel(_loginManager)
         };
         MainWindow.Show();

         base.OnStartup(e);
      }
   }
         
}

