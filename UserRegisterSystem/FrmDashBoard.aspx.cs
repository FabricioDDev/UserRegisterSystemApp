using DomainModel;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.IO;
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
                string Rute = @"C:\Users\miaqu\OneDrive\Escritorio\Fabri\Proyects\Server\UserRegisterSystem\Pictures\Profile-" + userActive.idProp + ".jpg";
                
                if(File.Exists(@MapPath("~/Pictures/Profile-"+ userActive.idProp.ToString()+".jpg")))
                  ImgProfile.ImageUrl = "~/Pictures/Profile-" + userActive.idProp.ToString() + ".jpg";
                else
                ImgProfile.ImageUrl = "~/Pictures/Default.jpg";
                

            }
            catch (Exception ex) { Session.Add("Error", ex.ToString()); }
        }
    }
}