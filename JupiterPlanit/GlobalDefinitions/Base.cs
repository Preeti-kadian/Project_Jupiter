
using JupiterPlanit.GlobalDefinitions;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using static JupiterPlanit.GlobalDefinitions.Global;

namespace JupiterPlanet.GlobalDefinitions
{
    [TestFixture]
    public class Base
    {
        public static RemoteWebDriver _driver;
        public Base(RemoteWebDriver driver)
        {

            _driver = driver;

        }

        #region To access Path from resource file

        public static string Url = "http://jupiter.cloud.planittesting.com";
        public static String ExcelPath = "/Users/preetikadian/Desktop/JupiterPlanit/JupiterPlanit/JupiterPlanit/ExcelData/ContactInfo.xlsx";
        public static string ScreenshotPath = "/Users/preetikadian/Desktop/JupiterPlanit/JupiterPlanit/JupiterPlanit/Test Reports/ScreenshotPath";
        public static string ReportPath = "/Users/preetikadian/Desktop/JupiterPlanit/JupiterPlanit/JupiterPlanit/Test Reports";
        #endregion
        
            
       
        #region setup and tear down
        [SetUp]
        public void Inititalize()
        {
            //instantiate the browser
            _driver = new ChromeDriver();

            //navigate to the website
            _driver.Navigate().GoToUrl(Url);
            //Maximize the browser
           _driver.Manage().Window.Maximize();


        }


        [TearDown]
        public void TearDown()
        {
        
            // Close the driver :)            
            _driver.Close();
        }
    }
        #endregion

    
}