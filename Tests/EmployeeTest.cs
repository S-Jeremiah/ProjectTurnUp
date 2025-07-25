using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ProjectTurnUp.Pages;
using ProjectTurnUp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTurnUp.Tests
{

    [TestFixture]
  [Parallelizable]
    public class EmployeeTest : BaseClass
    {
       
     

        [Test, Order(1)]
        public void NavigateToemployee()
        {
           

            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginAction(driver);

            HomePage homePageObj = new HomePage();
            homePageObj.NavigateToEmployeePage(driver);


        }

        [Test, Order(2)]
        public void CrteEmployee_Test()
        {
            Employees employeePageObj = new Employees();
            employeePageObj.CreateEmployee(driver);
        }

        [Test, Order(3)]
        public void EditEmployee_Test()
        {
            Employees employeePageObj = new Employees();
            employeePageObj.EditEmployee(driver);
        }


        [Test, Order(4)]
        public void DeleteEmployee_Test()
        {
            Employees employeePageObj = new Employees();
            employeePageObj.DeleteEmployee(driver);
        }
        
     

    }
}
