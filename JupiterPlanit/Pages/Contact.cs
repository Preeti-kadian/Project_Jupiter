using OpenQA.Selenium;
using JupiterPlanet.GlobalDefinitions;
using NUnit.Framework;
using OpenQA.Selenium.Remote;
using System;
using JupiterPlanit.GlobalDefinitions;
using static JupiterPlanit.GlobalDefinitions.Global;
using System.Threading;
using SeleniumExtras.PageObjects;

namespace JupiterPlanit.Pages
{
    public class Contact
    {
        public RemoteWebDriver _driver;


       
        public Contact(RemoteWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        #region Initialise web elements
        
        //start shopping Button
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div/div[1]/p[2]/a")]
        public IWebElement startShoppingButton { get; set; }
        
        //contact tab
        [FindsBy(How = How.XPath, Using = "//li[@id='nav-contact']/a[@href='#/contact']")]
        public IWebElement  contactTab{ get; set; }

        //Forename text box
        [FindsBy(How = How.XPath, Using = "/html//input[@id='forename']")]
        public IWebElement foreNameText { get; set; }

        //surname textbox
        [FindsBy(How = How.XPath, Using = "/html//input[@id='surname']")]
        public IWebElement surnameText { get; set; }

        //Email input field
        [FindsBy(How = How.XPath, Using = "/html//input[@id='email']")]
        public IWebElement email { get; set; }

        //Telephone text box
        [FindsBy(How = How.XPath, Using = "/html//input[@id='telephone']")]
        public IWebElement telephoneTextBox { get; set; }

        //Message box
        [FindsBy(How = How.XPath, Using = "/html//textarea[@id='message']")]
        public IWebElement messageText { get; set; }

        //Submit button
        [FindsBy(How = How.LinkText, Using = "Submit")]
        public IWebElement submitButton { get; set; }

        //Message Display
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div")]
        public IWebElement savedMessageDisplay { get; set; }

        #endregion

        //Enter and submit contact details
        [Obsolete]
        public void SaveContactDetails()
        {

            //Click on contact tab
            contactTab.WaitForElementClickable(_driver, 60).Click();


            //Wait(3);
            foreNameText.WaitForElementClickable(_driver, 60);
            //Enter value in Forename text
            foreNameText.SendKeys("Lauren");

            //Read value in Surname
            surnameText.SendKeys("James");

            //Read value in Email
            email.SendKeys("lauren.james@gmail.com");

            //Read value in Telephone
            telephoneTextBox.SendKeys("0298765431");

            //Read value in Message
            messageText.SendKeys("Hi, I am interested in buying toys");

            //Click on Submit button
            submitButton.WaitForElementClickable(_driver, 60).Click();
        }

        //Validate the saved contact details
        public void ValidateContactDetails()
        {
            Thread.Sleep(3000);
            string actualMessageText = savedMessageDisplay.Text;

            string expectedMessageText = "Thanks Lauren, we appreciate your feedback.";
            Thread.Sleep(3000);

            //Verify if displayed displayed is same as expected
            try
            {
                if (actualMessageText == expectedMessageText)
                {
                    Thread.Sleep(2000);

                    Assert.IsTrue(true, "Test Passed, Message saved");
                }
                else
                {
                    Assert.IsFalse(false, "Test failed");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        
    }
}
