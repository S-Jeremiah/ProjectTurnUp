using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTurnUp.Pages
{
    public class LoginPage
    {

        public void LoginAction(IWebDriver driver)
        {
            
            // launch the website
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/");
            driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(10);

            // Identigy the username testbox and enter valid username
            IWebElement usernameField = driver.FindElement(By.Id("UserName"));
            usernameField.SendKeys("hari");

            // Identify the password testbox and enter valid password
            IWebElement passwordField = driver.FindElement(By.Id("Password"));
            passwordField.SendKeys("123123");

            //Identify the login button and click it
            IWebElement loginButton = driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
            loginButton.Click();
           

        }
    }
}
