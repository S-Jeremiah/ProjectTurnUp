using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ProjectTurnUp.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTurnUp.Tests
{
    
    [TestFixture]
    [Parallelizable]
    public class EmployeeTest: Utilities.CommonDriver
    {
        [OneTimeSetUp]
        public void OneTimeSetUp_Steps()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddUserProfilePreference("profile.password_manager_leak_detection", false);
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();

            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginAction(driver);

            HomePage homePageObj = new HomePage();
            homePageObj.NavigateToEmployeePage(driver);


        }
        
        [Test,Order(1)]
        public void CrteEmployee_Test()
        {
            Employees employeePageObj = new Employees();
            employeePageObj.CreateEmployee(driver);
        }

        [Test,Order(2)]
        public void EditEmployee_Test()
        {
            Employees employeePageObj = new Employees();
            employeePageObj.EditEmployee(driver);
        }


        [Test,Order(3)]
        public void DeleteEmployee_Test()
        {
            Employees employeePageObj = new Employees();
            employeePageObj.DeleteEmployee(driver);
        }
        [OneTimeTearDown]
        public void CloseTest()
        {
            driver.Quit();
        }

    }
}
