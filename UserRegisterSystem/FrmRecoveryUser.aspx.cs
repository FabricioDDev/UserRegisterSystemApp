using DataModel;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace UserRegisterSystem
{
    public partial class FrmRecoveryUser : System.Web.UI.Page
    {
        //Atributes
        private static string Code = Helper.generateRandomCode();
        private static int count = 0;
        private static string Email;

        //Events
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validates
            if (Security.isErrorSessionActive(Session["Error"]))
                Response.Redirect("FrmErrorPage.aspx", false);
            //charge controlls
            if (!IsPostBack) controlls();
        }
        protected void BtnConfirm_Click(object sender, EventArgs e)
        {
            //here we implement a switch for all the case, since Search the
            //UserEmail with the Name, Send a Code to his Name, and Confirm the code.
            UserData userData = new UserData();
            emailServices emailServices = new emailServices();
            try
            {
                switch (count)
                {
                    case 0:
                        Email = userData.searchEmail(TxtForm.Text);
                        if (Email != null)
                        {
                            emailServices.createEmail(Email, "Recovery Password", "your code is :  " + Code);
                            emailServices.sendEmail();
                            count++;
                            controlls();
                        }
                        else { LblWarning.Visible = true; LblWarning.Text = "Usuario no encontrado!."; }
                        break;
                    case 1:
                        if (TxtForm.Text == Code)
                        { count++; controlls(); }
                        else { LblWarning.Visible = true; LblWarning.Text = "Codigo incorrecto, vuelva a intentarlo."; }
                        break;
                    case 2:
                        userData.RecoveryUserPass(TxtForm.Text, Email);
                        count++;
                        controlls();
                        break;
                    default:
                        break; 
                }
            }
            catch (Exception ex) { Session.Add("Error", ex.ToString()); }
        }
        protected void BtnExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmLogIn.aspx", false);
        }
        private void controlls()
        {
            //here we use only one label from the differents cases.
            TxtForm.Text = "";
            if (count == 0)
            {
                LblForm.Text = "escriba su usuario";
            }
            else if (count == 1)
            {
                LblForm.Text = "escriba el codigo enviado a:" + Email;
            }
            else if (count == 2)
            {
                LblForm.Text = "escriba su nueva contraseña";
            }
            else if (count == 3)
            {
                LblForm.Text = "Genial, su contraseña fue actualizada Correctamente!!.";
                BtnConfirm.Visible = false;
                TxtForm.Visible = false;
                LblWarning.Visible = false;
            }
        }
    }
}