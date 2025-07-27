using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTurnUp.Utilities
{
    public class Wait
    {
        public static void WaitToBeClicakable(IWebDriver driver, string locatorType, string locatorValue, int seconds)
        { 
         var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));

            if (locatorType == "XPath")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(locatorValue)));
            }
            if (locatorType == "Id")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id(locatorValue)));
            }
        }
        public static void WaitToBeVisible(IWebDriver driver, string locatorType, string locatorValue, int seconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            if (locatorType == "XPath")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(locatorValue)));
            }
            if (locatorType == "Id")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(locatorValue)));
            }
        }

        public static void WaitForGridToLoad(IWebDriver driver, int seconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));

            wait.Until(d =>
            {
                var rows = d.FindElements(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr"));
                // Check if at least one row is visible in the grid
                return rows.Count > 0 && rows.All(row => row.Displayed);
            });
        }
    }
}
