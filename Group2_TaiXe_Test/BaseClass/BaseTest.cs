using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;

namespace Group2_TaiXe_Test.BaseClass
{
    public class BaseTest
    {
        public string strUrl = "http://localhost:4200";
        /*public string strUrl = "http://k22.phanmemquanlytaisan.com/";*/
        static public IWebDriver webDriver;
        IWebElement ele;

        [OneTimeSetUp]
        public void Open()
        {
            webDriver = new ChromeDriver();
            webDriver.Manage().Window.Size = new Size(1470, 1030);
            webDriver.Url = strUrl;
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(9);

            //Login
            ele = webDriver.FindElement(By.XPath("/html/body/app-root/ng-component/div/ng-component/div/div/div/div[2]/div/form/div[2]/div/input"));
            ele.SendKeys("admin");
            ele = webDriver.FindElement(By.XPath("/html/body/app-root/ng-component/div/ng-component/div/div/div/div[2]/div/form/div[3]/div/input"));
            ele.SendKeys("123qwe");
            ele = webDriver.FindElement(By.XPath("/html/body/app-root/ng-component/div/ng-component/div/div/div/div[2]/div/form/div[5]/button"));
            ele.Click();
            Thread.Sleep(5000);

        }

        public void NagativeToManagement()
        {
            ele = webDriver.FindElement(By.XPath("/html/body/app-root/ng-component/div/div/div[1]/side-bar-menu/nav/div[1]/div/ul/li[9]"));
            ele.Click();
            Thread.Sleep(400);
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [OneTimeTearDown]
        public void Close()
        {
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            webDriver.Close();
        }

    }
}
