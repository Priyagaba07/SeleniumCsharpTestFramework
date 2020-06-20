using System;
using System.IO;
using System.Xml.XPath;

namespace AmazonTestFramework.Config
{
    public class ConfigReader
    { 
        public static void SetFrameworkSettings()
    {
            XPathItem aut;
            XPathItem logPath;
            XPathItem browser;
            XPathItem screenshotPassPath;
            XPathItem screenshotFailPath;
            var curDir = AppDomain.CurrentDomain.BaseDirectory.ToString();
            curDir = Path.GetFullPath(curDir + "../../..");
        

            string strFileName = curDir + "/AmazonTestFramework/Config/GlobalConfig.xml";
            FileStream stream = new FileStream(strFileName, FileMode.Open);
            XPathDocument document = new XPathDocument(stream);

            XPathNavigator navigator = document.CreateNavigator();

            aut = navigator.SelectSingleNode("AmazonTestFramework/RunSettings/AUT");
            logPath = navigator.SelectSingleNode("AmazonTestFramework/RunSettings/LogPath");
            browser = navigator.SelectSingleNode("AmazonTestFramework/RunSettings/Browser");
            screenshotPassPath = navigator.SelectSingleNode("AmazonTestFramework/RunSettings/ScreenshotPassPath");
            screenshotFailPath = navigator.SelectSingleNode("AmazonTestFramework/RunSettings/ScreenshotFailPath");

            Settings.AUT = aut.ToString();
            Settings.LogPath = logPath.ToString();
            Settings.Browser = browser.ToString();
            Settings.ScreenshotPassPath = screenshotPassPath.ToString();
            Settings.ScreenshotFailPath = screenshotFailPath.ToString();
        }
    
    }
}
