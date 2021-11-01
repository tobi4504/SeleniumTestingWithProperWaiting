using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;
using System.Threading;


namespace DR_Rest_Test
{
    [TestClass]
    public class UnitTest1
    {
        static string DriverDirectory = "C:\\Driver";
        static string URL = "file:///C:/Users/tobia/OneDrive/Skrivebord/RestWithCasper/DR-Rest-Website-main/DR-Rest-Website-Project/index.html";
        static IWebDriver driver = new ChromeDriver(DriverDirectory);
        //static IWebDriver driver = new FirefoxDriver(DriverDirectory);
        static IWebElement getAllButtonElement;
        static IWebElement getIdInputField;
        static IWebElement getByIdButton;
        static IWebElement resultElement1;
        static IWebElement resultElement2;
        static WebDriverWait waiting;
        [ClassInitialize]
        public static void TestClassSetup(TestContext context)
        {
            waiting = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            driver.Navigate().GoToUrl(URL);
            getAllButtonElement = driver.FindElement(By.Id("getAll"));
            getByIdButton = driver.FindElement(By.Id("getById"));
            resultElement1 = driver.FindElement(By.Id("getResult1"));
            resultElement2 = driver.FindElement(By.Id("getResult2"));
            getIdInputField = driver.FindElement(By.Id("recordInputId"));
            //clearElement = driver.FindElement(By.Id("clear"));
        }
        [TestInitialize]
        public void TestInitialize()
        {
            //clearElement.Click();
        }
        [TestMethod]
        public void GetAllTest()
        {
            waiting.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("getAll")));
            getAllButtonElement.Click();
            waiting.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement(resultElement1, ")"));
            Assert.IsNotNull(resultElement1.Text.Trim());
        }
        [TestMethod]
        public void GetByID()
        {
            waiting.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("recordInputId")));
            getIdInputField = driver.FindElement(By.Id("recordInputId"));
            getIdInputField.Clear();                                  
            getIdInputField.SendKeys("3");
            getByIdButton.Click();
            waiting.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement(resultElement2,")"));                                    
            Assert.IsTrue(resultElement2.Text.Contains("Hello"));        
        }
        [ClassCleanup]
        public static void TestTearDown()
        {
        //driver.Quit();
        }
    }
}
