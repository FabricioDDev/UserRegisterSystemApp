using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using DB;
using System.ComponentModel.Design;

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
                data.Query("select U.Id as UserId, Email, UserName, Password, R.Id as RoleId, RoleName from UserTable U, RoleTable R where R.Id = U.IdRole ");
                data.Read();
                while (data.readerProp.Read())
                {
                    User Aux = new User();
                    Aux.idProp = (int)data.readerProp["UserId"];
                    Aux.emailProp = (string)data.readerProp["Email"];
                    Aux.userNameProp = (string)data.readerProp["UserName"];
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
                data.Query("insert into UserTable values (@UEmail, @UName, @UPassword, @UIdRole)");
                data.Parameters("@UEmail", user.emailProp);
                data.Parameters("@UName", user.userNameProp);
                data.Parameters("@UPassword", user.passwordProp);
                data.Parameters("@UIdRole", user.RoleType.Id);
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
                data.Parameters("@IdRole", user.RoleType.Id);
                data.Execute();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally { data.Close(); }
        }

        public void RecoveryUserPass(string newPass, string Email)
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

        public User Login(string userName, string userPass)
        {
            try
            {
                data.SP("LogIn");
                data.Parameters("@UserName", userName);
                data.Parameters("@Pass", userPass);
                data.Read();
                if (data.readerProp.Read())
                {
                    User user = new User();
                    user.userNameProp = userName;
                    user.passwordProp = userPass;
                    user.idProp = (int)data.readerProp["UserId"];
                    user.emailProp = (string)data.readerProp["Email"];
                    user.RoleType = new Role();
                    user.RoleType.Id = (int)data.readerProp["RoleId"];
                    user.RoleType.RoleName = (string)data.readerProp["RoleName"];
                    return user;
                }
                return null;
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
                    aux = (int)data.readerProp["Exist"];
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

        public string searchEmail(string user)
        {
            string email = "";
            try
            {
                data.Query("select Email from UserTable where UserName = @user");
                data.Parameters("@user", user);
                data.Read();
                if (data.readerProp.Read())
                {
                    email = (string)data.readerProp["Email"];
                }
                return email;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { data.Close(); }
        }
    }
}
