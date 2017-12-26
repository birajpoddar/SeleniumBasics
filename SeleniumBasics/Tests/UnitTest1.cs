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

            try
            {
                driver.Title.ShouldContain("Google");
            }
            catch(Exception ex)
            {
                Log.Fatal("Title did not match, EXITING Test...");
                throw new Exception("Title did not match", ex);                
            }
            finally
            {
                driver.Quit();
            }

            Log.Info("Title Matched");

            //driver.Quit();
        }
    }

    [TestFixture]
    public class RandomTest : TestBase
    {
        public RandomTest() : base()
        {

        }

        //[TestCase("1"), TestCase("2")]
        [TestCaseSource("Source")]
        public void Random(string invalid)
        {
            Console.WriteLine(invalid);

            Log.Info("RandomTest....");
            Log.Debug("Debug RandomTest....");

            //this.ShouldBe(null);

            Log.Error("Error RandomTest...");
            Log.Fatal("Fatal RandomTest...");
            Log.Warn("Warn Random Test...");
        }

        static string[] Source = { "1", "2", "3" };
    }
}
