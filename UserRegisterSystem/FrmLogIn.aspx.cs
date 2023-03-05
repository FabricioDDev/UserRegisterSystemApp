using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataModel;
using DomainModel;

namespace UserRegisterSystem
{
    public partial class FrmLogIn : System.Web.UI.Page
    {
        //Events
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validating
                if (Security.isErrorSessionActive(Session["Error"]))
                    Response.Redirect("FrmErrorPage.aspx", false);
        }

        protected void BtnGo_Click(object sender, EventArgs e)
        {
            UserData userData = new UserData();
            try
            {
                //Using a Method from UserData class fro LogIn the User.
                User user = userData.Login(TxtUserName.Text, TxtPass.Text);
                if (user != null)
                {
                    Session.Add("UserActive", user);
                    Response.Redirect("FrmDashBoard.aspx", false);
                }
                else
                { 
                    LblWarning.Visible = true;
                    LblWarning.Text = "Usuario no encontrado. Vuelva a Intentarlo"; 
                }
            }
            catch (Exception ex) { Session.Add("Error", ex.ToString()); }
        }

        protected void LkbtnSignIn_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmSignIn.aspx", false);
        }

        protected void LkbtnRecovery_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmRecoveryUser.aspx", false);
        }

       
    }
}