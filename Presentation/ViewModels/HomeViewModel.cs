using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DTOs;
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

       private string connString = "Server=tcp:st4prj4.database.windows.net,1433;Initial Catalog=ST4PRJ4;Persist Security Info=False;User ID=azureuser;Password=Katrinebjerg123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
       public HomeViewModel(NavigationControl navigationControl)
       {
           DataSet ds = new DataSet();
           using (SqlConnection conn = new SqlConnection(connString))
           {
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = new SqlCommand("SELECT * FROM Test_table", conn);
                dataAdapter.Fill(ds);
           }

           DataTable dt = new DataTable();
           dt = ds.Tables[0];

           _relatives = new ObservableCollection<RelativeViewModel>();
           for (int i = 0; i < dt.Rows.Count; i++)
           {
                DataRow dataRow = dt.NewRow();
                dataRow = dt.Rows[i];
                RelativeDTO dto = new RelativeDTO();
                dto.FirstName = dataRow["FirstName"].ToString();
                dto.PersonID = (int)dataRow["PersonID"];
                _relatives.Add(new RelativeViewModel(dto));
           }
            // https://www.youtube.com/watch?v=DF_I628kNvk

           CreateProfileCommand = new CreateCommand(navigationControl);
           EditProfileCommand = new EditCommand(navigationControl);
      }
   }
}
