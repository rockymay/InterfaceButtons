using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace InterfaceButton
{

    public static class Program
    {
        static void Main(string[] args)
        {
            //Define Browser and Open URL
            Global.GlobalDefinition.driver = new ChromeDriver();

            LoginPage LoginObject = new LoginPage();
            ButtonsPage ButtonObject = new ButtonsPage();

            LoginObject.LoginSteps();
            //ButtonObject.AddNewRecord();
            //ButtonObject.EditExistingRecord();
            ButtonObject.DeleteRecord();


        }
    }
}
