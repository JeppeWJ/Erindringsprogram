using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;


namespace Presentation
{
    public class DataControl : IDataAccessObserver
    {
        public IWindow Window { get; set; }

        private byte[] Blob;
        private bool FileType;
        private uint PersonID;

        private List<PersonsDTO> PersonsList;
        private PersonsDTO EmptyPersonsDTO = new PersonsDTO(0, "", "", new byte[1] { 1 }, new byte[1] { 1 });

        public DataControl(DataAccess dataAccess)
        {
            PersonsList = new List<PersonsDTO>();

            for (uint i = 0; i < 8; i++)
            {
                EmptyPersonsDTO.PersonID = i + 1;
                PersonsList.Add(EmptyPersonsDTO);
            }

            dataAccess.Attach(this);

        }

        public void Update(byte[] blob, bool fileType, uint personID)
        {
            int length = blob.Length;
            Blob = new byte[length];
            Blob = blob;
            FileType = fileType;
            PersonID = personID;


            PersonsDTO personDto = PersonsList.Find(PersonDTO => PersonDTO.PersonID == personID);

            personDto.Image = blob;


            PersonsList.Insert(Convert.ToInt32(personID - 1), personDto);




            //var obj = PersonsList.FirstOrDefault(PersonDTO => PersonDTO.PersonID == personID);
            //if (obj != null && fileType == true)  obj.SoundFile = blob;
            //else if (obj != null && fileType == false) obj.Image = blob;

            if (fileType)
            {
                ImagesToGUI(PersonsList);
            }

        }




        public void ImagesToGUI(List<PersonsDTO> personsList)
        {
            Window.UpdateImages(personsList);
        }


    }
}