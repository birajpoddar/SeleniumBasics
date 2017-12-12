using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Shouldly;

namespace SeleniumBasics.Tests
{
    [TestFixture]
    public class UnitTest1 : TestBase
    {
        public UnitTest1() : base()
        {
            //Log.Info("Something....");
        }

        [TestCase(TestName = "Open Browser"), Order(0)]
        public void OpenBrowser()
        {
            IWebDriver driver = new ChromeDriver();
            Log.Info("Opening Browser");

            driver.Url = "http://www.google.com";
            Log.Info("Browsing Google");

            driver.Title.ShouldContain("Google");

            driver.Quit();
        }
    }

    [TestFixture]
    public class RandomTest : TestBase
    {
        public RandomTest() : base()
        {

        }

        [TestCase("1")]
        public void Random(string invalid)
        {          
            Log.Info("RandomTest....");
            Log.Debug("Debug RandomTest....");

            this.ShouldBe(null);

            Log.Error("Error RandomTest...");
            Log.Fatal("Fatal RandomTest...");
            Log.Warn("Warn Random Test...");
        }
    }
}
