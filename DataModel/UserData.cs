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
                data.Parameters("@IdRole", user.RoleType.Id);
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

        public User Login(User user)
        {
            try
            {
                data.SP("LoginUser");
                data.Read();
                if (data.readerProp.Read())
                {
                    user.idProp = (int)data.readerProp["UserId"];
                    user.emailProp = (string)data.readerProp["Email"];
                    user.ImageProfile = (string)data.readerProp["ImagenPerfil"];
                    user.RoleType = new Role();
                    user.RoleType.Id = (int)data.readerProp["RoleId"];
                    user.RoleType.RoleName = (string)data.readerProp["RoleName"];
                }
                return user;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally { data.Close(); }
        }

        public bool ExistUser(string Email, string UserName)
        {
            int aux = 0;
            try
            {
                data.SP("ExistUser");
                data.Parameters("@Email", Email);
                data.Parameters("@UserName", UserName);
                data.Read();
                if (data.readerProp.Read())
                {
                    aux = (int)data.readerProp["Match"];
                }
                if (aux != 0) return true;
                else return false;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally { data.Close(); }
        }
    }
}
