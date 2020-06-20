using AmazonTest.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AmazonTestFramework.Helpers;
using System.Collections.Generic;
using System;

namespace AmazonTest
{
    [TestClass]
    public class UnitTest1
    {
     
        
        
        string actualBookTitle = "";
       
        
        [TestMethod]
        public void TestMethod1()
        {
            string strFileName = Environment.CurrentDirectory.ToString();
            Console.WriteLine(strFileName);
            LogHelpers.Write("Opening Browser");
           
           
            LogHelpers.Write("Navigating Page");
            

      /*
            CurrentPage = GetInstance<SearchByCategoryPage>();
         
            CurrentPage = CurrentPage.As<SearchByCategoryPage>().SearchBookByCategory(ExcelHelpers.GetCellDataList("Sheet1", "BookName")[0]);
            actualBookTitle = CurrentPage.As<BookListPage>().GetTitleOfFirstBook();
            CurrentPage = CurrentPage.As<BookListPage>().ClickFirstBook();
            CurrentPage.As<BookDetailPage>().MatchTitleOfDetailBook(actualBookTitle);
            CurrentPage = CurrentPage.As<BookDetailPage>().AddBookToCart();
            CurrentPage.As<BookCartPage>().CheckCart();*/



        }


    }
}
