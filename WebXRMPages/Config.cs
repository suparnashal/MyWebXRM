using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.XPath;
using NUnit.Framework;


namespace WebXRMPages
{
   public class Config
    {
        public string username;
        public string password;
        public string dealerid ;

        public Config()
        {
            //Getting the username, password, dealerid from xml
            string filename = AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\WebXRMPages\Config.xml";
            XPathDocument xpathdoc = new XPathDocument(filename);
            XPathNavigator navigator = xpathdoc.CreateNavigator();

            try
            {
                username = navigator.SelectSingleNode("Login/user").Value.ToString();
                password = navigator.SelectSingleNode("Login/password").Value.ToString();
                dealerid = navigator.SelectSingleNode("Login/dealerid").Value.ToString();
            }
            catch (Exception e)
            {
                Assert.Fail($"Error reading from file {filename}{e}");
            }
        }

       
    }
}
