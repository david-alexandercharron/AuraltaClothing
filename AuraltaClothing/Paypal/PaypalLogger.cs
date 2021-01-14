using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace AuraltaClothing.Paypal
{
    public class PaypalLogger
    {

        public static string LogDirectoryPath = Environment.CurrentDirectory;

        public static void Log(string messages)
        {

            try
            {
                StreamWriter strw = new StreamWriter(LogDirectoryPath + "\\PaypalError.log", true);
                strw.WriteLine("{0}--->{1}", DateTime.Now.ToString("MM/dd/yyyy HH::mm::ss"), messages);
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}