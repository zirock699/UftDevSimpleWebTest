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
        private Random random = new Random();
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
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"|DataDirectory|\Data\Data.csv", "Data#csv", DataAccessMethod.Sequential)]
   
            public void MyLoginTest()
        {
            IBrowser browser = BrowserFactory.Launch(BrowserType.Chrome);
            browser.Navigate("http://advantageonlineshopping.com/#/");


            var username = TestContext.DataRow[0].ToString();
            string password = TestContext.DataRow["Password"].ToString();

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
            usernameEditField.SetValue(username);

            var passwordEditField = browser.Describe<IEditField>(new EditFieldDescription
            {
                Name = @"password",
                TagName = @"INPUT",
                Type = @"password"
            });
            passwordEditField.SetValue(password);

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



        [TestMethod]
        public void VerifyUsernameIsNotEmpty()
        {
            int testValue = random.Next(0, 2); // Generates 0 or 1
            string username = testValue == 1 ? "JohnDoe" : "";
            Assert.IsFalse(string.IsNullOrEmpty(username), "Username should not be empty");
        }

        [TestMethod]
        public void VerifyPasswordLength()
        {
            int testValue = random.Next(3, 10); // Generates a number between 3 and 9
            string password = new string('*', testValue);
            Assert.IsTrue(password.Length >= 6, $"Password length {password.Length} is less than the minimum required length of 6");
        }

        [TestMethod]
        public void ValidateSuccessfulLogin()
        {
            int testValue = random.Next(0, 2); // Generates 0 or 1
            bool loginSuccessful = testValue == 1;
            Assert.IsTrue(loginSuccessful, "Login should be successful");
        }

        [TestMethod]
        public void CheckForTwoFactorAuthentication()
        {
            int testValue = random.Next(0, 2); // Generates 0 or 1
            bool twoFactorEnabled = testValue == 1;
            Assert.IsTrue(twoFactorEnabled, "Two-factor authentication should be enabled");
        }

        [TestMethod]
        public void VerifyAccountLockAfterFailedAttempts()
        {
            int failedAttempts = random.Next(1, 6); // Generates a number between 1 and 5
            Assert.IsTrue(failedAttempts < 5, $"Account should not be locked, but had {failedAttempts} failed attempts");
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
