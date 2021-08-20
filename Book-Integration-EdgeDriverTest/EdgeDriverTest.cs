using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Edge;

namespace Book_Integration_EdgeDriverTest
{
    [TestClass]
    public class EdgeDriverTest
    {
        // In order to run the below test(s), 
        // please follow the instructions from http://go.microsoft.com/fwlink/?LinkId=619687
        // to install Microsoft WebDriver.

        private EdgeDriver _driver;

        [TestInitialize]
        public void EdgeDriverInitialize()
        {
            // Initialize edge driver 
            var options = new EdgeOptions
            {
                PageLoadStrategy = PageLoadStrategy.Normal
            };
            _driver = new EdgeDriver(options);
        }



        public void AddDevice()
        {
            _driver.Url = "https://localhost:44372/AddBooks";
            var title = _driver.FindElementById("AddBook_Title");
            title.SendKeys("Brain Jotter");

            var author = _driver.FindElementById("AddBook_Author");
            author.SendKeys("Chinia Achebe");

            var description = _driver.FindElementById("AddBook_Description");
            description.SendKeys("comical");

            var category = _driver.FindElementById("AddBook_Category");
            category.SendKeys("comic");

            var button = _driver.FindElementById("submit");
            button.Click();

        }

        [TestMethod]
        public void VerifyPageTitle()
        {
            // Replace with your own test logic
            _driver.Url = "https://www.bing.com";
            Assert.AreEqual("Bing", _driver.Title);
        }

        [TestCleanup]
        public void EdgeDriverCleanup()
        {
            _driver.Quit();
        }


    }
}
