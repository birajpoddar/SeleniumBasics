using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using log4net;

namespace SeleniumBasics.Pages
{
    class HomePage : PageBase
    {
        static int numOfCalls = 0;
        IWebElement searchBox;
        IWebElement submitButton;
        IWebElement luckyButton;

        static HomePage()
        {
            numOfCalls += 1;
        }

        public HomePage(IWebDriver driver)
        {
            searchBox = driver.FindElement(By.Id("q"));
            Log.Info("SearchBox found");

            submitButton = driver.FindElement(By.Id("submit"));
            luckyButton = driver.FindElement(By.Id("lucky"));
        }


    }
}
