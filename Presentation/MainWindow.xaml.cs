using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
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
