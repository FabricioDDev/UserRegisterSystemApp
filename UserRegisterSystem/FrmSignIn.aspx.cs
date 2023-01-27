using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainModel;
using DataModel;

namespace UserRegisterSystem
{
    public partial class FrmSignIn : System.Web.UI.Page
    {
        public FrmSignIn()
        {
            userData = new UserData();
        }
        private UserData userData;
        protected void Page_Load(object sender, EventArgs e)
        {
            //validaciones: todos los campos son requeridos. datos incorrectos. aceptar politicas. ya existe usuario. 
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            User user = new User();
            try
            {
                user.emailProp = TxtEmail.Text;
                user.userNameProp = TxtUserName.Text;
                user.passwordProp = TxtPassword.Text;
                user.ImageProfile = "Vacio";
                user.RoleType = new Role();
                user.RoleType.Id = 1;
                userData.insertUser(user);
            }catch(Exception ex) { Session.Add("Error", ex.ToString()); }
        }
    }
}