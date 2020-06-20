using AmazonTestFramework.Base;
using OpenQA.Selenium;
using AmazonTestFramework.Extensions;
using AmazonTestFramework.Helpers;


namespace AmazonTest.Pages
{
    class SearchByCategoryPage : BasePage
    {
        public SearchByCategoryPage(DriverContext driverConfig) : base(driverConfig)
        {
        }




        //Objects Used for this page

        IWebElement LnkSearch => _driverConfig.Driver.FindElement(By.Id("searchDropdownBox"));
        IWebElement TextSearchFilter => _driverConfig.Driver.FindElement(By.XPath("//input[@id='twotabsearchtextbox']"));
         IWebElement BtnGo => _driverConfig.Driver.FindElement(By.XPath("//input[@value='Go']"));
        IWebElement TextSelectedFilter => _driverConfig.Driver.FindElement(By.XPath("//select/option[contains(text(),'Books') and @selected='selected']"));

        public BookListPage SearchBookByCategory(string bookName)
        {
            WebElementExtensions.SelectDropDownList(LnkSearch, "Books");
            TextSearchFilter.SendKeys(bookName);
            BtnGo.Click();
            WebElementExtensions.AssertElementPresent(TextSelectedFilter);
            return new BookListPage(_driverConfig);
        }
        public void SelectBookFilter()
        {
            WebElementExtensions.SelectDropDownList(LnkSearch, "Books");

        }

        public void EnterBookName()
        {
            TextSearchFilter.Clear();
            TextSearchFilter.SendKeys(ExcelHelpers.GetCellDataList("Sheet1", "BookName")[0]);
        }

        public BookListPage ClickGoButton()
        {
           
            BtnGo.Click();

            return new BookListPage(_driverConfig);
        }

        

    }
}
