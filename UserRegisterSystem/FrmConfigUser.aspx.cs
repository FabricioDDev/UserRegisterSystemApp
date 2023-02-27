using DomainModel;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserRegisterSystem
{
    public partial class FrmConfigUser : System.Web.UI.Page
    {
        private User userActive;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Security.isErrorSessionActive(Session["Error"]))
                Response.Redirect("FrmErrorPage.aspx", false);
            if (!Security.activeSession(Session["userActive"]))
                Response.Redirect("FrmErrorPage.aspx", false);
            userActive = (User)Session["userActive"];
            if(!IsPostBack)
                chargeControlls();
        }
        public void chargeControlls()
        {
            TxtEmail.Text = userActive.emailProp;
            TxtUserName.Text= userActive.userNameProp;
            TxtPassword.Text = userActive.passwordProp;
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