using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_2._0.RelativeManagerClasses
{
   public class TestRelativeManager : IRelativeManager
   {
      public List<RelativeDTO> Relatives { get; set; }


      public TestRelativeManager()
      {
         Relatives = new List<RelativeDTO>();
      }
   }
}
