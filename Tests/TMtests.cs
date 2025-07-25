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
    public class TM_Tests : BaseClass
    {
        [Test,Order(1)]
        public void NavigationTm()
        {

           
            // LoginPage class object initialization and definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginAction(driver);

            // HomePage class object initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.NavigateToTMPage(driver);
        }
        [Test,Order(2)]
        public void Createtime_Test()
        {
            TMPages tmPageObj = new TMPages();
            tmPageObj.CreateTimeRecord(driver);
        }
        [Test,Order(3)]
        public void EditTime_Test()
        {
            TMPages tmPageObj = new TMPages();
            tmPageObj.EditTimeRecord(driver);
        }
        [Test,Order(4)]
        public void DeleteTime_Test()
        {
            TMPages tmPageObj = new TMPages();
            tmPageObj.DeleteTimeRecord(driver);
        }
        







    }
}
