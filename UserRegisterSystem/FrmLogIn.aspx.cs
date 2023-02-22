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
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Security.isErrorSessionActive(Session["Error"]))
                    Response.Redirect("FrmErrorPage.aspx", false);
            }
            catch (Exception ex) { Session.Add("Error", ex.ToString()); }
        }

        protected void BtnGo_Click(object sender, EventArgs e)
        {
            UserData userData = new UserData();
            try
            {
                User user = userData.Login(TxtUserName.Text, TxtPass.Text);
                if (user != null)
                {
                    Session.Add("UserActive", user);
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