using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;


namespace DataAccessLayer
{
    public interface IDataAccessObserver
    {

        void Update(byte[] blob, bool fileType, uint personID);
        List<RelativeDTO> Relatives { get; set; }
        void UpdateFile(bool fileType, uint id);
        void CreateProfile(RelativeDTO newProfile);
        void DeleteProfile(uint id);
        void EditProfile(RelativeDTO profile);
    }
}
