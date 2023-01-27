using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainModel;

namespace UserRegisterSystem
{
    public partial class FrmErrorPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { 
            if (!Security.isErrorSessionActive(Session["Error"])){
                Response.Redirect("FrmLogIn.aspx", false);
            }
        }

        protected void LkbLogIn_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmLogIn.aspx", false);
        }
    }
}