using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using HomeValuationTests.Extensions;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;

namespace HomeValuationTests
{
    public class SeleniumTests
    {
        private const string pageUrl = "https://homevaluationfront.azurewebsites.net/test.html";
        private const string sqm = "100";
        private const string constructionYear = "2005";
        private const string energyLabel = "C";

        private string chromeDriverPath;

        internal const int WaitTime = 3500;
        internal static void Wait()
        {
            Thread.Sleep(WaitTime);
        }

        public SeleniumTests()
        {
            chromeDriverPath = @"C:\webDrivers\chromedriver.exe";
        }

        [Fact]
        public void TitleTest()
        {
            // Arrange
            using (IWebDriver driver = new ChromeDriver(chromeDriverPath))
            {
                // Act
                driver.Navigate().GoToUrl("https://homevaluationfront.azurewebsites.net/test.html");

                string actualTitle = driver.Title;

                // Assert
                Assert.Equal("Document", actualTitle);
            }
        }

        [Fact]
        public void AvgPriceTest()
        {
            using (IWebDriver driver = new ChromeDriver(chromeDriverPath))
            {
                driver.Navigate().GoToUrl(pageUrl);

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.UrlContains(pageUrl));

                Wait();

                driver.FindElement(By.XPath("/html/body/main/div/div[1]/div/ul/li[1]/a/button")).Click();

                Wait();

                IWebElement webElement = driver.FindElement(By.XPath("/html/body/main/div/div[2]/p"));
                string actualAvgPrice = webElement.Text;

                Assert.Equal("29.694 kr.", actualAvgPrice);
            }
        }

        [Fact]
        public void CalculateTest()
        {
            using (IWebDriver driver = new ChromeDriver(chromeDriverPath))
            {
                driver.Navigate().GoToUrl(pageUrl);

                Wait();

                driver.FindElement(By.XPath("/html/body/main/div/div[1]/div/ul/li[1]/a/button")).Click();

                Wait();

                driver.FindElement(By.XPath("/html/body/main/div/div[2]/input[1]")).SendKeys(sqm);
                driver.FindElement(By.XPath("/html/body/main/div/div[2]/input[2]")).SendKeys(constructionYear);
                driver.FindElement(By.XPath("/html/body/main/div/div[2]/input[3]")).SendKeys(energyLabel);

                Wait();

                driver.FindElement(By.XPath("/html/body/main/div/div[2]/div/ul/li[2]/a/button")).Click();

                Wait();

                IWebElement webElement = driver.FindElement(By.XPath("/html/body/main/div/div[3]/p"));
                string actualCalculatedPrice = webElement.Text;

                Assert.Equal("3.299.003 kr.", actualCalculatedPrice);
            }
        }

    }
}
