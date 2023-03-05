using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainModel;
using DataModel;
using System.Web.DynamicData;

namespace UserRegisterSystem
{
    public partial class FrmSignIn : System.Web.UI.Page
    {
        //Builder
        public FrmSignIn()
        {
            userData = new UserData();
        }

        //Atributes
        private UserData userData;
        private List<TextBox> controlls = new List<TextBox>();

        //Events
        protected void Page_Load(object sender, EventArgs e)
        {
            //Conditional validate.
            if (Security.isErrorSessionActive(Session["Error"]))
                Response.Redirect("FrmErrorPage.aspx", false);

            chargeControlls();
        }
        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            //if the information entry is correct, charge a user object, inserting the user to database using
            //a userData method. if the information entry isn't correct, we shoot a warning label from the Validating_TextBox Method.
            //all this it's inside on a try/Catch for drive the exceptions
            User user = new User();
            try
            {
                if (Validating_TextBox())
                {
                    user.emailProp = TxtEmail.Text;
                    user.userNameProp = TxtUserName.Text;
                    user.passwordProp = TxtPassword.Text;
                    user.RoleType = new Role();
                    user.RoleType.Id = 1;
                    userData.insertUser(user);
                    Session.Add("userActive", user);
                    Response.Redirect("FrmDashBoard.aspx", false);
                }
                
            }catch(Exception ex) { Session.Add("Error", ex.ToString()); }
        }
        protected void BtnViewPass_Click(object sender, EventArgs e)
        {
            //This event allow the user view or ocult his password, changing the property to the controll.
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
        protected void LkbtnLogIn_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmLogIn.aspx", false);
        }

        //Methods and Functions
        private void chargeControlls()
        {
            controlls.Add(TxtEmail);
            controlls.Add(TxtUserName);
            controlls.Add(TxtPassword);
        }
        private bool Validating_TextBox()
        {
            //here basically validate the information entry from the asp controlls.
            bool Result;
            Result = !userData.ExistUser(TxtEmail.Text, TxtUserName.Text);
            if (!Result) return Result;
            foreach (TextBox txt in controlls)
            {
                if (!Result) return Result;
                else if (txt.Text.Length == 0)
                {
                    Result = false;
                    LblWarning.Text = "Todos los campos son requeridos";
                }
                else if (!Helper.validate_LongText(txt.Text, 5, 30))
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
    }
}