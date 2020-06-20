using AmazonTestFramework.Base;
using AmazonTestFramework.Extensions;
using AmazonTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using OpenQA.Selenium;
using System.Linq;

namespace AmazonTest.Pages
{
    public class BookCartPage : BasePage
    {
        public BookCartPage(DriverContext driverConfig) : base(driverConfig)
        {
        }

        public IWebElement BtnPaperBack => _driverConfig.Driver.FindElement(By.XPath("//h1[contains(text(),'Added to Cart')]"));


        public void  CheckCart()
        {
           if((BtnPaperBack.Text).Contains("Added to"))

            {
                LogHelpers.Write("Book added to cart successfully");
            }
           else
            {
                LogHelpers.Write(" Error in adding book to cart ");
            }
        }
        
    }
}
