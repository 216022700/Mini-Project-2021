using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace InfoSpace
{
    public class ConnectionManager
    {
        private MySqlConnection connection = null;
        private string connectionString = "";
        private string dbName = "";
        private string dbHost = "";
        private string dbUsername = "";
        private string dbPassword = "";

        private ExceptionManager eManager = null;


        public ConnectionManager() { eManager = new ExceptionManager(); eManager.ClassName = "Connection Manager: "; }

        public ConnectionManager(string connectionString)
        {
            eManager = new ExceptionManager();
            eManager.ClassName = "Connection Manager: ";
            this.connectionString = connectionString;
        }

        public ConnectionManager(string dbHost, string dbUsername, string dbPassword, string dbName)
        {
            eManager = new ExceptionManager();
            this.dbName = dbName;
            this.dbHost = dbHost;
            this.dbUsername = dbUsername;
            this.dbPassword = dbPassword;
            eManager.ClassName = "Connection Manager: ";
        }

        public string ConnectionString { get => connectionString; set => connectionString = value; }
        public string DbName { get => dbName; set => dbName = value; }
        public string DbHost { get => dbHost; set => dbHost = value; }
        public string DbUsername { get => dbUsername; set => dbUsername = value; }
        public string DbPassword { get => dbPassword; set => dbPassword = value; }
        public MySqlConnection Connection { get => connection; }
        public ExceptionManager EManager { get => eManager;}

        public void CreateConnectionString()
        {
            if (connectionString.Length == 0)
            {
                connectionString = @"server = "+DbHost+"; user id = "+DbUsername+"; pwd = "+DbPassword+"; database = "+DbName+";";
            }
        }

        public string OpenNewConnection()
        {
            string strMessage = "";
            connection = new MySqlConnection(connectionString);
            try
            {
                Connection.Open();
                strMessage = "Connection Opened";
            }
            catch (Exception exception) 
            { 
                EManager.AddException(exception);
            }
            return strMessage;
        }

        public string CloseConnection()
        {
            string strMessage = "";
            try
            {
                Connection.Close();
                strMessage = "Connection Successfully Closed";
            }
            catch (Exception exception)
            {
                EManager.AddException(exception);
            }
            return strMessage;
        }
    }

}