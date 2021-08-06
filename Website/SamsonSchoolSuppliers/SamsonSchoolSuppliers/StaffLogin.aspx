<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master"  CodeBehind="StaffLogin.aspx.cs" Inherits="SamsonSchoolSuppliers.StaffLogin" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<link rel="stylesheet" type="text/css" href="css/form_style.css">
    <div class="row">
		<div class="col-xs-4 col-xs-offset-4 wrapper">
			<label class="loginLabel">
				Staff Login
				</label>
			<br/>
			<label style="color: #959595;font-size:15px;padding-bottom:30px;">
				Use your Samson School Suppliers account
				</label>
			<div class="floating-label-group form-group" >
				<asp:TextBox runat="server" ID="TextBox1" required="true" CssClass="inputText form-control" TextMode="SingleLine"/>
			  <label class="floating-label">Staff ID</label>
			</div>
		
			<div class="floating-label-group form-group">
				<asp:TextBox runat="server" ID="TextBox2" required="true" CssClass="inputText form-control" TextMode="Password" autocomplete="off"/>
			<label class="floating-label">Password</label>
			</div>
			          <div><br>
              <asp:Button runat="server" ID="Button1" CssClass="btn btn-primary solid blank" OnClick="Button1_Click" Text="Login"/>
				<span><asp:LinkButton runat="server" ID="LinkButton1" Text="Create account" CssClass="loginLinkButton"/></span>
						  <br/>
				<asp:Label runat="server" ID="Label1" Text="" />
          </div>
		</div>
	</div>
    </asp:Content>
