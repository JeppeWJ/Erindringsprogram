using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    public class PersonsDTO
    {
        public uint PersonID;
        public string FirstName;
        public string LastName;
        public byte[] Image;
        public byte[] SoundFile;

        public PersonsDTO(uint personID, string firstName, string lastName, byte[] image, byte[] soundFile)
        {
            PersonID = personID;
            FirstName = firstName;
            LastName = lastName;
            Image = image;
            SoundFile = soundFile;
        }

    }
}
