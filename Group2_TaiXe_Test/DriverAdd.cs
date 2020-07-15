using Group2_TaiXe_Test.BaseClass;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Group2_VatTu_Test
{
    public class DriverAdd : BaseTest
    {
        IWebElement ele;
        string str;
        IWebElement txtTen, txtMucLuong, txtNgayBatDau, txtHangGPLX, btnLuu;

        void GetElement()
        {
            ele = webDriver.FindElement(By.XPath("/html/body/app-root/ng-component/div/div/div[2]/app-driver/app-driver-management-group2/div/div[1]/div[1]/div/ul/li[1]"));
            ele.Click();
            Thread.Sleep(200);
            txtTen = webDriver.FindElement(By.XPath("/html/body/app-root/ng-component/div/div/div[2]/app-driver-add/app-driver-add-group2/div/div[2]/div/div[1]/form/div[1]/div[1]/div/input"));
            txtMucLuong = webDriver.FindElement(By.XPath("/html/body/app-root/ng-component/div/div/div[2]/app-driver-add/app-driver-add-group2/div/div[2]/div/div[1]/form/div[2]/div[1]/div/input"));
            txtNgayBatDau = webDriver.FindElement(By.XPath("/html/body/app-root/ng-component/div/div/div[2]/app-driver-add/app-driver-add-group2/div/div[2]/div/div[1]/form/div[1]/div[2]/div/input"));
            txtHangGPLX = webDriver.FindElement(By.XPath("/html/body/app-root/ng-component/div/div/div[2]/app-driver-add/app-driver-add-group2/div/div[2]/div/div[1]/form/div[2]/div[2]/div/p-dropdown"));
            btnLuu = webDriver.FindElement(By.XPath("/html/body/app-root/ng-component/div/div/div[2]/app-driver-add/app-driver-add-group2/div/div[2]/div/div[1]/div/div[2]/div/form/div/div/ul/li[2]"));
        }

        [Test, Category("RightInputDriverAdd"), Order(1)]
        public void txtTenCheck()
        {
            this.NagativeToManagement();
            this.GetElement();
            txtTen.SendKeys("Tuấn Huy");
            str = txtTen.GetAttribute("value");
            Assert.AreEqual("Tuấn Huy", str);
        }
        [Test, Category("RightInputDriverAdd"), Order(2)]
        public void txtMucLuongCheck()
        {
            txtMucLuong.SendKeys("2oio0000000");
            str = txtMucLuong.GetAttribute("value");
            Assert.AreEqual("20000000", str);
        }
        [Test, Category("RightInputDriverAdd"), Order(3)]
        public void txtNgayBatDauCheck()
        {
            txtNgayBatDau.SendKeys("02012020");
            str = txtNgayBatDau.GetAttribute("value");
            Assert.AreEqual("2020-02-01", str);
        }

        [Test, Category("RightInputDriverAdd"), Order(4)]
        public void txtHangGPLXCheck()
        {
            txtHangGPLX.Click();
            Thread.Sleep(300);
            ele = webDriver.FindElement(By.XPath("/html/body/app-root/ng-component/div/div/div[2]/app-driver-add/app-driver-add-group2/div/div[2]/div/div[1]/form/div[2]/div[2]/div/p-dropdown/div/div[4]/div/ul/li[3]"));
            ele.Click();
            str = txtHangGPLX.Text;
            Assert.AreEqual("B2", str);
        }
        [Test, Category("RightInputDriverAdd"), Order(5)]
        public void modalXacNhanCheck()
        {
            btnLuu.Click();
            ele = webDriver.FindElement(By.XPath("/html/body/app-root/ng-component/div/div/div[2]/app-driver-add/app-driver-add-group2/div/p-dialog/div/div[2]"));
            str = ele.Text;
            Assert.AreEqual("Xác nhận thêm tài xế?", str);
        }

        [Test, Category("RightInputDriverAdd"), Order(7)]
        public void cancelXacnhan()
        {
            ele = webDriver.FindElement(By.XPath("/html/body/app-root/ng-component/div/div/div[2]/app-driver-add/app-driver-add-group2/div/p-dialog/div/div[3]/p-footer/button[2]"));
            ele.Click();
        }
        [Test, Category("RightInputDriverAdd"), Order(8)]
        public void confirmXacNhanCheck()
        {
            btnLuu.Click();
            ele = webDriver.FindElement(By.XPath("/html/body/app-root/ng-component/div/div/div[2]/app-driver-add/app-driver-add-group2/div/p-dialog/div/div[3]/p-footer/button[1]"));
            ele.Click();
            ele = webDriver.FindElement(By.ClassName("toast-message"));
            str = ele.Text;
            Assert.AreEqual("Thêm tài xế thành công", str);
        }

    }
}
