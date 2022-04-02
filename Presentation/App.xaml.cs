using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Logic_2._0.LoginClasses;


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
   }
}
