using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Assignment3Test.Tests
{

    [TestClass]
    public class CustomerTests
    {
        string url = "http://localhost:55544";
        ChromeDriver driver = new ChromeDriver();

        public CustomerTests()
        {
        }

        // Testing Customer Creation
        [TestMethod]
        public void Test1()
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Customer")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Create New")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.Id("Name")).SendKeys("Joe Bob");
            driver.FindElement(By.Id("Address")).SendKeys("55555 Main Street");
            driver.FindElement(By.XPath("//Input[@type='submit']")).Click();
        }

        // Testing Customer Editing
        [TestMethod]

        public void Test2()
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Customer")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Edit")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.Id("Name")).Clear();
            driver.FindElement(By.Id("Name")).SendKeys("edit guy");
            driver.FindElement(By.Id("Address")).Clear();
            driver.FindElement(By.Id("Address")).SendKeys("editing street");
            driver.FindElement(By.XPath("//Input[@type='submit']")).Click();
        }

        // Testing Reading Customer Details
        [TestMethod]

        public void Test3()
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Customer")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Details")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.XPath("//*[contains(text(), 'edit guy')]"));
            driver.FindElement(By.XPath("//*[contains(text(), 'editing street')]"));
        }

        // Testing Customer Deletion
        [TestMethod]

        public void Test4()
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Customer")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Delete")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.XPath("//Input[@type='submit']")).Click();
        }
    }
}
