using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class User
    {
        private int Id;
        private string Email;
        private string UserName;
        private string Password;

        public int idProp
        {
            get { return Id; }
            set { Id = value; }
        }
        public string emailProp
        {
            get { return Email; }
            set { Email = value; }
        }
        public string userNameProp
        {
            get { return UserName; }
            set { UserName = value; }
        }
        public string passwordProp
        {
            get { return Password; }
            set { Password = value; }
        }
        public Role RoleType { get; set; }
    }
}
