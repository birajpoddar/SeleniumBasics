using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Shouldly;
using NUnit.Allure.Attributes;
//using Ghpr.NUnit.Attributes;
using Allure;

namespace SeleniumBasics.Tests
{
    
    [AllureFixture]
    [TestFixture]
    public class UnitTest1 : TestBase
    {
        public UnitTest1() : base()
        {
            //Log.Info("Something....");
        }

        //[GhprTest]
        [AllureTest("Browser Open"), AllureStory("Selenium Test")]
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

    [AllureFixture]
    [TestFixture]
    public class RandomTest : TestBase
    {
        public RandomTest() : base()
        {

        }

        //[GhprTest]
        [AllureTest("Random test to log"), AllureStory("Random Test")]
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
