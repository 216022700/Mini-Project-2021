using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InfoSpace;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Text;

namespace InfoSpace
{
    public class DataManager : Page
    {
        private List<TextBox> textBoxes = null;
        private ExceptionManager eManager = null;


        public DataManager()
        {
            textBoxes = new List<TextBox>();
            eManager = new ExceptionManager();
            eManager.ClassName = "Data Manager: ";
        }

        public ExceptionManager EManager { get => eManager; }

        public void AddTextBox(TextBox textBox)
        {
            textBoxes.Add(textBox);
        }

        public string[] GetTextBoxValues()
        {
            string[] values = null;
            if (textBoxes.Count != 0)
            {
                values = new string[textBoxes.Count];
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = textBoxes.ElementAt(i).Text;
                }
            }
            return values;
        }

        public string HashValue(string value)
        {
            string hash = "";
            using (MD5 md5Hash = MD5.Create())
            {
                hash = GetMd5Hash(value, md5Hash);
            }
            return hash;
        }

        private string GetMd5Hash(string value, MD5 md5Hash)
        {
            string md5Value = "";
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(value));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            md5Value = sBuilder.ToString();
            return md5Value;
        }

        public string GenerateStaffID()
        {
            string strID = "ST";
            Random random = new Random();
            int runs = 8;
            while (runs > 0)
            {
                strID += (random.Next(0,10)).ToString();
                runs--;
            }
            return strID;
        }

        public bool isNumber(string input)
        {
            bool blnCheck = false;
            int intInput = 0;
            try { intInput = int.Parse(input); blnCheck = true; }
            catch (Exception) {}
            return blnCheck;
        }
    }

}