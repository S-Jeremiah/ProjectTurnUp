using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V136.WebAuthn;
using ProjectTurnUp.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProjectTurnUp.Pages
{
    public class Employees
    {
        public void CreateEmployee(IWebDriver driver)
        {
            // Click on Create New button
            IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            createNewButton.Click();
            // Fill in employee details
            Wait.WaitToBeClicakable(driver, "Id", "Name", 2);
            IWebElement nameTextbox = driver.FindElement(By.Id("Name"));
            nameTextbox.SendKeys("Mindy");
            IWebElement userNameTextbox = driver.FindElement(By.Id("Username"));
            userNameTextbox.SendKeys("Chen");
            IWebElement contactTextbox = driver.FindElement(By.Id("ContactDisplay"));
            contactTextbox.SendKeys("Auckland");
            IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
            passwordTextbox.SendKeys("123456");
            IWebElement confirmPasswordTextbox = driver.FindElement(By.Id("RetypePassword"));
            confirmPasswordTextbox.SendKeys("123456");
            IWebElement vehicleTextboxClick = driver.FindElement(By.XPath("//*[@id=\"UserEditForm\"]/div/div[7]/div/span[1]/span"));
            vehicleTextboxClick.Click();
            IWebElement vehicleTextbox = driver.FindElement(By.XPath("//*[@id=\"UserEditForm\"]/div/div[7]/div/span[1]/span/input"));
            vehicleTextbox.SendKeys("Car");

            
            //IWebElement groupBox=driver.FindElement(By.XPath("//*[@id=\"UserEditForm\"]/div/div[8]/div/div/div[1]")) ;
            //groupBox.Click();
            
            IWebElement groupname = driver.FindElement(By.XPath("//*[@id=\"UserEditForm\"]/div/div[8]/div/div/div[1]/input"));
            groupname.SendKeys("asb");

            Thread.Sleep(3000); 

            IList <IWebElement> options = driver.FindElements(By.CssSelector(".k-item"));

            foreach (IWebElement option in options)
            {
                if(option.Text.Equals("asb"))
                    {
                    option.Click();
                    break;
                }

            }


            
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();

            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='container']/div/a", 2);
            IWebElement backToListButton = driver.FindElement(By.XPath("//*[@id='container']/div/a"));
            backToListButton.Click();

            // Verify the employee is created
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"usersGrid\"]/div[4]/a[4]/span", 2);
            IWebElement lastPageEmployee = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]/span"));
            lastPageEmployee.Click();
            Wait.WaitToBeClicakable(driver, "XPath", "//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]", 3);
            IWebElement lastEmployeeRecord = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            Assert.That(lastEmployeeRecord.Text, Is.EqualTo("Mindy"), "Last employee record is not created successfully.");

        }
        public void EditEmployee(IWebDriver driver)
        {
            IWebElement editEmployeebutton= driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[3]/a[1]"));
            editEmployeebutton.Click();
            IWebElement editNamebox = driver.FindElement(By.Id("Name"));
            editNamebox.Clear();    
            editNamebox.SendKeys("Min");
            IWebElement editContactbox= driver.FindElement(By.XPath("//*[@id=\"ContactDisplay\"]"));
            editContactbox.Clear();
            editContactbox.SendKeys("Philippines");
            IWebElement editSaveButton = driver.FindElement(By.XPath("//*[@id=\"SaveButton\"]"));
            editSaveButton.Click();
            

            // Verify the employee is edited
            Wait.WaitToBeClicakable(driver, "XPath", "//*[@id=\"container\"]/div/a", 3);
            IWebElement backToEditList= driver.FindElement(By.XPath("//*[@id=\"container\"]/div/a"));
            backToEditList.Click();

            IWebElement lastPageEditedEmployee = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]/span"));
            lastPageEditedEmployee.Click();
           
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]", 3);
            IWebElement lastEditedEmployeeRecord = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            Assert.That(lastEditedEmployeeRecord.Text, Is.EqualTo("Min"), "Last employee record is not edited successfully.");
            



        }

        public void DeleteEmployee(IWebDriver driver)
        {
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[3]/a[2]", 3);
            IWebElement deleteEmployeeButton = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[3]/a[2]"));
            deleteEmployeeButton.Click();

            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            // Verify the employee is deleted
            Wait.WaitToBeClicakable(driver, "XPath", "//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]", 3);
            IWebElement lastEmployeeName= driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            Assert.That(lastEmployeeName.Text, Is.EqualTo("Min"), "Last employee record is not deleted successfully.");
            
        }


    }

}
