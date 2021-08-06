using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfoSpace
{
    public class ExceptionManager
    {
        private List<Exception> exceptionList = null;
        private int numOfExceptions = 0;
        private string className = "";

        public ExceptionManager() { exceptionList = new List<Exception>(); }

        public string ClassName { get => className; set => className = value; }
        public int NumOfExceptions { get => numOfExceptions;}

        public void AddException(Exception exception)
        {
            exceptionList.Add(exception);
            numOfExceptions++;
        }

        public string EListToString()
        {
            string str = ClassName;
            if (exceptionList.Count != 0)
            {
                foreach (Exception exception in exceptionList)
                {
                    str += "< "+exception.Message+" >\n";
                }
            }
            return str;
        }

    }
}