using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.XPath;

namespace WebXRMPages
{
   public class Config
    {
        public string username;
        public string password;
        public string dealerid ;

        public Config()
        {
            string filename = AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\WebXRMPages\Config.xml";
            XPathDocument xpathdoc = new XPathDocument(filename);
            XPathNavigator navigator = xpathdoc.CreateNavigator();
            
            username = navigator.SelectSingleNode("Login/user").Value.ToString();
            password = navigator.SelectSingleNode("Login/password").Value.ToString();
            dealerid = navigator.SelectSingleNode("Login/dealerid").Value.ToString();
        }

       
    }
}
