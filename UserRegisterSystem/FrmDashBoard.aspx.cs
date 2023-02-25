using DomainModel;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserRegisterSystem
{
    public partial class FrmDashBoard : System.Web.UI.Page
    {
        public FrmDashBoard()
        {
            
        }
        private User userActive;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Security.isErrorSessionActive(Session["Error"]))
                    Response.Redirect("FrmErrorPage.aspx", false);
                if (!Security.activeSession(Session["userActive"]))
                    Response.Redirect("FrmErrorPage.aspx", false);

                userActive = (User)Session["userActive"];
                

                LblWelcome.Text = "Bienvenido " + userActive.userNameProp + "!!";
                LblUserName.Text = userActive.userNameProp;
                ImgProfile.ImageUrl = "~/Images/Profile/Profile-" + userActive.idProp.ToString() + ".jpg";
            }
            catch (Exception ex) { Session.Add("Error", ex.ToString()); }
        }
    }
}