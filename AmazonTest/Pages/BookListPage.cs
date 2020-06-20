using AmazonTestFramework.Base;
using AmazonTestFramework.Extensions;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace AmazonTest.Pages
{
    class BookListPage : BasePage
    {
        public BookListPage(DriverContext driverConfig) : base(driverConfig)
        {
        }



        //Objects Used for this page

        public IWebElement LnkFirstBookOpen => _driverConfig.Driver.FindElement(By.XPath("(//h2/a/span)[1]"));
        public IWebElement TxtSearchedBook => _driverConfig.Driver.FindElement(By.XPath("//span[contains(text(),'SeleniumBook')]"));

        public void CheckSearchedBookListIsOpen()
        {
            // WebElementExtensions.WaitUntilFound(TxtSearchedBook, 30);
                //Thread.Sleep(10000);
            WebElementExtensions.AssertElementPresent(TxtSearchedBook);
        }
        
        public string GetTitleOfFirstBook()
        {
            string firstBookTitle = LnkFirstBookOpen.Text;
            Console.WriteLine(firstBookTitle);
            
            return firstBookTitle;
        }

        public BookDetailPage ClickFirstBook()
        {
            LnkFirstBookOpen.Click();
            return new BookDetailPage(_driverConfig);
        }


    }

}
