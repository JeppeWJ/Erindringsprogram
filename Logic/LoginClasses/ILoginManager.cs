using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.LoginClasses
{
   public interface ILoginManager
   {
      List<LoginInfoDTO> ValidLogins { get; set; }

      bool CheckLogin(LoginInfoDTO loginTry);
   }
}
