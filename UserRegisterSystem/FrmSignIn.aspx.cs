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
        private List<TextBox> controlls = new List<TextBox>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Security.isErrorSessionActive(Session["Error"]))
                Response.Redirect("FrmErrorPage.aspx", false);
            chargeControlls();
        }
        private void chargeControlls()
        {
            controlls.Add(TxtEmail);
            controlls.Add(TxtUserName);
            controlls.Add(TxtPassword);
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            User user = new User();
            try
            {
                if (Validating_TextBox())
                {
                    user.emailProp = TxtEmail.Text;
                    user.userNameProp = TxtUserName.Text;
                    user.passwordProp = TxtPassword.Text;
                    user.ImageProfile = "sasasa";
                    user.RoleType = new Role();
                    user.RoleType.Id = 1;
                    userData.insertUser(user);
                }
                
            }catch(Exception ex) { Session.Add("Error", ex.ToString()); }
        }
        private bool Validating_TextBox()
        {
            bool Result;
            Result = !userData.ExistUser(TxtEmail.Text, TxtUserName.Text);
            if (!Result) return Result;
            foreach (TextBox txt in controlls)
            {
                if (!Result) return Result;
                else if(txt.Text.Length == 0)
                {
                    Result = false;
                    LblWarning.Text = "Todos los campos son requeridos";
                }
                else if(!Helper.validate_LongText(txt.Text, 5, 20))
                {
                    Result = false;
                    LblWarning.Text = "Cantidad de caracteres incorrectos";
                    txt.Text = "Incorrecto";
                }   
                else if (!CkbRead.Checked)
                {
                    Result = false;
                    LblWarning.Text = "Debes aceptar los terminos y politicas de la empresa.";
                }
            }
            return Result;
        }

        protected void BtnViewPass_Click(object sender, EventArgs e)
        {
            if(TxtPassword.TextMode == TextBoxMode.Password)
            {
                BtnViewPass.Text = "View Pass";
                TxtPassword.TextMode = TextBoxMode.SingleLine;
            }
            else if (TxtPassword.TextMode == TextBoxMode.SingleLine)
            {
                BtnViewPass.Text = "Ocult Pass";
                TxtPassword.TextMode = TextBoxMode.Password;
            }

        }
    }
}