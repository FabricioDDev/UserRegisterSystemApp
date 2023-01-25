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

        public List<User> listSP()
        {
            List<User> list = new List<User>();
            try
            {
                data.SP("UserList");
                data.Read();
                while (data.readerProp.Read())
                {
                    User Aux = new User();
                    Aux.idProp = (int)data.readerProp["UserId"];
                    Aux.emailProp = (string)data.readerProp["Email"];
                    Aux.userNameProp = (string)data.readerProp["UserName"];
                    Aux.ImageProfile = (string)data.readerProp["ImagenPerfil"];
                    Aux.passwordProp = (string)data.readerProp["Password"];
                    Aux.RoleType = new Role();
                    Aux.RoleType.Id = (int)data.readerProp["RoleId"];
                    Aux.RoleType.RoleName = (string)data.readerProp["RoleName"];

                    list.Add(Aux);
                }
                return list;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally { data.Close(); }
        }

        public void insertUser(User user)
        {
            try
            {
                data.SP("InsertUser");
                data.Parameters("@Email", user.emailProp);
                data.Parameters("@UserName", user.userNameProp);
                data.Parameters("@Password", user.passwordProp);
                data.Parameters("@ImagenPerfil", user.ImageProfile);
                data.Parameters("@IdRol", user.RoleType.Id);
                data.Execute();
            }
            catch(Exception ex) { throw ex; }
            finally { data.Close(); }
        }

        public void updateUser(User user)
        {
            try
            {
                data.SP("UpdateUser");
                data.Parameters("@Email", user.emailProp);
                data.Parameters("@UserName", user.userNameProp);
                data.Parameters("@Password", user.passwordProp);
                data.Parameters("@ImagenPerfil", user.ImageProfile);
                data.Parameters("@IdRole", user.RoleType.Id);
                data.Execute();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally { data.Close(); }
        }

        public void recoveryUserPass(string newPass, string Email)
        {
            try
            {
                data.SP("RecoveryUserPass");
                data.Parameters("@Password", newPass);
                data.Parameters("@Email", Email);
                data.Execute();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { data.Close(); }
        }
    }
}
