using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using ProjectTurnUp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTurnUp.Pages
{
    public class TMPages
    {
        public void CreateTimeRecord(IWebDriver driver)
        {
            //Click on Create New button
           // Wait.WaitToBeVisible(driver, "XPath", "//*[@id='container']/p/a", 5);
            IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\'container\']/p/a"));
            createNewButton.Click();
            //Select Time from TypeCode dropdown
            IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
            typeCodeDropdown.Click();
            Wait.WaitToBeClicakable(driver, "XPath", "//*[@id=\"TypeCode_listbox\"]/li[2]", 2);
            IWebElement timeOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
            timeOption.Click();
            //Type code in the Code textbox
            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.SendKeys("Creating Time Record");
            //Type description in the Description textbox
            IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
            descriptionTextbox.SendKeys("This is the description for Time");


            //Type price in the Price textbox
            IWebElement priceTabOverlap = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceTabOverlap.Click();
            IWebElement priceTextbox = driver.FindElement(By.Id("Price"));
            priceTextbox.SendKeys("10");
            //Click on Save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            //Thread.Sleep(2000); // Wait for the save operation to complete

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//a[@title=\"Go to the last page\"]")));


           // Wait.WaitToBeClicakable(driver, "XPath", "//a[@title=\"Go to the last page\"]", 20);
            IWebElement goTOlastPageRecord = driver.FindElement(By.XPath("//a[@title=\"Go to the last page\"]"));
            
            goTOlastPageRecord.Click();
            Wait.WaitForGridToLoad(driver, 15);

            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]", 4);
            IWebElement lastElement = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
           Assert.That(lastElement.Text, Is.EqualTo("Creating Time Record"), "Last record is not displayed in the form.");
            


        }  
        public void EditTimeRecord(IWebDriver driver) 
        {
            //Editing the last record
            IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            editButton.Click();
        

            IWebElement changeCodeBox = driver.FindElement(By.XPath("//*[@id=\"Code\"]"));
            changeCodeBox.Clear();
            changeCodeBox.SendKeys("Editing Time Record");

            IWebElement changeDescriptionBox = driver.FindElement(By.XPath("//*[@id=\"Description\"]"));
            changeDescriptionBox.Clear();
            changeDescriptionBox.SendKeys("This is the Edited description for Time");
            IWebElement saveBtn = driver.FindElement(By.XPath("//*[@id=\"SaveButton\"]"));
            saveBtn.Click();
            //Thread.Sleep(2000); // Wait for the save operation to complete
                                //verify the last record is displayed is edited in the form

            Wait.WaitToBeClicakable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]/span", 10);
            IWebElement goToLastRecordEdited = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastRecordEdited.Click();
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]", 2);
            //Click on the last record in the table
            IWebElement lastRecordEdited = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            Assert.That(lastRecordEdited.Text, Is.EqualTo("12TimeCode"), "Last record is not edited in the form.");
           
        }

        public void DeleteTimeRecord(IWebDriver driver) 
        {
            //Delete the last record
            IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            deleteButton.Click();
            IAlert alert = driver.SwitchTo().Alert();

            // Option 1: Accept the alert (click OK)
            alert.Accept();

            //verify the last record is deleted 

            Wait.WaitToBeClicakable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]", 2);
            IWebElement lastRecordDeleted = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            Assert.That(lastRecordDeleted.Text, Is.Not.EqualTo("12TimeCode"), "Last record is not deleted in the form.");
            
        }

    }


}
