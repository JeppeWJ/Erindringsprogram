using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.LoginClasses
{
   public class TestLoginManager : ILoginManager
   {
      public List<LoginInfoDTO> ValidLogins { get; set; }

      public TestLoginManager()
      {
         ValidLogins = new List<LoginInfoDTO>();
         ValidLogins.Add(new LoginInfoDTO("123", "123", "123"));
      }

      public bool CheckLogin(LoginInfoDTO loginTry)
      {
         bool ok = false;
         foreach (var Login in ValidLogins)
         {
            if (Login.DeviceID == loginTry.DeviceID && Login.Username == loginTry.Username && Login.Password == loginTry.Password)
            {
               ok = true;
            }
         }

         return ok;
      }
   }
}
