using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Remote;
using System;
using JupiterPlanit.GlobalDefinitions;
using static JupiterPlanit.GlobalDefinitions.Global;
using System.Threading;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Interactions;

namespace JupiterPlanit.Pages
{
    public class Shop
    {
        public RemoteWebDriver _driver;

        public Shop(RemoteWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        #region Initialise web elements

        //Home tab
        [FindsBy(How = How.LinkText, Using = "Home")]
        public IWebElement homeTab { get; set; }

        //Shop tab
        [FindsBy(How = How.LinkText, Using = "Shop")]
        public IWebElement shopTab { get; set; }

        //Buy button for funny cow
        [FindsBy(How = How.XPath, Using = "//*[@id='product-6']/div/p/a")]
        public IWebElement buyCow { get; set; }

        //Buy button for fluffy bunny 
        [FindsBy(How = How.XPath, Using = "//*[@id='product-4']/div/p/a")]
        public IWebElement buyBunny { get; set; }

        //cart tab
        [FindsBy(How = How.XPath, Using = "//*[@id='nav-cart']/a")]
        public IWebElement cartButton { get; set; }

     
        //cow quantity
        [FindsBy(How = How.XPath, Using = " //body[@class='ng-scope']/div[@class='container-fluid']//form[@name='form']/table/tbody/tr[1]/td[3]/input[@name='quantity']")]
        public IWebElement cowQuantity{ get; set; }

        //bunnyQuanity
        [FindsBy(How = How.XPath, Using = " //body[@class='ng-scope']/div[@class='container-fluid']//form[@name='form']/table/tbody/tr[1]/td[3]/input[@name='quantity']")]
        public IWebElement bunnyQuantity { get; set; }

        #endregion

        [Obsolete]
        public void AddToCart()
        {
            //Click on home tab
            homeTab.WaitForElementClickable(_driver, 40).Click();

            //Click on shop tab
            shopTab.WaitForElementClickable(_driver, 60).Click();

            Thread.Sleep(2000);
            //Click on funny cow twice
            Actions action = new Actions(_driver);
            action.DoubleClick(buyCow).Build().Perform();

            //Click on fluffy bunny
            buyBunny.Click();

            //Click on cart
            cartButton.WaitForElementClickable(_driver, 60).Click();

            Thread.Sleep(5000);
            Console.WriteLine(cowQuantity.Text);
           //Validate if items are added to cart
            if(cowQuantity.Text == "2" && bunnyQuantity.Text == "1")
            {
                Thread.Sleep(4000);
                Assert.Pass("Test Passed, cart updated");

            }
           
        }

    }
}