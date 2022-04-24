using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_2._0.RelativeManagerClasses
{
   public class RelativeDTO
   {
       public string FirstName { get; set; }
       public string LastName { get; set; }
       public int PersonID { get; set; }
       public DateTime DateOfBirth { get; set; }
       public string Relation { get; set; }
       public Byte[] Picture { get; set; }
       public Byte[] Audio { get; set; }

       public RelativeDTO() { }
       
    }
}
