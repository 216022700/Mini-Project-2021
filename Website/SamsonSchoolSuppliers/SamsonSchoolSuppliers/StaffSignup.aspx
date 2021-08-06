<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="StaffSignup.aspx.cs" Inherits="SamsonSchoolSuppliers.StaffSignup" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<link rel="stylesheet" type="text/css" href="css/form_style.css">
    <div class="row">
		<div class="col-xs-4 col-xs-offset-4 wrapper" style="width:600px;margin-left:500px;height:800px;">
			<label class="loginLabel">
				Staff Sign up
				</label>
			<br/>
			<label style="color: #959595;font-size:15px;padding-bottom:10px;">
				Create your Samson School Supplier account
				</label>
			<div class="floating-label-group form-group" >
				<!--Staff ID TextBox and Label Starts -->
				<label style="color: #959595;font-size:12px;">StaffID</label>
				<asp:TextBox runat="server" ID="TextBox1" required="true" CssClass="inputText form-control" TextMode="SingleLine"/>
				<label style="color: #959595;font-size:12px;">
				<i>Above is your staffID. Please note it. You will be ask for it in the future.</i>
				</label>
				<!--Staff ID TextBox and Label Starts -->
			</div>
			          <div class="floating-label-group form-group">
                          <asp:Table ID="Table1" runat="server" CellPadding="10">
                              <asp:TableRow runat="server">
                                  
								  <asp:TableCell runat="server">
									  <asp:TextBox runat="server" ID="TextBox2" required="true" CssClass="inputText form-control" TextMode="SingleLine"/>
									  <label class="floating-label" style="padding-top:10px;margin-left:10px;">Name</label>
                                  </asp:TableCell><asp:TableCell runat="server">
									  <asp:TextBox runat="server" ID="TextBox3" required="true" CssClass="inputText form-control" TextMode="SingleLine"/>
									  <label class="floating-label" style="margin-left:250px;padding-top:10px;">Surname</label>
                                  </asp:TableCell>

                              </asp:TableRow>
							  <asp:TableRow runat="server">
								  <asp:TableCell runat="server">
									  <label style="color: #959595;font-size:12px;">Date Of Birth</label>
									  <asp:TextBox runat="server" ID="TextBox4" required="true" CssClass="inputText form-control" TextMode="Date"/>
								  </asp:TableCell></asp:TableRow><asp:TableRow runat="server">
								  <asp:TableCell runat="server">

									  <asp:TextBox runat="server" ID="TextBox5" required="true" CssClass="inputText form-control" TextMode="Phone"/>
									  <label class="floating-label" style="padding-top:173px;margin-left:10px;">Phone</label>

								  </asp:TableCell><asp:TableCell runat="server">

									  <asp:TextBox runat="server" ID="TextBox6" required="true" CssClass="inputText form-control" TextMode="Email"/>
									  <label class="floating-label" style="margin-left:250px;padding-top:173px;">Email</label>

								  </asp:TableCell></asp:TableRow>
							  <asp:TableRow runat="server">
								  <asp:TableCell runat="server">
									  <label style="color: #959595;font-size:12px;">Staff Type</label>
									  <asp:DropDownList ID="DropDownList1" runat="server" CssClass="inputText form-control">
										  <asp:ListItem Selected="True" Value="-Select Staff Type-">-Select Staff Type-</asp:ListItem>
										  <asp:ListItem Value="Admin">Admin</asp:ListItem>
										  <asp:ListItem Value="Manager">Manager</asp:ListItem>
										  <asp:ListItem Value="Clerk">Clerk</asp:ListItem>
									  </asp:DropDownList>

								  </asp:TableCell></asp:TableRow>
							  
							  <asp:TableRow runat="server">
								  <asp:TableCell runat="server">
									  <asp:TextBox runat="server" ID="TextBox7" required="true" CssClass="inputText form-control" TextMode="Password"/>
									  <label class="floating-label" style="padding-top:335px;margin-left:10px;">Create Password</label>
                                  </asp:TableCell><asp:TableCell runat="server">
									  <asp:TextBox runat="server" ID="TextBox8" required="true" CssClass="inputText form-control" TextMode="Password"/>
									  <label class="floating-label" style="margin-left:250px;padding-top:335px;">Confirm Password</label>
                                  </asp:TableCell>

							  </asp:TableRow></asp:Table><br>
              <asp:Button runat="server" ID="Button1" CssClass="btn btn-primary solid blank" OnClick="Button1_Click" Text="Signup"/>
				<span><asp:LinkButton runat="server" ID="LinkButton1" Text="Login" CssClass="loginLinkButton" OnClick="LinkButton1_Click"/></span>
						  <br/><br/>
				<asp:Label runat="server" ID="Label1" Text="" />
          </div>
		</div>
	</div>
    </asp:Content>