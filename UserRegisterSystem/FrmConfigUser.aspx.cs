using DomainModel;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataModel;

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
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            UserData userData = new UserData();
            userActive.emailProp= TxtEmail.Text;
            userActive.userNameProp = TxtUserName.Text;
            userActive.passwordProp = TxtPassword.Text;
            userData.updateUser(userActive);

            string Rute = MapPath("~/Pictures/Profile-" + userActive.idProp.ToString() + ".jpg");
            if (File.Exists(@Rute))
            {
                File.Delete(@Rute);
                TxtImage.PostedFile.SaveAs(Rute);
            }
            else TxtImage.PostedFile.SaveAs(Rute);

            chargeControlls();
        }

        protected void BtnGoToDashBoard_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmDashBoard.aspx");
        }
    }
}