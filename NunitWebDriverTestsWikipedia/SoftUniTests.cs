using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NunitWebDriverTests
{
    public class SoftUniTests
    {
        private WebDriver driver;
        [OneTimeSetUp]
        public void OpenBrowserAndNavigate()
        {
            //Add option to Chrome browse instance
            var options = new ChromeOptions();
            options.AddArgument("--headless");


            this.driver=new ChromeDriver(options);
            driver.Url = "https://softuni.bg";
            driver.Manage().Window.Maximize();
        }
        [OneTimeTearDown]
        public void ShutDown()
        {
            driver.Quit();
        }

        [Test]
        public void Test_AssertMainPageTitle()
        {
            //Act
            driver.Url = "https://softuni.bg";
            string expectedTitle = "Обучение по програмиране - Софтуерен университет";
           //Assert
            Assert.AreEqual(expectedTitle, driver.Title);
        }

        [Test]
        public void Test_AssertAboutUsTitle()
        {
            //Act
            var zaNasElement = driver.FindElement(By.LinkText("За нас"));
            zaNasElement.Click();

            string expectedTitle = "За нас - Софтуерен университет";
            
            //Assert
            Assert.AreEqual(expectedTitle, driver.Title);
        }
        [Test]
        public void testInvalidUsernameAndPassword()
        {
            driver.Url = "https://softuni.bg";
            driver.FindElement(By.CssSelector(".softuni-btn-primary")).Click();

            //Locate username field
            var userNameField = driver.FindElement(By.Id("username"));

            userNameField.Click();
            driver.FindElement(By.Id("password-input")).Click();
            driver.FindElement(By.Id("password-input")).SendKeys("11");
            driver.FindElement(By.CssSelector(".softuni-btn")).Click();
            Assert.That(driver.FindElement(By.CssSelector("li")).Text, Is.EqualTo("Невалидно потребителско име или парола"));
            driver.Close();
        }
    }
}