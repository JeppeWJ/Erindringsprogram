using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataAccessLayer;

namespace Presentation
{
    public interface IWindow
    {
        void UpdateImages(List<PersonsDTO> personsList);
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : IWindow 
   {
      public MainWindow()
      {
         InitializeComponent();
         dataAccessObserver = new DataControl(DataAccess);
         //dataAccessObserver.Window = this;
        }






                                                            //todo Implement
        DataControl dataAccessObserver { get; set; }
      DataAccess DataAccess = new DataAccess();
      private MediaPlayer mediaPlayer = new MediaPlayer();


      public void UpdateImages(List<PersonsDTO> personsList)
      {
          int i = 0;
          foreach (var VARIABLE in personsList)
          {
              i++;
              Stream streamObj = new MemoryStream(VARIABLE.Image);
              BitmapImage bitObj = new BitmapImage();
              bitObj.BeginInit();
              bitObj.CacheOption = BitmapCacheOption.OnLoad;
              bitObj.StreamSource = streamObj;
              bitObj.EndInit();


              //if (i == 1)
              //{
              //    Image1.Source = bitObj;
              //}
              //else if (i == 2)
              //{
              //    Image2.Source = bitObj;
              //}
              //else if (i == 3)
              //{
              //    Image3.Source = bitObj;
              //}
              //else if (i == 4)
              //{
              //    Image4.Source = bitObj;
              //}
              //else if (i == 5)
              //{
              //    Image5.Source = bitObj;
              //}
              //else if (i == 6)
              //{
              //    Image6.Source = bitObj;
              //}
              //else if (i == 7)
              //{
              //    Image7.Source = bitObj;
              //}
              //else if (i == 8)
              //{
              //    Image8.Source = bitObj;
              //}
              //else if (i >= 9)
              //{
              //    break;
              //}

          }

      }


        //private void uploadButton_Click(object sender, RoutedEventArgs e)
        //{
        //    bool fileType;
        //    if (SoundRB.IsChecked == true)
        //    {
        //        fileType = true;
        //    }
        //    else
        //    {
        //        fileType = false;
        //    }

        //    uint personID = Convert.ToUInt32(PersonIDTextBox.Text);

        //    DataAccess.UploadImageOrAudioToDB(fileType, personID);
        //}

        //private void downLoadButton_Click(object sender, RoutedEventArgs e)
        //{
        //    bool fileType;
        //    if (SoundRB.IsChecked == true)
        //    {
        //        fileType = true;
        //    }
        //    else
        //    {
        //        fileType = false;
        //    }

        //    uint personID = Convert.ToUInt32(PersonIDTextBox.Text);

        //    DataAccess.GetImageOrAudioFromDB(fileType, personID);
        //}



    }
}
