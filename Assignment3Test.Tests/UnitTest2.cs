using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Assignment3Test.Tests
{
    [TestClass]
    public class EmployeeTests
    {
        string url = "http://localhost:55544";
        ChromeDriver driver = new ChromeDriver();

        public EmployeeTests()
        {
        }

        // Testing Employee Creation
        [TestMethod]
        public void TestCreateEmployee()
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Employee")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Create New")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.Id("Name")).SendKeys("Fest Fester");
            driver.FindElement(By.Id("Address")).SendKeys("123 Street St");
            driver.FindElement(By.Id("Salary")).SendKeys("50,000");
            driver.FindElement(By.XPath("//Input[@type='submit']")).Click();
        }

        // Testing Employee Edit
        [TestMethod]
        public void TestEditEmployee()
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Employee")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Edit")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.Id("Name")).Clear();
            driver.FindElement(By.Id("Name")).SendKeys("Test Tester");
            driver.FindElement(By.Id("Address")).Clear();
            driver.FindElement(By.Id("Address")).SendKeys("1414 Green Ave");
            driver.FindElement(By.Id("Salary")).Clear();
            driver.FindElement(By.Id("Salary")).SendKeys("80000");
            driver.FindElement(By.XPath("//Input[@type='submit']")).Click();
        }

        // Testing Employee Reading
        [TestMethod]
        public void TestReadEmployee()
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Employee")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Details")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.XPath("//*[contains(text(), 'Test Tester')]"));
            driver.FindElement(By.XPath("//*[contains(text(), '1414 Green Ave')]"));
            driver.FindElement(By.XPath("//*[contains(text(), '80000')]"));
        }

        // Testing Employee Deletion
        [TestMethod]
        public void TestDeleteEmployee()
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Employee")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Delete")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.XPath("//Input[@type='submit']")).Click();
        }
    }
}
