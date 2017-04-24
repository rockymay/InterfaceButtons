using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InterfaceButton
{
    class ButtonsPage
    {

        string expectMessage = "No items to display";


        public ButtonsPage()
        {
            PageFactory.InitElements(Global.GlobalDefinition.driver, this);
            //Global.ExcelLib.PopulateInCollection("demo.xlsx", "testData");
        }
      

        //[FindsBy(How = How.Name, Using = "BTN_NAME")]
        //public IWebElement btnNameTextBox { get; set; }

        //[FindsBy(How = How.Name, Using = "BTN_DISPLAY_TITLE")]
        //public IWebElement btnDisplayNameTextBox { get; set; }

        //[FindsBy(How = How.Name, Using = "PRE_CONDITION")]
        //public IWebElement preCdtnTextBox { get; set; }

        //[FindsBy(How = How.Name, Using = "VALUE_UPDATES")]
        //public IWebElement valueUpdateTextBox { get; set; }
      
        //[FindsBy(How = How.XPath, Using = "//*[@id='grid']/div[1]/a")]
        //public IWebElement addNewRecordBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[6]/div[2]/div/div[27]/a[1]")]
        public IWebElement createBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='grid']/div[3]/div/table/thead/tr/th[1]/a[1]/span")]
        public IWebElement filterIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[5]/form/div[1]/input[1]")]
        public IWebElement filterTextBox { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[5]/form/div[1]/div[2]/button[1]")]
        public IWebElement filterBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='grid']/div[4]/table/tbody/tr[1]/td[14]/a[1]")]
        public IWebElement editBtnAfterFilter { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.k-widget.k-window > div.k-popup-edit-form.k-window-content.k-content > div > div.k-edit-buttons.k-state-default > a.k-button.k-button-icontext.k-grid-update")]
        public IWebElement updateBtnClick { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='grid']/div[4]/table/tbody/tr[1]/td[1]")]
        public IWebElement firstRecordAfterFilterValue01 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='grid']/div[4]/table/tbody/tr[1]/td[2]")]
        public IWebElement firstRecordAfterFilterValue02 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='grid']/div[4]/table/tbody/tr[1]/td[4]")]
        public IWebElement firstRecordAfterFilterValue03 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='grid']/div[4]/table/tbody/tr[1]/td[6]")]
        public IWebElement firstRecordAfterFilterValue04 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='grid']/div[4]/table/tbody/tr[1]/td[14]/a[2]")]
        public IWebElement deleteBtnAfterFilter { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='container']/div/form/div/input")]
       
        public IWebElement deleteConfirmBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#grid > div.k-pager-wrap.k-grid-pager.k-widget > span.k-pager-info.k-label")]
        public IWebElement rightPagenation { get; set; }

        public void AddNewRecord ()
        {
            //Define report test
            ButtonTest.test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Click on UI");

            //Populate in collection
            Global.ExcelLib.PopulateInCollection("demo.xlsx", "buttonsPage");

            List<string> addNewRecord = new List<string>();
            addNewRecord.Add(Global.ExcelLib.ReadData(2, "newData"));
            addNewRecord.Add(Global.ExcelLib.ReadData(3, "newData"));
            addNewRecord.Add(Global.ExcelLib.ReadData(4, "newData"));
            addNewRecord.Add(Global.ExcelLib.ReadData(5, "newData"));

            //#######Add New Record Test Here########
            //addNewRecordBtn.Click();
            Global.GlobalDefinition.ActionButton(Global.GlobalDefinition.driver, "XPath", (Global.ExcelLib.ReadData(2, "button")));

            //TextBox input
            //btnNameTextBox.SendKeys(addNewRecord[0]);
            //btnDisplayNameTextBox.SendKeys(addNewRecord[1]);
            //preCdtnTextBox.SendKeys(addNewRecord[2]);
            //valueUpdateTextBox.SendKeys(addNewRecord[3]);
            Global.GlobalDefinition.TextBox(Global.GlobalDefinition.driver, "Name", (Global.ExcelLib.ReadData(2, "textbox")), addNewRecord[0]);
            Global.GlobalDefinition.TextBox(Global.GlobalDefinition.driver, "Name", (Global.ExcelLib.ReadData(3, "textbox")), addNewRecord[1]);
            Global.GlobalDefinition.TextBox(Global.GlobalDefinition.driver, "Name", (Global.ExcelLib.ReadData(4, "textbox")), addNewRecord[2]);
            Global.GlobalDefinition.TextBox(Global.GlobalDefinition.driver, "Name", (Global.ExcelLib.ReadData(5, "textbox")), addNewRecord[3]);



            //Use DropdownSelect to Repeat Dropdown Selection
            DropdownSelect(Global.GlobalDefinition.driver);

            for (int i = 1; i < 2; i++)
            {
                try
                {
                    createBtn.Click();
                    Thread.Sleep(500);
                    string message = "Error: The Button Name already exists, Please create a new one";
                    string alertMessage = Global.GlobalDefinition.driver.SwitchTo().Alert().Text;

                    if (message.Equals(alertMessage))
                    {
                        Console.WriteLine("Duplicates!!!!! Try another test data set.");
                        ButtonTest.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Duplicates!!!!! Try another test data set");
                        Global.GlobalDefinition.driver.SwitchTo().Alert().Dismiss();
                        break;
                    }
                    else
                    {
                        Global.GlobalDefinition.driver.SwitchTo().Alert().Dismiss();
                    }
                }
                catch (Exception) { Console.WriteLine("Exception caught!"); }
            }

            Global.GlobalDefinition.driver.Navigate().Refresh();

            //Use VerifyResult to Verify Record Change
            VerifyResult(Global.GlobalDefinition.driver, addNewRecord, "Add New Record", "AddUpdate");


        }

        public void EditExistingRecord()
        {
            //Populate in collection
            Global.ExcelLib.PopulateInCollection("demo.xlsx", "testData");

            List<string> updateRecord = new List<string>();
            updateRecord.Add(Global.ExcelLib.ReadData(2, "update01"));
            updateRecord.Add(Global.ExcelLib.ReadData(2, "update02"));
            updateRecord.Add(Global.ExcelLib.ReadData(2, "update03"));
            updateRecord.Add(Global.ExcelLib.ReadData(2, "update04"));
            filterIcon.Click();
            Thread.Sleep(500);
            filterTextBox.SendKeys(Global.ExcelLib.ReadData(2, "add01"));
            filterBtn.Click();
            Thread.Sleep(500);

            editBtnAfterFilter.Click();
            Thread.Sleep(500);

            //btnNameTextBox.Clear();
            //btnNameTextBox.SendKeys(updateRecord[0]);
            //btnDisplayNameTextBox.Clear();
            //btnDisplayNameTextBox.SendKeys(updateRecord[1]);
            //preCdtnTextBox.Clear();
            //preCdtnTextBox.SendKeys(updateRecord[2]);
            //valueUpdateTextBox.Clear();
            //valueUpdateTextBox.SendKeys(updateRecord[3]);

            Global.GlobalDefinition.TextBox(Global.GlobalDefinition.driver, "Name", (Global.ExcelLib.ReadData(2, "textbox")), updateRecord[0]);
            Global.GlobalDefinition.TextBox(Global.GlobalDefinition.driver, "Name", (Global.ExcelLib.ReadData(3, "textbox")), updateRecord[1]);
            Global.GlobalDefinition.TextBox(Global.GlobalDefinition.driver, "Name", (Global.ExcelLib.ReadData(4, "textbox")), updateRecord[2]);
            Global.GlobalDefinition.TextBox(Global.GlobalDefinition.driver, "Name", (Global.ExcelLib.ReadData(5, "textbox")), updateRecord[3]);


            DropdownSelect(Global.GlobalDefinition.driver);

            try
            {
                updateBtnClick.Click();
                Thread.Sleep(500);

                Global.GlobalDefinition.driver.SwitchTo().Alert().Dismiss();
            }
            catch (Exception) { Console.WriteLine("Exception caught!"); }


      

            Global.GlobalDefinition.driver.Navigate().Refresh();

            //Use VerifyResult to Verify Record 

            VerifyResult(Global.GlobalDefinition.driver, updateRecord, "Update", "AddUpdate");



        }

        public void DeletebyFilterRecord()
        {

            string deleteRecordText = Global.ExcelLib.ReadData(2,"newRecord");
            //######## Delete Function Test Here#########


            filterIcon.Click();
            Thread.Sleep(500);
            filterTextBox.SendKeys(deleteRecordText);
            filterBtn.Click();
            Thread.Sleep(500);


            string actualMessagge = rightPagenation.Text;
            if (expectMessage.Equals(actualMessagge))

            //Compare filter pagenation message
            {
                Console.WriteLine(" Sorry, there is no such record as: {0}", deleteRecordText);
            }

            //When there are two or more items with same button name.
            else
            {
                //Save selected record
                List<string> deleteRecord = new List<string>();
                deleteRecord.Add(firstRecordAfterFilterValue01.Text);
                deleteRecord.Add(firstRecordAfterFilterValue02.Text);
                deleteRecord.Add(firstRecordAfterFilterValue03.Text);
                deleteRecord.Add(firstRecordAfterFilterValue04.Text);
                Console.WriteLine("You are trying to delet button: {0},  {1},  {2} {3}", deleteRecord[0], deleteRecord[1], deleteRecord[2], deleteRecord[3]);

                deleteBtnAfterFilter.Click();
                Thread.Sleep(500);
                //Delete action confirmation
                deleteConfirmBtn.Click();
                Thread.Sleep(500);
                //Verify 
                VerifyResult(Global.GlobalDefinition.driver, deleteRecord, "Delete Existing Record", "Del");
            }

             
        
           }

        public void DeletebySearchRecord()
        {
            string deleteRecordText = Global.ExcelLib.ReadData(2, "newRecord");
            //Locate the record
            int numPage = Global.GlobalDefinition.driver.FindElements(By.XPath("//*[@id='grid']/div[5]/ul/li")).Count();
            Console.WriteLine("Number of Pages: {0}", numPage);

            //Define delete record string array
            List<string> deleteRecord = new List<string>();

            for (int pageIndex = 1; pageIndex < numPage + 1; pageIndex++)
            {
                
                Console.WriteLine("");
                Console.WriteLine("Page " + pageIndex);
                int numElement = Global.GlobalDefinition.driver.FindElements(By.XPath("//*[@id='grid']/div[4]/table/tbody/tr/td[1]")).Count();
                Console.WriteLine("Numbers of items : {0}", numElement);

                for (int i = 1; i <= numElement; i++)
                {

                    string firstText = Global.GlobalDefinition.driver.FindElement(By.CssSelector("#grid > div.k-grid-content > table > tbody > tr:nth-child(" + i + ") > td:nth-child(1)")).Text;
                    Console.WriteLine("Line " + i + ": " + firstText);
                    if (firstText.Equals(deleteRecordText))
                    {
                        Console.WriteLine("Congratulations, the item is at Page {0}, Line {1}", pageIndex, i);
                        deleteRecord.Add(Global.GlobalDefinition.driver.FindElement(By.XPath("//*[@id='grid']/div[4]/table/tbody/tr[" + i + "]/td[1]")).Text);
                        deleteRecord.Add(Global.GlobalDefinition.driver.FindElement(By.XPath("//*[@id='grid']/div[4]/table/tbody/tr[" + i + "]/td[2]")).Text);
                        deleteRecord.Add(Global.GlobalDefinition.driver.FindElement(By.XPath("//*[@id='grid']/div[4]/table/tbody/tr[" + i + "]/td[4]")).Text);
                        deleteRecord.Add(Global.GlobalDefinition.driver.FindElement(By.XPath("//*[@id='grid']/div[4]/table/tbody/tr[" + i + "]/td[6]")).Text);
                        Global.GlobalDefinition.driver.FindElement(By.CssSelector("#grid > div.k-grid-content > table > tbody > tr:nth-child(" + i + ") > td:nth-child(14) > a.k-button.k-button-icontext.k-grid-Delete")).Click();
                        Thread.Sleep(500);
                        break;
                    }


                }

                try { Global.GlobalDefinition.driver.FindElement(By.XPath("//*[@id='grid']/div[5]/ul/li[" + (pageIndex + 1) + "]")).Click(); }
                catch (Exception)
                {
                    Console.WriteLine("Exception Expected Here");
                }

            }

            //Delete Record
            //Save selected record
            
            
            Console.WriteLine("You are trying to delet button: {0},  {1},  {2} {3}", deleteRecord[0], deleteRecord[1], deleteRecord[2], deleteRecord[3]);


            //Delete action confirmation
            deleteConfirmBtn.Click();
            Thread.Sleep(500);

            //Verify deletion


            VerifyResult(Global.GlobalDefinition.driver, deleteRecord, "Delete Existing Record", "Del");


        }

        #region Dropdown Method
        private void DropdownSelect(IWebDriver driver)
        {
            Random rnd = new Random();
            //Define double click
            Func<IWebElement, bool> func = new Func<IWebElement, bool>((IWebElement element) =>
            {
                //Try to click dropdown elements twice.
                for (int i = 1; i < 3; i++)
                {
                    try { element.Click(); Thread.Sleep(500); }
                    catch (Exception) { Console.WriteLine("Exception caught!"); }
                }
                return true;
            });

            //ButtonLogo
            driver.FindElement(By.CssSelector("body > div.k-widget.k-window > div.k-popup-edit-form.k-window-content.k-content > div > div:nth-child(6) > span > span > span.k-input")).Click();
            Thread.Sleep(500);
            int optionNum = (driver.FindElement(By.CssSelector("body > div.k-animation-container.km-popup > div > ul"))).FindElements(By.ClassName("k-item")).Count;
            Console.WriteLine("Number of Dropdown is: {0}", optionNum);
            string ButtonLogoCSS = "body > div.k-animation-container.km-popup > div > ul > li:nth-child(" + (rnd.Next(2, optionNum)) + ")";
            func(driver.FindElement(By.CssSelector(ButtonLogoCSS)));

            //NextScreen
            driver.FindElement(By.CssSelector("body > div.k-widget.k-window > div.k-popup-edit-form.k-window-content.k-content > div > div:nth-child(10) > span > span > span.k-input")).Click();
            Thread.Sleep(500);
            int optionNumNextScreen = (driver.FindElement(By.CssSelector("#NEXT_SCREEN_DBID_listbox"))).FindElements(By.ClassName("k-item")).Count;
            Console.WriteLine("Number of Dropdown is: {0}", optionNumNextScreen);
            string NextScreenXPath = "//*[@id='NEXT_SCREEN_DBID_listbox']/li[" + (rnd.Next(2, optionNumNextScreen)) + "]";
            func(driver.FindElement(By.XPath(NextScreenXPath)));

            //NextState
            driver.FindElement(By.CssSelector("body > div.k-widget.k-window > div.k-popup-edit-form.k-window-content.k-content > div > div:nth-child(14) > span > span > span.k-input")).Click();
            Thread.Sleep(500);
            int optionNumNextState = (driver.FindElement(By.CssSelector("#NEXT_STATE_DBID_listbox"))).FindElements(By.ClassName("k-item")).Count;
            Console.WriteLine("Number of Dropdown is: {0}", optionNumNextState);
            string NextStateXPath = "//*[@id='NEXT_STATE_DBID_listbox']/li[" + (rnd.Next(2, optionNumNextState)) + "]";
            func(driver.FindElement(By.XPath(NextStateXPath)));

            //PendingState
            driver.FindElement(By.CssSelector("body > div.k-widget.k-window > div.k-popup-edit-form.k-window-content.k-content > div > div:nth-child(16) > span > span > span.k-input")).Click();
            int optionNumPendingState = (driver.FindElement(By.CssSelector("#PENDING_STATE_DBID_listbox"))).FindElements(By.ClassName("k-item")).Count;
            Thread.Sleep(500);
            string PendingStateXPath = "//*[@id='PENDING_STATE_DBID_listbox']/li[" + (rnd.Next(2, optionNumPendingState)) + "]";
            Console.WriteLine("Number of Dropdown is: {0}", optionNumPendingState);
            func(driver.FindElement(By.XPath(PendingStateXPath)));

            //EntityType
            driver.FindElement(By.CssSelector("body > div.k-widget.k-window > div.k-popup-edit-form.k-window-content.k-content > div > div:nth-child(18) > span > span > span.k-input")).Click();
            Thread.Sleep(500);
            int optionNumEntityType = (driver.FindElement(By.CssSelector("#ETT_DBID_listbox"))).FindElements(By.ClassName("k-item")).Count;
            Console.WriteLine("Number of Dropdown is: {0}", optionNumEntityType);
            string EntityTypeCSS = "#ETT_DBID_listbox > li:nth-child(" + (rnd.Next(2, optionNumEntityType)) + ")";
            func(driver.FindElement(By.CssSelector(EntityTypeCSS)));
        }
        #endregion

        //Verify filter result
        private void VerifyResult(IWebDriver driver, List<string> newValue, string message, string AddorDel)
        {
            filterIcon.Click();
            Thread.Sleep(500);
            filterTextBox.SendKeys(newValue[0]);
            filterBtn.Click();
            Thread.Sleep(500);


            int numOfFilterResult = Global.GlobalDefinition.driver.FindElements(By.XPath("//*[@id='grid']/div[4]/table/tbody/tr")).Count();
            Console.WriteLine("Number of Filter Result: {0} ", numOfFilterResult);

            string actualMessagge = rightPagenation.Text;

            Console.WriteLine(actualMessagge);

            //Delete and add/update 
            switch (AddorDel)
            {
                case "Del":

                    if (expectMessage.Equals(actualMessagge))

                    //Compare filter pagenation message
                    {
                        Console.WriteLine("Congratulation!  " + message + " function test pass!"); 
                        ButtonTest.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, message);
                    }

                    //When there are two or more items with same button name.
                    else
                    {

                        for (int i = 1; i < 2; i++)
                        {
                            string resultBtnNm = firstRecordAfterFilterValue01.Text;
                            string resultBtnTt = firstRecordAfterFilterValue02.Text;
                            string resultPreCdt = firstRecordAfterFilterValue03.Text;
                            string resultVaUpdt = firstRecordAfterFilterValue04.Text;

                            if (resultBtnNm.Equals(newValue[0]) && resultBtnTt.Equals(newValue[1]) && resultPreCdt.Equals(newValue[2]) && resultVaUpdt.Equals(newValue[3]))
                            {
                                Console.WriteLine("WARNING!  " + message + " function test FAILED!!!!!");
                                ButtonTest.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, message);
                                Console.WriteLine("There might be duplicate records, delete them and retry again");
                            }
                            else {
                                Console.WriteLine("Congratulation!  " + message + " function test pass!!!!!");
                                ButtonTest.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, message);
                            }
                        }
                    }
                    break;

                case ("AddUpdate"):
                    //Save filter result value
                    if (expectMessage.Equals(actualMessagge))

                    //Compare filter pagenation message
                    {
                        Console.WriteLine("WARNING!  " + message + " function test Failed! ");
                        ButtonTest.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, message);
                    }

                    else
                    {

                        //Count number of records
                     

                        Console.WriteLine("The update data is:");
                        Console.WriteLine(newValue[0]);
                        Console.WriteLine(newValue[1]);
                        Console.WriteLine(newValue[2]);
                        Console.WriteLine(newValue[3]);

                        for (int i=1; i<=numOfFilterResult; i++)
                        {
                            string result1 = Global.GlobalDefinition.driver.FindElement(By.XPath("//*[@id='grid']/div[4]/table/tbody/tr[" + i + "]/td[1]")).Text;
                            string result2 = Global.GlobalDefinition.driver.FindElement(By.XPath("//*[@id='grid']/div[4]/table/tbody/tr[" + i + "]/td[2]")).Text;
                            string result3 = Global.GlobalDefinition.driver.FindElement(By.XPath("//*[@id='grid']/div[4]/table/tbody/tr[" + i + "]/td[4]")).Text;
                            string result4 = Global.GlobalDefinition.driver.FindElement(By.XPath("//*[@id='grid']/div[4]/table/tbody/tr[" + i + "]/td[6]")).Text;
                            Console.WriteLine("The filter result data line {0} is:", i);
                            Console.WriteLine(result1);
                            Console.WriteLine(result2);
                            Console.WriteLine(result3);
                            Console.WriteLine(result4);
                            //Compare the filter result with add/update value
                            if (result1.Equals(newValue[0]) && result2.Equals(newValue[1]) && result3.Equals(newValue[2]) && result4.Equals(newValue[3]))
                            {
                                Console.WriteLine(message + " function test passed!");
                                ButtonTest.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, message);
                                break;
                            }
                        }
                        //Console.WriteLine(message + " function test FAILED! There might be more than two buttons with same name");
                    }
                    
                    break;

                default: break;
            }
            driver.Navigate().Refresh();
        }

        public void Closing()
        {

            //#######Closing Browser######
            //Refresh page
            Global.GlobalDefinition.driver.Navigate().Refresh();
            Global.GlobalDefinition.driver.Close();
            //driver.Quit();
        }
    }
}
