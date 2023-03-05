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
        //atributes
        private User userActive;
        private List<TextBox> controlls = new List<TextBox>();
        //events
        protected void Page_Load(object sender, EventArgs e)
        {
            //validates
                if (Security.isErrorSessionActive(Session["Error"]))
                    Response.Redirect("FrmErrorPage.aspx", false);
                if (!Security.activeSession(Session["userActive"]))
                    Response.Redirect("FrmErrorPage.aspx", false);

                userActive = (User)Session["userActive"];
                if (!IsPostBack)
                    chargeControlls();
                    controllsToList();
        }
        private void controllsToList()
        {
            controlls.Add(TxtEmail);
            controlls.Add(TxtUserName);
            controlls.Add(TxtPassword);
        }
        public void chargeControlls()
        {
            //Charge the controlls with Information
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
            //validate the controlls entry, and update the user
            try
            {
                UserData userData = new UserData();
                if (Validating_TextBox())
                {
                    userActive.emailProp = TxtEmail.Text;
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
                else { LblWarning.Visible = true; }

                
            }
            catch (Exception ex) { Session.Add("Error", ex.ToString()); }
        }

        private bool Validating_TextBox()
        {
            bool Result = true;
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
            }
            return Result;
        }


        protected void BtnGoToDashBoard_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmDashBoard.aspx");
        }
    }
}