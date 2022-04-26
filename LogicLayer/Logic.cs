using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess_2._0;
using DataAccessLayer;
using DTOs;

namespace LogicLayer
{
    public class Logic
    {
        private IDataAccessObserver _data;
        private int _personID;

        public Logic()
        {
            _data = new Database();
            _personID = new int();
        }

        public RelativeDTO Getinfo()
        {
            RelativeDTO info = _data.PersonInfo();
            return info;
        }

        public int EditProfile(RelativeDTO person)
        {
            _personID = _data.UpdateProfile(person);
            return _personID;
        }
    }
}
