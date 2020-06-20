using AmazonTest.Pages;
using AmazonTestFramework.Base;
using System;

using TechTalk.SpecFlow;

namespace AmazonTest.Steps
{
    [Binding]
    class BookListPageSteps :BaseStep
    {
        public static string actualTitle;
        public new readonly DriverContext _driverConfig;

        public BookListPageSteps(DriverContext driverConfig) : base(driverConfig)
        {
            _driverConfig = driverConfig;
        }

        [Given(@"List of searched Book is visible")]
        public void GivenListOfSearchedBookIsVisible()
        {
            _driverConfig.CurrentPage.As<BookListPage>().CheckSearchedBookListIsOpen();
        }

        [When(@"I get the BookTitle of First Book")]
        [Obsolete]
        public void WhenIGetTheBookTitleOfFirstBook()
        {
            actualTitle = _driverConfig.CurrentPage.As<BookListPage>().GetTitleOfFirstBook();
        }

        [When(@"I click the first Book In List")]
        public void WhenIClickTheFirstBookInList()
        {
            _driverConfig.CurrentPage = _driverConfig.CurrentPage.As<BookListPage>().ClickFirstBook();
        }

        [Then(@"First Book detail page is open")]
        public void ThenFirstBookDetailPageIsOpen()
        {
            _driverConfig.CurrentPage.As<BookDetailPage>().MatchTitleOfDetailBook(actualTitle);

        }

    }
}
