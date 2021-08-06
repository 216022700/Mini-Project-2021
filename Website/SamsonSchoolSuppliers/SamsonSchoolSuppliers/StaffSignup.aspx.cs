using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InfoSpace;

namespace SamsonSchoolSuppliers
{
    public partial class StaffSignup : System.Web.UI.Page
    {
        private Color myGray = System.Drawing.ColorTranslator.FromHtml("#959595");
        private Color myRed = System.Drawing.Color.Red;

        private DataManager dataManager = null;
        private QueryManager queryManager = null;
        private ConnectionManager connectionManager = null;
        private string staffID = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.ForeColor = myRed;
            connectionManager = new ConnectionManager();
            dataManager = new DataManager();
            queryManager = new QueryManager();

            TextBox1.ReadOnly = true;
            staffID = dataManager.GenerateStaffID();
            TextBox1.Text = staffID;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //Response.Redirect("StaffLogin.aspx");
            Label1.Text = dataManager.HashValue(TextBox7.Text.Trim())+ "-"+ TextBox4.Text;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            connectionManager.DbHost = "100.125.197.109";
            connectionManager.DbName = "samson_school_suppliers_db";
            connectionManager.DbUsername = "exsiyabanele";
            connectionManager.DbPassword = "@Mcobicullen1";
            connectionManager.CreateConnectionString();

            string openConnResult = connectionManager.OpenNewConnection();
            queryManager.Connection = connectionManager.Connection;
            

            string staffName = TextBox2.Text.Trim();
            string staffSurname = TextBox3.Text.Trim();
            string staffDOB = TextBox4.Text.Trim();
            string staffPhone = TextBox5.Text.Trim();
            string staffType = DropDownList1.SelectedValue;
            string staffPassword = dataManager.HashValue(TextBox7.Text.Trim());
            string staffAccessStatus = "Pending";
            string staffEmail = TextBox6.Text.Trim();

            string emailExist = queryManager.CheckExistance("staff","staffEmail",staffEmail);
            string idExist = queryManager.CheckExistance("staff", "staffID", staffID);


            if (idExist != "")
            {
                Label1.Text = "Generated ID exists in system.\nPlease wait while generating a new one.";
                System.Threading.Thread.Sleep(1000 * 2);
                Page_Load(sender, e);
            }
            else if (dataManager.isNumber(staffPhone) == false) { Label1.Text = "Phone is a 10-digit number that starts with 0."; }
            else if (emailExist != "") { Label1.Text = emailExist; }
            else if (staffType == "-Select Staff Type-") { Label1.Text = "Please select staff type."; }
            else if (staffPassword != dataManager.HashValue(TextBox8.Text.Trim())) { Label1.Text = "Passwords do not match."; }
            else
            {
                if (openConnResult == "Connection Opened")
                {
                    string[] fieldValues = { staffID, staffName, staffSurname, staffDOB, staffEmail, staffPhone, staffPassword, staffType, staffAccessStatus };
                    string[] fields = queryManager.GetColumnNames("staff", 9);
                    string insertResponse = queryManager.InsertQuery("staff", fields, fieldValues);

                    if (insertResponse == "Insert Successful")
                    {
                        string[] verifiedEmails = queryManager.GetVerifiedAdminEmails("staff", "staffEmail", "staffAccessStatus", "Verified", "staffType", "Admin");
                        string sendVerificationEmail = queryManager.VerifyUserEmail(staffID,staffName,staffSurname,staffEmail,verifiedEmails);
                    }
                    else
                    { 
                        
                    }
                }
                else
                {
                    Label1.Text = openConnResult;
                }
            }

        }
    }
}