using OpenQA.Selenium;
using ProjectTurnUp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTurnUp.Pages
{
    public class HomePage
    {
        public void NavigateToTMPage(IWebDriver driver)
        {
            Wait.WaitToBeVisible(driver, "XPath", "/html/body/div[3]/div/div/ul/li[5]", 2);
            // Navigate to Time & Materials page
            IWebElement adminMenu = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]"));
            adminMenu.Click();
            // Wait for the menu to load
            Wait.WaitToBeClicakable(driver, "XPath", "//a[contains(@href, 'TimeMaterial')]", 2);
            IWebElement timeAndMaterialsMenu = driver.FindElement(By.XPath("//a[contains(@href, 'TimeMaterial')]"));
            timeAndMaterialsMenu.Click();
        }

        public void NavigateToEmployeePage(IWebDriver driver)
        {
            Wait.WaitToBeVisible(driver, "XPath", "/html/body/div[3]/div/div/ul/li[5]", 2);
            // Navigate to Time & Materials page
            IWebElement adminMenu = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]"));
            adminMenu.Click();
            // Wait for the menu to load
             IWebElement employeeMenu = driver.FindElement(By.XPath("//a[contains(@href, 'User')]"));
            employeeMenu.Click();

        }


    }


}
