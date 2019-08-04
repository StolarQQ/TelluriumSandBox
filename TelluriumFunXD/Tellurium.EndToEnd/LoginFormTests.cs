using System.IO;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using Tellurium.MvcPages;
using Tellurium.MvcPages.BrowserCamera;
using Tellurium.MvcPages.BrowserCamera.Lens;
using Tellurium.MvcPages.Configuration;
using Tellurium.MvcPages.SeleniumUtils;
using Tellurium.Web.Controllers;
using TestContext = NUnit.Framework.TestContext;

namespace Tellurium.EndToEnd
{
    [TestFixture]
    public class LoginFormTests
    {
        [Test]
        public void TestMethod1()
        {
            var browserAdapterConfig = new BrowserAdapterConfig
            {
                BrowserType = BrowserType.Chrome,
                SeleniumDriversPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Drivers"),
                PageUrl = "http://executeautomation.com",
                ErrorScreenshotsPath = @"c:\selenium\",
                BrowserDimensions = new BrowserDimensionsConfig
                {
                    Width = 1200,
                    Height = 768
                },
                BrowserCameraConfig = new BrowserCameraConfig
                {
                    LensType = LensType.Regular
                }
            };

            using (var browser = BrowserAdapter.Create(browserAdapterConfig))
            {
                browser.NavigateTo("/demosite/Login.html");
                //browser.NavigateTo<HomeController>(c => c.Index());
                //browser.RefreshPage();
                var loginForm = browser.GetForm("userName");
                loginForm.SetFieldValue("UserName", "abc123");
                loginForm.SetFieldValue("Password", "secret123");
                loginForm.ClickOnElementWithText("Login");
                browser.RefreshPage();
                
                //var detinationForm = browserAdapter.GetForm<SampleFormViewModel>(FormsIds.TestFormDst);
                var userForm = browser.GetForm("details");
                userForm.SetFieldValue("Initial", "test1");
                userForm.SetFieldValue("FirstName", "test2");
                userForm.SetFieldValue("MiddleName", "test3");


                userForm.Click();
                userForm.ClickOnElementWithText("Select");
                userForm.Click();
                userForm.ClickOnElementWithText("TitleId");

                //userForm.ClickOnElementWithText("Select");

                userForm.ClickOnElementWithText("Save");

                //browser.Wait(5000);
            }
        }

        [Test]
        public void Selenium_demo()
        {
            var driverPath = "F://";
            var driver = new ChromeDriver(driverPath);
            var pageUrl = "http://executeautomation.com/demosite/Login.html";
            driver.Navigate().GoToUrl(pageUrl);
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void should_be_able_to_fullFill_test_form()
        {
            var browserAdapterConfig = new BrowserAdapterConfig
            {
                BrowserType = BrowserType.Chrome,
                SeleniumDriversPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Drivers"),
                PageUrl = "http://localhost:52045",
                ErrorScreenshotsPath = @"c:\selenium\",
                BrowserDimensions = new BrowserDimensionsConfig
                {
                    Width = 1200,
                    Height = 768
                },
                BrowserCameraConfig = new BrowserCameraConfig
                {
                    LensType = LensType.Regular
                }
            };

            using (var browser = BrowserAdapter.Create(browserAdapterConfig))
            {

                browser.NavigateTo<HomeController>(x => x.Index());
                browser.ClickOnElementWithText("Register");
                var regForm = browser.GetForm("register");                
                regForm.SetFieldValue("Email", "stolar@o2.pl");
                regForm.SetFieldValue("Password", "Abc123!");
                regForm.SetFieldValue("ConfirmPassword", "Abc123!");
                //regForm.ClickOnElementWithText("Register");
                browser.ClickOnElementWithText("Home");
               // browser.ClickOnElementWithText("Learn more »");
                browser.ClickOnElementWithText("Open Modal");
                browser.Wait(1);
                var modal = browser.GetPageFragmentById("form-group");
                modal.SetFieldValueByLabel("Email.form-control", "XD");
                


                //browser.ClickOnElementWithText("Submit");

                
                browser.ClickOnElementWithText("Open Modal");



                browser.Wait(5);
                //browser.RefreshPage();

                //var detinationForm = browserAdapter.GetForm<SampleFormViewModel>(FormsIds.TestFormDst);
             
            }

        }
    }
}
