
using AmazonTestFramework.Config;
using AmazonTestFramework.Helpers;
using System.Drawing.Imaging;
using System.Reflection;
using NPOI.SS.Util;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

using System;
using System.IO;
using System.Text;

namespace AmazonTestFramework.Extensions
{
    public static class WebElementExtensions
    {


        public static void SelectDropDownList(this IWebElement element, string value)
        {
            SelectElement dd1 = new SelectElement(element);
            dd1.SelectByText(value);
        }

        public static void AssertElementPresent(this IWebElement element)
        {
            if (!IsElementPresent(element))
            {
                throw new Exception(string.Format("Element Not Present exception"));
            }
        }

        public static bool IsElementPresent(this IWebElement element)
        {
            try
            {
                bool elementDisplayed = element.Displayed;
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public static string GetElementText(this IWebElement element)
        {
            return element.Text;
        }

        /* public  static void WaitUntilFound( this IWebElement element, int time, RemoteWebDriver Driver)
         {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(time));
             try
             {
                 if (element != null)
                 {
                     wait.Until(Driver1 => element.Displayed);
                 }
                 else
                 {
                     LogHelpers.Write("Element Not Foud");
                 }



             }
             catch (Exception e)
             {
                 LogHelpers.Write("Element not found or null " + e);
             }
         }*/

        /** take screenshot for Failed Test Cases */
        public static string CaptureFailedScreenshot(this RemoteWebDriver Driver, string stepName)
        {

            try
            {
                StringBuilder TimeAndDate = new StringBuilder(DateTime.Now.ToString());
                TimeAndDate.Replace("/", "_");
                TimeAndDate.Replace(":", "_");

                var curDir = AppDomain.CurrentDomain.BaseDirectory.ToString();
                curDir = Path.GetFullPath(curDir + "../../..");
                string strFileName = curDir + Settings.ScreenshotFailPath;


                SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd HHmmss");
                string path = strFileName + TimeAndDate + "." + stepName + ".png";
                Screenshot ss = ((ITakesScreenshot)Driver).GetScreenshot();
                ss.SaveAsFile(path, ScreenshotImageFormat.Png);

                return path;

            }
            catch (Exception e)
            {
                LogHelpers.Write(e.ToString());
                return "";
            }

        }

        /** take screenshot for Pass Test Cases */
        public static string CapturePassScreenshot(this RemoteWebDriver Driver , string stepName)
        {
            try
            {
                StringBuilder TimeAndDate = new StringBuilder(DateTime.Now.ToString());
                TimeAndDate.Replace("/", "_");
                TimeAndDate.Replace(":", "_");

                var curDir = AppDomain.CurrentDomain.BaseDirectory.ToString();
                curDir = Path.GetFullPath(curDir + "../../..");
                string strFileName = curDir + Settings.ScreenshotPassPath;


                SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd HHmmss");
                string path = strFileName + TimeAndDate + "." +stepName + ".png";
                Screenshot ss = ((ITakesScreenshot)Driver).GetScreenshot();
                ss.SaveAsFile(path, ScreenshotImageFormat.Png);
                Console.WriteLine(path);
                return path;



            }
            catch (Exception e)
            {
                LogHelpers.Write(e.ToString());
                return "";
            }

        }
    }
}
