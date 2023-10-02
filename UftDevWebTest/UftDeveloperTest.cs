using System;
using HP.LFT.SDK;
using HP.LFT.Verifications;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HP.LFT.SDK.Web;

namespace UftDevWebTest
{
    [TestClass]
    public class UftDeveloperTest : UnitTestClassBase<UftDeveloperTest>
    {
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            GlobalSetup(context);
        }

        [TestInitialize]
        public void TestInitialize()
        {

        }
        [TestMethod]

        public void MyLoginTest()
        {
            IBrowser browser = BrowserFactory.Launch(BrowserType.Chrome);
            browser.Navigate("http://advantageonlineshopping.com/#/");

            for (int i=1;i <11; i++)
            {
                browser.OpenNewTab();

            }

            
            var userMenuLink = browser.Describe<ILink>(new LinkDescription
            {
                InnerText = @"My account My orders Sign out ",
                TagName = @"A"
            });
            userMenuLink.Click();


            var usernameEditField = browser.Describe<IEditField>(new EditFieldDescription
            {
                Name = @"username",
                TagName = @"INPUT",
                Type = @"text"
            });
            usernameEditField.SetValue("RandomUserName");

            var passwordEditField = browser.Describe<IEditField>(new EditFieldDescription
            {
                Name = @"password",
                TagName = @"INPUT",
                Type = @"password"
            });
            passwordEditField.SetSecure("6514481c7a0efe6e7834029e51d2341af2856953ce0d6971a80d6aec61a3a4fe59ff");

            var signInBtnButton = browser.Describe<IButton>(new ButtonDescription
            {
                ButtonType = @"button",
                Name = @"SIGN IN",
                TagName = @"BUTTON"
            });
            signInBtnButton.Click();

            signInBtnButton.Click();

            var signInResultMessageWebElement = browser.Describe<IWebElement>(new WebElementDescription
            {
                TagName = @"LABEL",
                InnerText = @"Incorrect user name or password."
            });

            Verify.AreEqual(@"Incorrect user name or password.", signInResultMessageWebElement.InnerText, "Verification", "Verify property: innerText");


        }

        

        [TestCleanup]
        public void TestCleanup()
        {
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            GlobalTearDown();
        }
    }
}
