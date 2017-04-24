using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace InterfaceButton
{

    class Program
    {
        static void Main(string[] args)
        {




        }
    }


   


    [TestFixture]
    class ButtonTest
    {
        public static ExtentReports reports;
        public static ExtentTest test;

        [SetUp]
        public void Login()
        {
            //Define report
            reports = new ExtentReports(@"C:/Users/rockymay/Documents/Visual%20Studio%202015/Projects/InterfaceButton/InterfaceButton/bin/Debug/Test.html", false, DisplayOrder.NewestFirst);

            //Define Browser and Open 
            Global.GlobalDefinition.driver = new ChromeDriver();
            LoginPage LoginObject = new LoginPage();

            LoginObject.LoginSteps();
            

        }

        [Test]
        public void AddbuttonTest()
        {
            test = reports.StartTest("Add");

            ButtonsPage ButtonObject = new ButtonsPage();
            ButtonObject.AddNewRecord();
        }

        [Test]
        public void EditbuttonTest()
        {
            test = reports.StartTest("Edit button test");
            ButtonsPage ButtonObject = new ButtonsPage();
            ButtonObject.EditExistingRecord();
        }

        [Test]
        public void DeletebyFilterRecord()
        {
            test = reports.StartTest("Delete by filter test");
            ButtonsPage ButtonObject = new ButtonsPage();
            ButtonObject.DeletebyFilterRecord();
        }

        [Test]
        public void DeletebuttonTestBySearch()
        {
            test = reports.StartTest("Delete by search test");
            ButtonsPage ButtonObject = new ButtonsPage();
            ButtonObject.DeletebySearchRecord();
        }

        [TearDown]

        public void Closing()
        {
            //Define report flush
            reports.EndTest(test);
            reports.Flush();
            
            //ButtonObject.Closing();
        }

    }


}
