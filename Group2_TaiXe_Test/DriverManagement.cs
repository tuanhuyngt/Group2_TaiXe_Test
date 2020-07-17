using Group2_TaiXe_Test.BaseClass;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace Group2_TaiXe_Test
{
    public class DriverManagement : BaseTest
    {
        IWebElement ele, pLoaiTimKiem, liMa, liTen, liHangBangLai, liLuongToiThieu, liLuongToiDa;
        string str;

        void GetElement()
        {
            pLoaiTimKiem = webDriver.FindElement(By.XPath("/html/body/app-root/ng-component/div/div/div[2]/app-driver/app-driver-management-group2/div/div[2]/div/div[1]/div/p-multiselect"));
            liMa = webDriver.FindElement(By.XPath("/html/body/app-root/ng-component/div/div/div[2]/app-driver/app-driver-management-group2/div/div[2]/div/div[1]/div/p-multiselect/div/div[4]/div[2]/ul/li[1]"));
            liTen = webDriver.FindElement(By.XPath("/html/body/app-root/ng-component/div/div/div[2]/app-driver/app-driver-management-group2/div/div[2]/div/div[1]/div/p-multiselect/div/div[4]/div[2]/ul/li[2]"));
            liHangBangLai = webDriver.FindElement(By.XPath("/html/body/app-root/ng-component/div/div/div[2]/app-driver/app-driver-management-group2/div/div[2]/div/div[1]/div/p-multiselect/div/div[4]/div[2]/ul/li[3]"));
            liLuongToiThieu = webDriver.FindElement(By.XPath("/html/body/app-root/ng-component/div/div/div[2]/app-driver/app-driver-management-group2/div/div[2]/div/div[1]/div/p-multiselect/div/div[4]/div[2]/ul/li[4]"));
        }

        [Test, Category("DirectButtonManagement"), Order(4)]
        public void txtTimKiemMaCheck()
        {
            this.GetElement();
            pLoaiTimKiem.Click();
            Thread.Sleep(300);
            liMa.Click();
            ele = webDriver.FindElement(By.XPath("/html/body/app-root/ng-component/div/div/div[2]/app-driver/app-driver-management-group2/div/div[2]/div/div[1]/form/div/input"));
            ele.SendKeys("2");
            ele.SendKeys(Keys.Enter);
            Thread.Sleep(400);
            ele = webDriver.FindElement(By.XPath("/html/body/app-root/ng-component/div/div/div[2]/app-driver/app-driver-management-group2/div/div[2]/div/div[2]/div/p-table/div/div/table/tbody/tr/td[3]/span"));
            str = ele.Text;
            Assert.IsTrue(str.Contains("2"));
            Thread.Sleep(1000);
        }
        [Test, Category("DirectButtonManagement"), Order(5)]
        public void txtTimKiemTenCheck()
        {
            pLoaiTimKiem.Click();
            Thread.Sleep(300);
            liMa.Click();
            Thread.Sleep(300);
            liTen.Click();
            ele = webDriver.FindElement(By.XPath("/html/body/app-root/ng-component/div/div/div[2]/app-driver/app-driver-management-group2/div/div[2]/div/div[1]/form/div/input"));
            ele.SendKeys("Trần");
            ele.SendKeys(Keys.Enter);
            Thread.Sleep(400);
            ele = webDriver.FindElement(By.XPath("/html/body/app-root/ng-component/div/div/div[2]/app-driver/app-driver-management-group2/div/div[2]/div/div[2]/div/p-table/div/div/table/tbody/tr[1]/td[4]/span"));
            str = ele.Text;
            Assert.IsTrue(str.Contains("Trần"));
            Thread.Sleep(1000);
        }
        [Test, Category("DirectButtonManagement"), Order(6)]
        public void txtHangBangLaiCheck()
        {
            pLoaiTimKiem.Click();
            Thread.Sleep(300);
            liTen.Click();
            Thread.Sleep(300);
            liHangBangLai.Click();
            ele = webDriver.FindElement(By.XPath("/html/body/app-root/ng-component/div/div/div[2]/app-driver/app-driver-management-group2/div/div[2]/div/div[1]/form/div/input"));
            ele.SendKeys("B1");
            ele.SendKeys(Keys.Enter);
            ele = webDriver.FindElement(By.XPath("/html/body/app-root/ng-component/div/div/div[2]/app-driver/app-driver-management-group2/div/div[2]/div/div[2]/div/p-table/div/div/table/tbody/tr[1]/td[5]/span"));
            str = ele.Text;
            Assert.IsTrue(str.Contains("B1"));
            Thread.Sleep(1000);
        }

        [Test, Category("DirectButtonManagement"), Order(7)]
        public void txtLuongToiThieuCheck()
        {
            pLoaiTimKiem.Click();
            Thread.Sleep(300);
            liHangBangLai.Click();
            Thread.Sleep(300);
            liLuongToiThieu.Click();
            ele = webDriver.FindElement(By.XPath("/html/body/app-root/ng-component/div/div/div[2]/app-driver/app-driver-management-group2/div/div[2]/div/div[1]/form/div/input"));
            ele.SendKeys("15000000");
            ele.SendKeys(Keys.Enter);
            Thread.Sleep(1000);
        }


        [Test, Category("DirectButtonManagement"), Order(1)]
        public void btnThemMoiCheck()
        {
            this.NagativeToManagement();          
            ele = webDriver.FindElement(By.XPath("/html/body/app-root/ng-component/div/div/div[2]/app-driver/app-driver-management-group2/div/div[1]/div[1]/div/ul/li[1]"));
            ele.Click();
            ele = webDriver.FindElement(By.XPath("/html/body/app-root/ng-component/div/div/div[2]/app-driver-add/app-driver-add-group2/div/div[1]/div[2]/div/div/span[1]"));
            str = ele.Text;
            Assert.AreEqual("Thêm tài xế", str);
            webDriver.Navigate().Back();
            Thread.Sleep(300);
        }
        [Test, Category("DirectButtonManagement"), Order(2)]
        public void btnChinhSua()
        {          
            ele = webDriver.FindElement(By.XPath("/html/body/app-root/ng-component/div/div/div[2]/app-driver/app-driver-management-group2/div/div[1]/div[1]/div/ul/li[2]"));
            ele.Click();
            ele = webDriver.FindElement(By.XPath("/html/body/app-root/ng-component/div/div/div[2]/app-driver-edit/app-driver-edit-group2/div/div[1]/div[2]/div/div/span[1]"));
            str = ele.Text;
            Assert.AreEqual("Chỉnh sửa tài xế", str);
            webDriver.Navigate().Back();
            Thread.Sleep(300);
        }
        [Test, Category("DirectButtonManagement"), Order(3)]
        public void btnXoa()
        {
            ele = webDriver.FindElement(By.XPath("/html/body/app-root/ng-component/div/div/div[2]/app-driver/app-driver-management-group2/div/div[2]/div/div[2]/div/p-table/div/div/table/tbody/tr[5]/td[1]/label/span"));
            ele.Click();
            ele = webDriver.FindElement(By.XPath("/html/body/app-root/ng-component/div/div/div[2]/app-driver/app-driver-management-group2/div/div[1]/div[1]/div/ul/li[3]"));
            ele.Click();
            Thread.Sleep(200);
            ele = webDriver.FindElement(By.ClassName("swal-text"));
            str = ele.Text;
            Assert.AreEqual("Xác nhận xóa tài xế", str);
            ele = webDriver.FindElement(By.ClassName("swal-button--cancel"));
            ele.Click();
            Thread.Sleep(500);
        }
    }
}