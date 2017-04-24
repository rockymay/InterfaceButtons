using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using Sikuli4Net;
using Sikuli4Net.sikuli_REST;
using System.IO;

namespace InterfaceButton
{
    class LoginPage
    {

        
        public LoginPage()
        {
            PageFactory.InitElements(Global.GlobalDefinition.driver, this);

            //Populate in collection
            Global.ExcelLib.PopulateInCollection("demo.xlsx", "LoginPage");

        }

        
    
        #region load csv convert to 2-dimention list
        public List<List<string>> LoadExcel(string fileName)
        {
            //Load CSV file to console
            List<List<string>> rawData = new List<List<string>>();

            Console.WriteLine("YOU ARE RUNNING LoadCSV UNIT TEST");
            List<string> lines = File.ReadAllLines(fileName).ToList();
            int num = lines.Count();
            Console.WriteLine("Number of Records: {0}", num);
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine(lines[i]);
                List<string> line = lines[i].Split(',').ToList(); ;
                rawData.Add(line);
                int num2 = line.Count();
                Console.WriteLine("Number of Element in line {0}: {1}", (i + 1), num2);
                for (int q = 0; q < num2; q++)
                {
                    Console.WriteLine("Element {0}: {1}", (q + 1), line[q]);
                }
                Console.WriteLine("");

            }

            return rawData;
        }
        #endregion

     

        #region Login Steps
        public void LoginSteps()
        {
            //Populate in collection
            Global.ExcelLib.PopulateInCollection("demo.xlsx", "LoginPage");

            //Define IWebDriver
            Global.GlobalDefinition.driver.Navigate().GoToUrl(Global.ExcelLib.ReadData(2, "url"));
            Global.GlobalDefinition.driver.Manage().Window.Maximize();
            Console.WriteLine("");
           
            Global.GlobalDefinition.TextBox(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(2, "locator"), Global.ExcelLib.ReadData(2, "username"));
            Global.GlobalDefinition.TextBox(Global.GlobalDefinition.driver, "Id", Global.ExcelLib.ReadData(3, "locator"), Global.ExcelLib.ReadData(2, "password"));

            Global.SaveScreenShotClass.SaveScreenshot(Global.GlobalDefinition.driver, "ssLogin");
            String ExpectedMessage = "Welcome";

            //Handle Exception for Login Verification
            try
            {
                //login btn pressed, compared portal page message to verify;
                Global.GlobalDefinition.ActionButton(Global.GlobalDefinition.driver, "XPath", Global.ExcelLib.ReadData(4, "locator"));
                String LoginMessage = Global.GlobalDefinition.Label(Global.GlobalDefinition.driver, "XPath", Global.ExcelLib.ReadData(5, "locator"));
                Console.WriteLine(Global.SaveScreenShotClass.SaveScreenshot(Global.GlobalDefinition.driver, "Login"));
                if (LoginMessage.Equals(ExpectedMessage))
                { Console.WriteLine("Login successfully"); }
            }
            //Catch login error message on login page
            catch (Exception) { Console.WriteLine(Global.GlobalDefinition.Label(Global.GlobalDefinition.driver, "XPath", Global.ExcelLib.ReadData(8, "locator"))); }



            //Navigate to Interface --> Buttons Page
            //interfaceClick.ClickAndWait();
            //buttonsClick.ClickAndWait();
            Global.SaveScreenShotClass.SaveScreenshot(Global.GlobalDefinition.driver, "ssLogin");
            Global.GlobalDefinition.ActionButton(Global.GlobalDefinition.driver, "CssSelector", Global.ExcelLib.ReadData(6, "locator"));
            Global.GlobalDefinition.ActionButton(Global.GlobalDefinition.driver, "CssSelector", Global.ExcelLib.ReadData(7, "locator"));



        }
        #endregion

    }
}
