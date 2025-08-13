﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CustomValidate_City_ServerValidate(object source, ServerValidateEventArgs args)
        {

            if (args.Value == "")
            {
                args.IsValid = false;
            }
            else if (args.Value.Length < 2)
            {
                args.IsValid = false;
            }

            else
            {
                args.IsValid = true;
            }
        }

        protected void CustomValidator_Adr_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value == "")
            {
                args.IsValid = false;
            }
            else if (args.Value.Length < 2)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }

        }

        

        protected void CustomValidator_Zip_ServerValidate(object source, ServerValidateEventArgs args)
        {

            string zipCode = args.Value;


            if (System.Text.RegularExpressions.Regex.IsMatch(zipCode, @"^\d{5}$"))
            {
                args.IsValid = true;
            }
            else
            {

                args.IsValid = false;

            }
        }

        protected void CustomValidator_Phone_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string phoneNumber = args.Value;
            if (System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, @"^\d{2}-\d{7}$|^\d{3}-\d{7}$"))
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }


        protected void CustomValidator_email_ServerValidate(object source, ServerValidateEventArgs args)
        {

            string email = args.Value;

            if (System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }

        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string name = Txtname.Text.Trim();
            string familyName = args.Value.Trim();

            if (name != "" && familyName != "" && name.ToLower() != familyName.ToLower())
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }

        }
        protected void btncheck_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                txtmsg.Text = "Validation Success";
                txtmsg.ForeColor = System.Drawing.Color.Green;
            }

            else
            {
                txtmsg.Text = "Validation failed. Please check your input.";
                txtmsg.ForeColor = System.Drawing.Color.Red;
            }
        }

       
    }
}