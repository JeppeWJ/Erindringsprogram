using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DTOs;

namespace LogicLayer.RelativeManagerClasses
{
   public class TestRelativeManager : IDataAccessObserver
   {
      public List<RelativeDTO> Relatives { get; set; }
      public TestRelativeManager()
      {
         Relatives = new List<RelativeDTO>();
         Relatives.Add(new RelativeDTO(){FirstName = "Hans", LastName = "Petersen", Relation = "Søn"});
         Relatives.Add(new RelativeDTO() { FirstName = "Hanne", LastName = "Petersen", Relation = "Datter" });

      }
      public void Update(RelativeDTO update, bool fileType)
      {

      }
      public void UpdateFile(bool fileType, uint id)
      {

      }

      public void CreateProfile(RelativeDTO newProfile)
      {

      }

      public void DeleteProfile(uint id)
      {

      }

      public void EditProfile(RelativeDTO profile)
      {

      }

   }
}
