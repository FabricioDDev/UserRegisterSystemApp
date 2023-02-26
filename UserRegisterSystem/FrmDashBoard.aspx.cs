using DomainModel;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
                chargeControlls();
            }
            catch (Exception ex) { Session.Add("Error", ex.ToString()); }
        }
        private void chargeControlls()
        {
            LblWelcome.Text = "Bienvenido " + userActive.userNameProp + "!!";
            LblUserName.Text = userActive.userNameProp;
            chargeImgProfile();
        }
        private void chargeImgProfile()
        {
            string Path = MapPath("~/Pictures/Profile-" + userActive.idProp.ToString() + ".jpg");
            if (File.Exists(@Path))
                ImgProfile.ImageUrl = "~/Pictures/Profile-" + userActive.idProp.ToString() + ".jpg";
            else
                ImgProfile.ImageUrl = "~/Pictures/Default.jpg";
        }
    }
}