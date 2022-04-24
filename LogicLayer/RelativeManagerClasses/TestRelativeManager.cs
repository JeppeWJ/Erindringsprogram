using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DTOs;

namespace LogicLayer.RelativeManagerClasses
{
   public class TestRelativeManager 
    {


        public List<RelativeDTO> Relatives { get; set; }

        //private DataAccess _dataAccess;

      public TestRelativeManager()
      {
          Relatives = new List<RelativeDTO>();
          //Relatives.Add(new RelativeDTO(_dataAccess.GetPersonName()));
      }

   }
}
