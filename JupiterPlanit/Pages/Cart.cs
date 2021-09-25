using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Remote;
using System;
using JupiterPlanit.GlobalDefinitions;
using static JupiterPlanit.GlobalDefinitions.Global;
using System.Threading;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;

namespace JupiterPlanit.Pages
{
    public class Cart
    {
        public RemoteWebDriver _driver;

        public Cart(RemoteWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        #region Initialise web elements

        //Shop tab
        [FindsBy(How = How.LinkText, Using = "Shop")]
        public IWebElement shopTab { get; set; }


        //Buy button for fluffy bunny 
        [FindsBy(How = How.XPath, Using = "//body[@class='ng-scope']/div[@class='container-fluid']//ul/li[4]//a")]
        public IWebElement buyBunny { get; set; }

        //Buy button for stuffed frog
        [FindsBy(How = How.XPath, Using = "//body[@class='ng-scope']/div[@class='container-fluid']//ul/li[2]//a")]
        public IWebElement buyFrog { get; set; }

        //Buy button for valentine bear
        [FindsBy(How = How.XPath, Using = "//body[@class='ng-scope']/div[@class='container-fluid']//ul/li[7]//a")]
        public IWebElement buyBear { get; set; }

        //cart tab
        [FindsBy(How = How.XPath, Using = "//li[@id='nav-cart']/a[@href='#/cart']")]
        public IWebElement cartButton { get; set; }



        #endregion

        [Obsolete]
        public void VerifyCart()
        {
            //Click on shop tab
            shopTab.WaitForElementClickable(_driver, 30).Click();

            Thread.Sleep(2000);
            //Click on stuffed frog
            Actions action = new Actions(_driver);
            action.DoubleClick(buyFrog).Build().Perform();

            //Click on fluffy bunny 5 times
            for (int i = 0; i < 5; i++)
            {
                buyBunny.WaitForElementClickable(_driver, 20).Click();
            }

            //Click on valentine bear
            buyBear.Click();

            //Click on cart tab
            cartButton.WaitForElementClickable(_driver, 40).Click();

            Thread.Sleep(2000);

            //Verify if subtotal for each item is correct
            IList<IWebElement> tableRows = _driver.FindElements(By.XPath("/html/body/div[2]/div/form/table/tbody/tr"));

            for (int i = 1; i <= tableRows.Count; i++)
            {
                Thread.Sleep(1000);
                //Item price
                string itemPrice = _driver.FindElement(By.XPath("/html/body/div[2]/div/form/table/tbody/tr[" + i + "]/td[2]")).Text;
                //Item subtotal
                string subTotal = _driver.FindElement(By.XPath("//form/table/tbody/tr[" + i + "]/td[4]")).Text;
                //Item quantity
                int[] itemQuantity = new int[3] { 2, 5, 1 };
                    //actual subtotal value for Item
                float actualValue =  Convert.ToInt32(itemQuantity)* float.Parse(itemPrice.Replace('$', ' '));

                Thread.Sleep(2000);

             
                try
                {
                    if (actualValue == float.Parse(subTotal.Replace('$', ' ')))
                    {
                        Assert.Pass("Test Passed, Subtotal is verified");
                    }
                    
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }




            }

        }
    }

}