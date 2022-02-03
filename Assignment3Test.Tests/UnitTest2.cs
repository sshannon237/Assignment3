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
        public void Test1()
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Employee")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Create New")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.Id("Name")).SendKeys("Fest Fester");
            driver.FindElement(By.Id("Address")).SendKeys("123 Street St");
            driver.FindElement(By.Id("Salary")).SendKeys("50000");
            driver.FindElement(By.XPath("//Input[@type='submit']")).Click();
            driver.Close();
        }

        // Testing Employee Reading
        [TestMethod]
        public void Test2()
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Employee")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Details")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.XPath("//*[contains(text(), 'Fest Fester')]"));
            driver.FindElement(By.XPath("//*[contains(text(), '123 Street St')]"));
            driver.FindElement(By.XPath("//*[contains(text(), '50000')]"));
            driver.Close();
        }

        // Testing Employee Edit
        [TestMethod]
        public void Test3()
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Employee")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Edit")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.Id("Employee_Name")).Clear();
            driver.FindElement(By.Id("Employee_Name")).SendKeys("Test Tester");
            driver.FindElement(By.Id("Employee_Address")).Clear();
            driver.FindElement(By.Id("Employee_Address")).SendKeys("1414 Green Ave");
            driver.FindElement(By.Id("Employee_Salary")).Clear();
            driver.FindElement(By.Id("Employee_Salary")).SendKeys("80000");
            driver.FindElement(By.XPath("//Input[@type='submit']")).Click();
            driver.Close();
        }

        // Testing Employee Deletion
        [TestMethod]
        public void Test4()
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Employee")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Delete")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.XPath("//Input[@type='submit']")).Click();
            driver.Close();
        }
    }
}
