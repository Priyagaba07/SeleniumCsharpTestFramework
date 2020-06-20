using AmazonTestFramework.Config;
using AmazonTestFramework.Helpers;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using TechTalk.SpecFlow;

namespace AmazonTestFramework.Base
{
    public class TestInitializeHook :Steps
    {

        public readonly DriverContext _driverConfig;

        public TestInitializeHook(DriverContext driverConfig)
        {
            _driverConfig = driverConfig;
        }
        /*   public readonly BrowserType Browser;

           public TestInitializeHook(BrowserType browser)
           {
               Browser = browser;
           } */
        public  void InitializeSetting()

        {
            
            //Set all the seetings for Framework
            ConfigReader.SetFrameworkSettings();

            //Set Log
            LogHelpers.CreateLogFile();

            //Open browsers
            OpenBrowser();
        }

      /*  public virtual void NavigateSite()
        {
            DriverContext.Driver.Navigate().GoToUrl(Settings.AUT);
            DriverContext.Driver.Manage().Window.Maximize();
         
        }*/


            private  void OpenBrowser()
            {

            string browserName = "BrowserName";

            
          
            if (ExcelHelpers.GetCellDataList(browserName, "FireFox")[0].Equals("Yes"))
            {
                LogHelpers.Write("Launching the Firefox Driver");
                _driverConfig.Driver = new FirefoxDriver();

            }
            else if (ExcelHelpers.GetCellDataList(browserName, "Chrome")[0].Equals("Yes"))
            {
                LogHelpers.Write("Launching the Chrome Driver");
                _driverConfig.Driver = new ChromeDriver();

            }
            else if (ExcelHelpers.GetCellDataList(browserName, "IE")[0].Equals("Yes"))
            {
                LogHelpers.Write("Launching the IE Driver");
                _driverConfig.Driver = new InternetExplorerDriver();

            }
            else
            {

                _driverConfig.Driver = new ChromeDriver();
                LogHelpers.Write("Selecting chrome driver as no driver is specified in data provided");
            }
          
            }
        }
    }

