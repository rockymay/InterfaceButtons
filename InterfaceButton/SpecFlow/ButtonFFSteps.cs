using OpenQA.Selenium.Chrome;
using RelevantCodes.ExtentReports;
using System;
using TechTalk.SpecFlow;

namespace InterfaceButton.SpecFlow
{
    [Binding]
    public class ButtonFFSteps
    {

        public static ExtentReports reports;
        public static ExtentTest test;

        [Given(@"I have login successfully\.")]
        public void GivenIHaveLoginSuccessfully_()
        {
            string path = Environment.CurrentDirectory;
            string reportPath = path + "/" + "Test.html";
           reports = new ExtentReports(reportPath, false, DisplayOrder.NewestFirst);

            //Define Browser and Open 
            Global.GlobalDefinition.driver = new ChromeDriver();
            LoginPage LoginObject = new LoginPage();

            LoginObject.LoginSteps();
        }
        
        [Then(@"I woule be able to add new button successfully\.")]
        public void ThenIWouleBeAbleToAddNewButtonSuccessfully_()
        {
            test = ButtonTest.reports.StartTest("Add");

            ButtonsPage ButtonObject = new ButtonsPage();
            ButtonObject.AddNewRecord();
        }
    }
}
