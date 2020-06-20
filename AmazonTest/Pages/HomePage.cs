using AmazonTestFramework.Base;
using AmazonTestFramework.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTest.Pages
{
    class HomePage :BasePage
    {
        public HomePage(DriverContext driverConfig) : base(driverConfig)
        {
        }

        IWebElement homeIcon => _driverConfig.Driver.FindElement(By.XPath("//a[@aria-label ='Amazon']"));


        internal SearchByCategoryPage CheckIfHomePageExist()
        {
            homeIcon.AssertElementPresent();
            return new SearchByCategoryPage(_driverConfig);
        }
    }
}
