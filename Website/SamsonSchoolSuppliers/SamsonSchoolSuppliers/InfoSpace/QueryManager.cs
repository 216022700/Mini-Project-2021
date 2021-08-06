using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Data;
using System.Net;

namespace InfoSpace
{
    public class QueryManager
    {
        private MySqlConnection connection = null;
        private MySqlDataReader reader = null;
        private ExceptionManager eManager = null;

        public QueryManager() 
        {
            eManager = new ExceptionManager();
            eManager.ClassName = "Query Manager: ";
        }
        public MySqlConnection Connection { get => connection; set => connection = value; }
        public ExceptionManager EManager { get => eManager; }

        public string[] GetColumnNames(string tableName, int numOfExpectedCols)
        {
            string[] columnNames = null;
            try
            {
                string query = "select `COLUMN_NAME` from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME='"+tableName+"'";

                MySqlCommand command = new MySqlCommand(query, connection);
                reader = command.ExecuteReader();

                DataTable table = new DataTable();
                table.Load(reader);
                if (table.Rows.Count > numOfExpectedCols)
                {
                    columnNames = new string[numOfExpectedCols];

                    for (int i = 0; i < numOfExpectedCols; i++)
                    {
                        columnNames[i] = table.Rows[i][0].ToString();
                    }
                }
                else
                {
                    columnNames = new string[table.Rows.Count];

                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        columnNames[i] = table.Rows[i][0].ToString();
                    }
                }
                reader.Close();
                command.Dispose();

            }
            catch (Exception exception)
            {
                eManager.AddException(exception);
            }
            return columnNames;
        }
    
        public string InsertQuery(string tableName,string[] columnNames, string[] rowValues)
        {
            string strMessage = "";
            string columnsQuery = "";
            string valuesQuery = "";

            for (int i = 0; i < columnNames.Length; i++)
            {

                if (i != columnNames.Length - 1)
                    columnsQuery += "`" + columnNames[i] + "`,";
                else
                    columnsQuery += "`" + columnNames[i] + "`";
            }

            for (int i = 0; i < rowValues.Length; i++)
            {
                if (i != rowValues.Length - 1)
                    valuesQuery += "'" + rowValues[i] + "',";
                else
                    valuesQuery += "'" + rowValues[i] + "'";
            }

            try
            {
                string query = "insert into "+tableName+" ("+columnsQuery+") values ("+valuesQuery+");";
                MySqlCommand command = new MySqlCommand(query, Connection);
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    strMessage = "Could Not Perform Insert";
                }
                else
                {
                    strMessage = "Insert Successful";
                }
                reader.Close();
                command.Dispose();
            }
            catch (Exception exception)
            {
                eManager.AddException(exception);
            }

            return strMessage;
        }

        public string DeleteQuery(string tableName, string columnName,string rowValue)
        {
            string strMessage = "";
            try
            {
                string query = "delete from "+tableName+" where `"+columnName+"` = '"+rowValue+"'";
                MySqlCommand command = new MySqlCommand(query, Connection);
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected != 0)
                    strMessage = "Removal Operation Successful";
                else
                    strMessage = "Could Not Complete The Removal";
                command.Dispose();
            }
            catch (Exception exception)
            {
                eManager.AddException(exception);
            }
            return strMessage;
        }

        public string UpdateQuery(string tableName, string columnIdentifier,string identifierValue,string columnToChange, string newRowValue)
        {
            MySqlTransaction transaction = null;
            string strMessage = "";
            try
            {
                 transaction = Connection.BeginTransaction();

                string query = "update "+tableName+" set "+"`"+columnToChange+"`="+"'"+newRowValue+"' where `"+columnIdentifier+"` ="+identifierValue; 
                MySqlCommand command = new MySqlCommand(query,Connection);
                command.Transaction = transaction;
                int rowsAffected = command.ExecuteNonQuery();
                transaction.Commit();
                if (rowsAffected != 0)
                    strMessage = "Update Successful";
                else
                    strMessage = "Could Not Update";
                command.Dispose();
            }
            catch (Exception exception)
            {
                transaction.Rollback();
                eManager.AddException(exception);
            }
            return strMessage;
        }

        public string CheckExistance(string tableName, string columnIdentifier, string rowValue)
        {
            string strMessage = "";
            try
            {
                string query = "select * from " + tableName + " where `" + columnIdentifier + "`='" + rowValue + "'";
                MySqlCommand command = new MySqlCommand(query, Connection);
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    strMessage = columnIdentifier.ToUpper() + " already exists in the system";
                }
                reader.Close();
                command.Dispose();
            }
            catch (Exception exception)
            {
                eManager.AddException(exception);
            }
            return strMessage;
        }

        //Can be used as a login function, columnIdentifier1 = username and columnIdentifier2 = password
        public string TwoFieldExistance(string tableName, string columnIdentifier1, string rowValue1, string columnIdentifier2, string rowValue2)
        {
            string strMessage = "";
            try
            {
                string query = "select * from " + tableName + " where `" + columnIdentifier1 + "`='" + rowValue1 + "' and `"+columnIdentifier2+"`='"+rowValue2+"'";
                MySqlCommand command = new MySqlCommand(query, Connection);
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    strMessage = "Fields Exist.";
                }
                reader.Close();
                command.Dispose();
            }
            catch (Exception exception)
            {
                eManager.AddException(exception);
            }
            return strMessage;
        }

        //The ff functions can be used in the implementation of registration where a new user is to be verified by admin
        //sends emails to all verified admins to vent a new user, toEmails[] =array of admin emails
        public string VerifyUserEmail(string newUserUsername, string newUserName, string newUserSurname,string newUserEmail,string[] toEmails)
        {
            string strMessage = "";
            string verifyLink = "https://localhost:44390/"; //add the appropriate port and webpage (URL)
            string subject = "New Registration: " +newUserEmail;
            string body = "Dear admin,\r\n\r\n" +
                "You received this email because a new user registration has been detected.\r\n\r\nNEW USER DETAILS: \r\n" +
                "Name: "+newUserName +"\r\n" +
                "Surname: "+newUserSurname+"\r\n" +
                "Username: "+newUserUsername+"\r\n" +
                "Email Address: "+newUserEmail+
                "\r\n\r\n"+
                "To verify the user, follow link, "+verifyLink+"\r\n\r\n" +
                "Kind Regards,\r\nInfoSpace Management\r\n\r\n" +
                "(Please do not reply to this email address - it is an unmonitored mailbox.)";
            try
            {
                MailMessage mailMessage = new MailMessage();
                SmtpClient smtpClient = new SmtpClient();

                mailMessage.From = new MailAddress("web-app@infospace.co.za", "InfoSpace Web Application");

                foreach (string toEmail in toEmails)
                {
                    mailMessage.To.Add(new MailAddress(toEmail));
                }
                
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                //mailMessage.IsBodyHtml = true;
                smtpClient.Host = "127.0.0.1";
                smtpClient.Port = 25;
                //smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.Credentials = new NetworkCredential("Info@infospace.co.za","");
                smtpClient.Send(mailMessage);
                strMessage = "Email Sent.";
            }
            catch(Exception exception) { eManager.AddException(exception); }
            return strMessage;
        }

        public string[] GetVerifiedAdminEmails(string tableName, string emailColumn, string verificationColumn, string verificationRowValue, string adminColumnName, string adminRowValue)
        {
            string[] emails = null;
            List<String> temp = new List<string>();
            try
            {
                string query = "select "+emailColumn+" from "+tableName+" where `"+verificationColumn+"`='"+verificationRowValue+"' and `"+adminColumnName+"`='"+adminRowValue+"'";
                MySqlCommand command = new MySqlCommand(query, Connection);
                reader = command.ExecuteReader();
                int count = 0;
                while (reader.Read())
                {
                    string strEmail = (string)reader[emailColumn];
                    temp.Add(strEmail);
                    count++;
                }
                emails = new string[count];
                emails = temp.ToArray();
                reader.Close();
                command.Dispose();
            }
            catch (Exception exception)
            {
                eManager.AddException(exception);
            }
            return emails;
        }

        public DataTable GetSpectificRegistration(string tableName, string columnIdentifier, string rowValue)
        {
            DataTable table = null;
            try 
            {
                string query = "select * from "+tableName+" where `"+columnIdentifier+"`='"+rowValue+"'";
                MySqlCommand command = new MySqlCommand(query,Connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = command;
                adapter.Fill(table);
                adapter.Dispose();
                command.Dispose();
                
            }
            catch (Exception exception) { eManager.AddException(exception); }
            return table;
        }

        public DataTable GetRegistrationByStatus(string tableName, string columnIdentifier, string rowValue,string verificationColumn, string verificationValue)
        {
            DataTable table = null;
            try
            {
                string query = "select * from " + tableName + " where `" + columnIdentifier + "`='" + rowValue + "' and `"+verificationColumn+"`='"+verificationValue+"'";
                MySqlCommand command = new MySqlCommand(query, Connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = command;
                adapter.Fill(table);
                adapter.Dispose();
                command.Dispose();

            }
            catch (Exception exception) { eManager.AddException(exception); }
            return table;
        }

        public string DeclineRegistration(string tableName, string userIdentifierColumn, string rowValue, string verificationColumn, string newVerificationValue, string reasonColoumnIdentifier, string reasonValue)
        {
            string strMessage = "";
            if (this.UpdateQuery(tableName, userIdentifierColumn, rowValue, verificationColumn, newVerificationValue) == "Update Successful")
            {
                if (this.UpdateQuery(tableName, userIdentifierColumn, rowValue, reasonColoumnIdentifier, reasonValue) == "Update Successful")
                {
                    strMessage = "New User Declined.";
                }
            }
                return strMessage;
        }

        public string AcceptRegistration(string tableName, string userIdentifierColumn, string rowValue, string verificationColumn, string newVerificationValue)
        {
            string strMessage = "";
            if (this.UpdateQuery(tableName,userIdentifierColumn,rowValue,verificationColumn,newVerificationValue) == "Update Successful")
            {
                strMessage = "New User Accepted.";
            }
            return strMessage;
        }

    }
}
