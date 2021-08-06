using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InfoSpace;

namespace SamsonSchoolSuppliers
{
    public partial class StaffLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "";
            Label1.ForeColor = System.Drawing.Color.Gray;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            ConnectionManager connectionManager = new ConnectionManager();
            connectionManager.DbHost = "100.119.153.127";
            connectionManager.DbName = "samson_school_suppliers_db";
            connectionManager.DbUsername = "exsiyabanele";
            connectionManager.DbPassword = "@Mcobicullen1";
            connectionManager.CreateConnectionString();

            QueryManager queryManager = null;
            DataManager dataManager = null;

            string openConnResult = connectionManager.OpenNewConnection();

            if (openConnResult == "Connection Opened")
            {
                string staffID = TextBox1.Text.Trim();
                string hashedStaffPassword = "";

                queryManager = new QueryManager();
                queryManager.Connection = connectionManager.Connection;

                dataManager = new DataManager();
                hashedStaffPassword = dataManager.HashValue(TextBox2.Text.Trim());

                string result = queryManager.TwoFieldExistance("staff", "staffID", staffID, "staffPassword", hashedStaffPassword);
                if (result == "Fields Exist.")
                    Response.Redirect("#");
                else
                {
                    Label1.ForeColor = System.Drawing.Color.Red;
                    Label1.Text += "Invalid ID and/or Password.";
                }

                Label1.ForeColor = System.Drawing.Color.Red;

            }
            else
            {
                Label1.ForeColor = System.Drawing.Color.Red;
                Label1.Text += openConnResult;
            }
            if (queryManager.EManager.NumOfExceptions != 0)
            {
                Label1.ForeColor = System.Drawing.Color.Red;
                Label1.Text += queryManager.EManager.EListToString();
            }
            if (dataManager.EManager.NumOfExceptions != 0)
            {
                Label1.ForeColor = System.Drawing.Color.Red;
                Label1.Text += dataManager.EManager.EListToString();
            }
            connectionManager.CloseConnection();
            if (connectionManager.EManager.NumOfExceptions != 0)
            {
                Label1.ForeColor = System.Drawing.Color.Red;
                Label1.Text += connectionManager.EManager.EListToString();
            }

        }
    }
}