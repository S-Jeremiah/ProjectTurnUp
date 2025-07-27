using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace ProjectTurnUp.Utilities
{
    
    public class BaseClass
    {
        public IWebDriver driver;
        [OneTimeSetUp]
        public void SatrtBrowser()
        {
            
            InitBrowser("Chrome");
          
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); 


        }
        public void InitBrowser(String browserName)
        {
            switch(browserName)
            {
                case "Chrome":
                    ChromeOptions options = new ChromeOptions();
                    options.AddUserProfilePreference("profile.password_manager_leak_detection", false);
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver(options);
                    driver.Manage().Window.Maximize();
                    break;

                case "Edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver = new EdgeDriver();
                    driver.Manage().Window.Maximize();
                    break;

            }




        }

        [OneTimeTearDown]
        public void AfterTest()
        {
            driver.Quit();
        }
    }
}
