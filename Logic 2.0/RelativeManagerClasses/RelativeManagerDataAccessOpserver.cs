using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DTOs;

namespace LogicLayer.RelativeManagerClasses
{
    class RelativeManagerDataAccessOpserver : IDataAccessObserver
    {
        public List<RelativeDTO> Relatives { get; set; }


        public void Update(byte[] blob, bool fileType, uint personID)
        {
            throw new NotImplementedException();
        }


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
    }
}
