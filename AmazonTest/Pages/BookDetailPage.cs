using AmazonTestFramework.Base;
using AmazonTestFramework.Extensions;
using AmazonTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;



namespace AmazonTest.Pages
{
    class BookDetailPage : BasePage

    {
        public BookDetailPage(DriverContext driverConfig) : base(driverConfig)
        {
        }

        public IWebElement BtnAddToCart => _driverConfig.Driver.FindElement(By.XPath("//input[@id='add-to-cart-button']"));
        public IWebElement TextFirstBookTitle => _driverConfig.Driver.FindElement(By.XPath("//span[@id='productTitle']"));

        public IWebElement BtnPaperBack => _driverConfig.Driver.FindElement(By.XPath("//a[@role = 'button']/span[contains(text(),'Paperback')]"));

        public BookCartPage AddBookToCart()
        {
           if(WebElementExtensions.IsElementPresent(BtnPaperBack))
            {
                if (WebElementExtensions.IsElementPresent(BtnAddToCart))
                {
                    BtnAddToCart.Click();
                    LogHelpers.Write("Hello");
                    return new BookCartPage(_driverConfig);
                }
                else
                {
                    LogHelpers.Write("Book not available");
                    return null;
                }
            }
           else
            {
                LogHelpers.Write("Book not available");
                return null;
            }


        }
        public void MatchTitleOfDetailBook(string actualBookTitle)

        {
            actualBookTitle = actualBookTitle + "dss";
            _driverConfig.Driver.SwitchTo().Window(_driverConfig.Driver.WindowHandles[1]);
            string bookTitle = WebElementExtensions.GetElementText(TextFirstBookTitle);
          /*  if (actualBookTitle.Equals(bookTitle))
            {

                LogHelpers.Write("Book opened successfully");

            }
            else
            {
                LogHelpers.Write("Book not opened");
            }*/

            Assert.AreEqual(bookTitle, actualBookTitle);
         


        }

    }
}
