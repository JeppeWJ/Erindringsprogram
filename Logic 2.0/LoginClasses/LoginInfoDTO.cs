using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.LoginClasses
{
   public class LoginInfoDTO
   {
      public string Username;
      public string Password;
      public string DeviceID;

      public LoginInfoDTO(string username, string password, string deviceID)
      {
         Username = username;
         Password = password;
         DeviceID = deviceID;
      }
   }
}
