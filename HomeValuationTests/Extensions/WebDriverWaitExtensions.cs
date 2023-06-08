using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeValuationTests.Extensions
{
    public static class WebDriverWaitExtensions
    {
        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }

            return driver.FindElement(by);
        }

        public static bool WaitForDocumentReadyStateComplete(this WebDriverWait wait)
        {
            return wait.Until(expectedCondition => ((IJavaScriptExecutor)expectedCondition).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public static Cookie WaitForCookie(this WebDriverWait wait, string cookieName)
        {
            return wait.Until(driver => driver.Manage().Cookies.GetCookieNamed(cookieName));
        }

        public static bool WaitForCookieAbsence(this WebDriverWait wait, string cookieName)
        {
            return wait.Until(driver => driver.Manage().Cookies.GetCookieNamed(cookieName) == null);
        }
    }
}
