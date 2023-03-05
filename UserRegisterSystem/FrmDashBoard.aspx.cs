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
        //atributes
        private User userActive;

        //events
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //validates
                if (Security.isErrorSessionActive(Session["Error"]))
                    Response.Redirect("FrmErrorPage.aspx", false);
                if (!Security.activeSession(Session["userActive"]))
                    Response.Redirect("FrmErrorPage.aspx", false);

                //charge user and charge controlls
                userActive = (User)Session["userActive"];
                chargeControlls();
            }
            catch (Exception ex) { Session.Add("Error", ex.ToString()); }
        }
        private void chargeControlls()
        {
            //charge controlls information
            LblWelcome.Text = "Bienvenido " + userActive.userNameProp + "!!";
            LblUserName.Text = userActive.userNameProp;
            chargeImgProfile();
        }
        private void chargeImgProfile()
        {
            //charge image profile and validate
            string Path = MapPath("~/Pictures/Profile-" + userActive.idProp.ToString() + ".jpg");
            if (File.Exists(@Path))
                ImgProfile.ImageUrl = "~/Pictures/Profile-" + userActive.idProp.ToString() + ".jpg";
            else
                ImgProfile.ImageUrl = "~/Pictures/Default.jpg";
        }

        protected void BtnSignOut_Click(object sender, EventArgs e)
        {
            //delete session and redirect logIn
            Session.Clear();
            Response.Redirect("FrmLogIn.aspx", false);
        }
    }
}