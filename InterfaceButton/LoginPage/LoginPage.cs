using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;

namespace InterfaceButton
{
    class LoginPage
    {
        public LoginPage()
        {
            PageFactory.InitElements(Global.GlobalDefinition.driver, this);
        }


        [FindsBy(How = How.Id, Using = "UserName")]
        public IWebElement username { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement password { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/form/div/div/div/div[2]/div[3]/input")]
        public IWebElement loginBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='container']/div/div/h2")]
        public IWebElement homeMessage { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#menu-items > ul > li:nth-child(5) > a")]
        public IWebElement interfaceClick { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#menu-items > ul > li.dropdown.open > ul > li:nth-child(3) > a")]
        public IWebElement buttonsClick { get; set; }

        public void LoginSteps()
        {
            //Define Test Data Here
            string usernameInput = "Jiya";
            string passwordInput = "Jiya@345";

            //Define IWebDriver
            Global.GlobalDefinition.driver.Navigate().GoToUrl("https://demo.econz.co.nz:1000/AdminPortal/Account/Login/exptest");
            Global.GlobalDefinition.driver.Manage().Window.Maximize();

            username.SendKeys(usernameInput);
            password.SendKeys(passwordInput);
          
            String ExpectedMessage = "Welcome";

            //Handle Exception for Login Verification
            for (int i = 1; i < 2; i++)
            {
                try
                {
                    loginBtn.ClickAndWait();
                    String LoginMessage = homeMessage.Text;
                    if (LoginMessage.Equals(ExpectedMessage))
                    { Console.WriteLine("Login successfully"); }
                }
                catch (Exception) { Console.WriteLine("Exception caught!"); }
            }

            //Navigate to Interface --> Buttons Page
            interfaceClick.ClickAndWait();
            buttonsClick.ClickAndWait();


        }
    }
}
