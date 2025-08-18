using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Electricity_Prj
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            var username = "admin";
            var password = "admin@123";
            if (txtusername.Text == username && txtpassword.Text == password)
            {
                txtlabelmsg.Text = "Validation Success";
                txtlabelmsg.ForeColor = System.Drawing.Color.Green;
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                txtlabelmsg.Text = "Validation Failed";
                txtlabelmsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}