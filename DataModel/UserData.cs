using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using DB;

namespace DataModel
{
    public class UserData
    {
        public UserData() { data = new DataAccess(); }
        private DataAccess data;
    }
}
