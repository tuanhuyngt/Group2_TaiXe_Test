using Group2_TaiXe_Test.BaseClass;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace Group2_TaiXe_Test
{
    public class DriverEdit : BaseTest
    {
        IWebElement ele, txtTen, txtMucLuong, txtNgayHetHan, txtNgayDong, btnHuy, btnLuu, labelCheck;
        string str;

        void GetElement()
        {
            ele = webDriver.FindElement(By.XPath("/html/body/app-root/ng-component/div/div/div[2]/app-driver/app-driver-management-group2/div/div[1]/div[1]/div/ul/li[2]"));
            ele.Click();
            txtTen = webDriver.FindElement(By.XPath("/html/body/app-root/ng-component/div/div/div[2]/app-driver-edit/app-driver-edit-group2/div/div[2]/div/div[1]/form/div[1]/div[1]/div/input"));
            txtMucLuong = webDriver.FindElement(By.XPath("/html/body/app-root/ng-component/div/div/div[2]/app-driver-edit/app-driver-edit-group2/div/div[2]/div/div[1]/form/div[2]/div[1]/div/input"));
            txtNgayDong = webDriver.FindElement(By.XPath("/html/body/app-root/ng-component/div/div/div[2]/app-driver-edit/app-driver-edit-group2/div/div[2]/div/div[1]/form/div[1]/div[2]/div/input"));
            txtNgayHetHan = webDriver.FindElement(By.XPath("/html/body/app-root/ng-component/div/div/div[2]/app-driver-edit/app-driver-edit-group2/div/div[2]/div/div[1]/form/div[2]/div[2]/div/input"));
            btnLuu = webDriver.FindElement(By.XPath("/html/body/app-root/ng-component/div/div/div[2]/app-driver-edit/app-driver-edit-group2/div/div[2]/div/div[1]/div/div[2]/div/form/div/div/ul/li[2]"));
            labelCheck = webDriver.FindElement(By.XPath("/html/body/app-root/ng-component/div/div/div[2]/app-driver-edit/app-driver-edit-group2/div/div[2]/div/div[3]/div/p-table/div/div/table/tbody/tr[2]/td[1]/label"));
        }

        void ClickRadio()
        {
            labelCheck.Click();
        }

        [Test, Category("RightDriverEdit"), Order(1)]
        public void txtTenNotNull()
        {
            this.NagativeToManagement();
            this.GetElement();
            labelCheck.Click();
            Thread.Sleep(300);
            str = txtTen.GetAttribute("value");
            Assert.IsNotNull(str);
        }
        [Test, Category("RightDriverEdit"), Order(2)]
        public void txtMucLuongNotNull()
        {    
            str = txtMucLuong.GetAttribute("value");
            Assert.IsNotNull(str);
        }

        [Test, Category("RightDriverEdit"), Order(3)]
        public void txtTenCheck()
        {
            txtTen.Clear();
            txtTen.SendKeys("Tên mẫu");
            str = txtTen.GetAttribute("value");
            Assert.AreEqual("Tên mẫu", str);
        }
        [Test, Category("RightDriverEdit"), Order(4)]
        public void txtMucLuongCheck()
        {
            txtMucLuong.Clear();
            txtMucLuong.SendKeys("25tt000uu000");
            str = txtMucLuong.GetAttribute("value");
            Assert.AreEqual("25000000", str);
        }
        [Test, Category("RightDriverEdit"), Order(5)]
        public void txtNgayDongCheck()
        {
            txtNgayDong.SendKeys("02012020");
            str = txtNgayDong.GetAttribute("value");
            Assert.AreEqual("2020-02-01", str);
        }
        [Test, Category("RightDriverEdit"), Order(6)]
        public void txtNgayHetHanCheck()
        {
            txtNgayHetHan.SendKeys("02012020");
            str = txtNgayHetHan.GetAttribute("value");
            Assert.AreEqual("2020-02-01", str);
        }

        [Test, Category("RightDriverEdit"), Order(7)]
        public void modalXacNhanCheck()
        {
            btnLuu.Click();
            Thread.Sleep(200);
            ele = webDriver.FindElement(By.XPath("/html/body/app-root/ng-component/div/div/div[2]/app-driver-edit/app-driver-edit-group2/div/p-dialog/div/div[2]"));
            str = ele.Text;
            Assert.AreEqual("Xác nhận chỉnh sửa tài xế?", str);
        }

        [Test, Category("RightDriverEdit"), Order(8)]
        public void cancelXacnhan()
        {
            ele = webDriver.FindElement(By.XPath("/html/body/app-root/ng-component/div/div/div[2]/app-driver-edit/app-driver-edit-group2/div/p-dialog/div/div[3]/p-footer/button[2]"));
            ele.Click();
        }
        [Test, Category("RightDriverEdit"), Order(9)]
        public void confirmXacNhanCheck()
        {
            btnLuu.Click();
            ele = webDriver.FindElement(By.XPath("/html/body/app-root/ng-component/div/div/div[2]/app-driver-edit/app-driver-edit-group2/div/p-dialog/div/div[3]/p-footer/button[1]"));
            ele.Click();
            ele = webDriver.FindElement(By.ClassName("toast-message"));
            str = ele.Text;
            Assert.AreEqual("Chỉnh sửa thông tin tài xế thành công", str);
        }

    }
}