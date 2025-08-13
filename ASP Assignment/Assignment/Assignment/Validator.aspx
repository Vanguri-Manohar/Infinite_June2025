﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Validator.aspx.cs" Inherits="Assignment.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Validator</title>

    <script type="text/javascript">
        function validateZipCode(source, args) {
            var zip = args.Value;
            var regex = /^\d{5}$/;
            args.IsValid = zip.match(regex) !== null;
            if (!args.IsValid) {
                alert("Zip Code must be exactly 5 digits.");
            }
        }

        function validatePhone(source, args) {
            var phone = args.Value;
            var regex = /^\d{2}-\d{7}$|^\d{3}-\d{7}$/;

            args.IsValid = regex.test(phone);
            if (!args.IsValid) {
                alert("Phone must be in format XX-XXXXXXX or XXX-XXXXXXX.");
            }
        }


        function validateEmail(source, args) {
            var email = args.Value;
            var regex = /^[^@\s]+@[^@\s]+\.[^@\s]+$/;
            args.IsValid = email.match(regex) !== null;
            if (!args.IsValid) {
                alert("Please enter a valid email address.");
            }
        }

        function validateAddress(source, args) {
            var address = args.Value;
            args.IsValid = address.length >= 5;
            if (!args.IsValid) {
                alert("Address must be at least 5 characters long.");
            }
        }

        function validateCity(source, args) {
            var city = args.Value;
            var regex = /^[A-Za-z\s]+$/;

            if (!regex.test(city)) {
                args.IsValid = false;
                alert("City name must contain only letters.");
            } else if (city.length <= 5) {
                args.IsValid = false;
                alert("City name must be more than 5 characters.");
            } else {
                args.IsValid = true;
            }
        }


        function validateNameAndFamily(source, args) {
            var name = document.getElementById("Txtname").value.trim();
            var familyName = args.Value.trim();

            if (name === "" || familyName === "") {
                args.IsValid = false;
                alert("Name and Family Name cannot be blank.");
            } else if (name.toLowerCase() === familyName.toLowerCase()) {
                args.IsValid = false;
                alert("Name and Family Name must be different.");
            } else {
                args.IsValid = true;
            }
        }
    
        
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="Label1" runat="server" Text="Insert your Details"></asp:Label>
        <p>
            Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="Txtname" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Txtname" ErrorMessage="Name Cannot be Blank" ForeColor="Red" ValidationGroup="M">*</asp:RequiredFieldValidator>
        </p>
        <p>
            Family Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="Txtfname" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Txtfname" ErrorMessage="Family name cannot be blank" ForeColor="Red" ValidationGroup="M">*</asp:RequiredFieldValidator>
&nbsp;&nbsp;
            <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="Txtfname" Display="Dynamic" ErrorMessage="Differs from Name" ForeColor="Red" OnServerValidate="CustomValidator1_ServerValidate" ValidationGroup="M" ClientValidationFunction="validateNameAndFamily"></asp:CustomValidator>
        </p>
        <p>
            Address:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="Txtaddr" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Txtaddr" ErrorMessage="Address Required" ForeColor="Red" ValidationGroup="M">*</asp:RequiredFieldValidator>
            <asp:CustomValidator ID="CustomValidator_Adr" runat="server" ControlToValidate="Txtaddr" ErrorMessage="Address Invalid" ForeColor="Red" OnServerValidate="CustomValidator_Adr_ServerValidate" ValidationGroup="M" Display="Dynamic" ClientValidationFunction="validateAddress"></asp:CustomValidator>
        </p>
        <p>
            City:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtcity" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtcity" ErrorMessage="City Required" ForeColor="Red" ValidationGroup="M">*</asp:RequiredFieldValidator>
            <asp:CustomValidator ID="CustomValidate_City" runat="server" ControlToValidate="txtcity" ErrorMessage="CustomValidator" ForeColor="Red" OnServerValidate="CustomValidate_City_ServerValidate" ValidationGroup="M" Display="Dynamic" ClientValidationFunction="validateCity">Invalid City</asp:CustomValidator>
        </p>
        <p>
            Zip Code:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtzip" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtzip" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="M">*</asp:RequiredFieldValidator>
&nbsp;<asp:CustomValidator ID="CustomValidator_Zip" runat="server" ControlToValidate="txtzip" Display="Dynamic" ErrorMessage="Invalid ZipCode" ForeColor="Red" OnServerValidate="CustomValidator_Zip_ServerValidate" ValidationGroup="M" ClientValidationFunction="validateZipCode"></asp:CustomValidator>
        </p>
        <p>
            Phone:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="Txtphone" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="Txtphone" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="M">*</asp:RequiredFieldValidator>
            <asp:CustomValidator ID="CustomValidator_Phone" runat="server" ControlToValidate="Txtphone" Display="Dynamic" ErrorMessage="Invalid Phone" ForeColor="Red" OnServerValidate="CustomValidator_Phone_ServerValidate" ValidationGroup="M" ClientValidationFunction="validatePhone"></asp:CustomValidator>
        </p>
        <p>
            Email:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtemail" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtemail" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="M">*</asp:RequiredFieldValidator>
            <asp:CustomValidator ID="CustomValidator_email" runat="server" ControlToValidate="txtemail" ErrorMessage="Invalid Email" ForeColor="Red" OnServerValidate="CustomValidator_email_ServerValidate" ValidationGroup="M" Display="Dynamic" ClientValidationFunction="validateEmail"></asp:CustomValidator>
        </p>
        <p>
            <asp:Button ID="btncheck" runat="server" OnClick="btncheck_Click" Text="Check" ValidationGroup="M"  />
            

&nbsp;&nbsp;&nbsp;
        </p>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="M" />
        <asp:Label ID="txtmsg" runat="server"></asp:Label>
    </form>
</body>
</html>
