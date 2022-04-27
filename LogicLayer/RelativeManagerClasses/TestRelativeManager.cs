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
       public void Update(RelativeDTO update, bool fileType)
       {
          throw new NotImplementedException();
       }

       public List<RelativeDTO> Relatives { get; set; }
       public void UpdateFile(bool fileType, uint id)
       {
          throw new NotImplementedException();
       }

       public void CreateProfile(RelativeDTO newProfile)
       {
          throw new NotImplementedException();
       }

       public void DeleteProfile(uint id)
       {
          throw new NotImplementedException();
       }

       public void EditProfile(RelativeDTO profile)
       {
          throw new NotImplementedException();
       }

       //private DataAccess _dataAccess;

      public TestRelativeManager()
      {
          Relatives = new List<RelativeDTO>();
          //Relatives.Add(new RelativeDTO(_dataAccess.GetPersonName()));
      }

   }
}
