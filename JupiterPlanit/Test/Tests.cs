using System;
using JupiterPlanet.GlobalDefinitions;
using JupiterPlanit.Pages;
using NUnit.Framework;


namespace JupiterPlanit
{
    [TestFixture]
    public class Tests: Base
    {
        public Tests() : base(_driver)
        {

        }
        [Test]
        [Repeat(5)]
        [Obsolete]
        //Test for contact details functionality
        public void Contact()
        {
           
            Contact contactObj = new Contact(_driver);
            contactObj.SaveContactDetails();
            contactObj.ValidateContactDetails();
           
        }

        //Test for shop functionality
        [Test]
        [Obsolete]
        public void Shop()
        {
            Shop shopObj = new Shop(_driver);
            shopObj.AddToCart();
          
        }

        //Test for cart functionality
        [Test]
        [Obsolete]
        public void Cart()
        {

            Cart cartObj = new Cart(_driver);
            cartObj.VerifyCart();
            
        }
    }
}
