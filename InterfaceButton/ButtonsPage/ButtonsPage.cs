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
        public ButtonsPage()
        {
            PageFactory.InitElements(Global.GlobalDefinition.driver, this);
        }



        [FindsBy(How = How.Name, Using = "BTN_NAME")]
        public IWebElement btnNameTextBox { get; set; }

        [FindsBy(How = How.Name, Using = "BTN_DISPLAY_TITLE")]
        public IWebElement btnDisplayNameTextBox { get; set; }

        [FindsBy(How = How.Name, Using = "PRE_CONDITION")]
        public IWebElement preCdtnTextBox { get; set; }

        [FindsBy(How = How.Name, Using = "VALUE_UPDATES")]
        public IWebElement valueUpdateTextBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='grid']/div[1]/a")]
        public IWebElement addNewRecordBtn { get; set; }

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

            List<string> addNewRecord = new List<string>();
            addNewRecord.Add("CheckButtonName");
            addNewRecord.Add("CheckButtonDisplayTitle");
            addNewRecord.Add("CheckPreCondition");
            addNewRecord.Add("CheckValueUpdate");

            //#######Add New Record Test Here########
            addNewRecordBtn.ClickAndWait();

            //TextBox input
            btnNameTextBox.EnterValue(addNewRecord[0]);
            btnDisplayNameTextBox.EnterValue(addNewRecord[1]);
            preCdtnTextBox.EnterValue(addNewRecord[2]);
            valueUpdateTextBox.EnterValue(addNewRecord[3]);

            //Use DropdownSelect to Repeat Dropdown Selection
            DropdownSelect(Global.GlobalDefinition.driver);

            for (int i = 1; i < 2; i++)
            {
                try
                {
                    createBtn.Click();
                    Global.GlobalDefinition.driver.SwitchTo().Alert().Dismiss();
                }
                catch (Exception) { Console.WriteLine("Exception caught!"); }
            }

            Global.GlobalDefinition.driver.Navigate().Refresh();

            //Use VerifyResult to Verify Record Change

            filterIcon.ClickAndWait();
            filterTextBox.SendKeys(addNewRecord[0]);
            filterBtn.ClickAndWait();


            VerifyResult(Global.GlobalDefinition.driver, addNewRecord, "Add New Record", "AddUpdate");


        }

        public void EditExistingRecord()
        {
            List<string> updateRecord = new List<string>();
            updateRecord.Add("update");
            updateRecord.Add("update2");
            updateRecord.Add("update3");
            updateRecord.Add("update4");

            //NOT FINISHED


            filterIcon.ClickAndWait();
            filterTextBox.SendKeys("CheckButtonName");
            filterBtn.ClickAndWait();

            editBtnAfterFilter.ClickAndWait();

            btnNameTextBox.EnterValue(updateRecord[0]);
            btnDisplayNameTextBox.EnterValue(updateRecord[1]);
            preCdtnTextBox.EnterValue(updateRecord[2]);
            valueUpdateTextBox.EnterValue(updateRecord[3]);

            DropdownSelect(Global.GlobalDefinition.driver);


            updateBtnClick.Click();

            try
            {
                updateBtnClick.Click();

                Global.GlobalDefinition.driver.SwitchTo().Alert().Dismiss();
            }
            catch (Exception) { Console.WriteLine("Exception caught!"); }


      

            Global.GlobalDefinition.driver.Navigate().Refresh();

            //Use VerifyResult to Verify Record Change

            filterIcon.ClickAndWait();
            filterTextBox.SendKeys(updateRecord[0]);
            filterBtn.ClickAndWait();

            VerifyResult(Global.GlobalDefinition.driver, updateRecord,"Add New Record", "AddUpdate");



        }

        public void DeleteRecord()
        {


            //######## Delete Function Test Here#########
            //Filter(driver, "a");
            //filterIcon.ClickAndWait();
           // filterTextBox.SendKeys("update");
           // filterBtn.ClickAndWait();


            //Option2, Search for Specific Page
            string keyName = "Yarun";

            int numPage = Global.GlobalDefinition.driver.FindElements(By.XPath("//*[@id='grid']/div[5]/ul/li")).Count();
            Console.WriteLine("Number of Pages: {0}", numPage);
           
            for (int pageIndex = 1; pageIndex <numPage+1; pageIndex++)
            {
                Console.WriteLine("");
                Console.WriteLine("Page " + pageIndex);
                int numElement = Global.GlobalDefinition.driver.FindElements(By.XPath("//*[@id='grid']/div[4]/table/tbody/tr/td[1]")).Count();
                Console.WriteLine("Numbers of items : {0}", numElement);

                for (int i = 1; i <= numElement; i++)
                {
                    
                    string firstText = Global.GlobalDefinition.driver.FindElement(By.CssSelector("#grid > div.k-grid-content > table > tbody > tr:nth-child(" + i + ") > td:nth-child(1)")).Text;
                    Console.WriteLine("Line "+ i + ": " + firstText);
                    if (firstText.Equals(keyName))
                    {
                        Console.WriteLine("Congratulations, the item is at Page {0}, Line {1}", pageIndex,i);
                        Global.GlobalDefinition.driver.FindElement(By.CssSelector("#grid > div.k-grid-content > table > tbody > tr:nth-child(" + i + ") > td:nth-child(14) > a.k-button.k-button-icontext.k-grid-edit")).ClickAndWait();
                        break;
                    }

                  
                }

                try { Global.GlobalDefinition.driver.FindElement(By.XPath("//*[@id='grid']/div[5]/ul/li[" + (pageIndex+1) + "]")).ClickAndWait(); }
                catch (Exception)   {
                    Console.WriteLine("Exception Expected Here");}
                   
                    

               
                
            }
           
/*



            //Save Selected Record into deleteRecord 
            List<string> deleteRecord = new List<string>();

                deleteRecord.Add(firstRecordAfterFilterValue01.Text);
            deleteRecord.Add(firstRecordAfterFilterValue02.Text);
            deleteRecord.Add(firstRecordAfterFilterValue03.Text);
            deleteRecord.Add(firstRecordAfterFilterValue04.Text);
            Console.WriteLine("You are trying to delet button: {0},  {1},  {2} {3}", deleteRecord[0], deleteRecord[1], deleteRecord[2], deleteRecord[3]);

            deleteBtnAfterFilter.ClickAndWait();
            //Delete Action Confirm
            deleteConfirmBtn.ClickAndWait();

            //Verify Deletion Successful
            filterIcon.ClickAndWait();
            filterTextBox.SendKeys(deleteRecord[0]);
            filterBtn.ClickAndWait();

            VerifyResult(Global.GlobalDefinition.driver, deleteRecord, "Delete Existing Record", "Del");


            //#######Closing Browser######
            //Refresh page
            Global.GlobalDefinition.driver.Navigate().Refresh();
            //driver.Close();
            //driver.Quit();
     
        */
           }
        private void DropdownSelect(IWebDriver driver)
        {
            Random rnd = new Random();
            //define Double Click Functions
            Func<IWebElement, bool> func = new Func<IWebElement, bool>((IWebElement element) =>
            {
                for (int i = 1; i < 3; i++)
                {
                    try { element.Click(); }
                    catch (Exception) { Console.WriteLine("Exception caught!"); }
                }
                return true;
            });

            //ButtonLogo
            driver.FindElement(By.CssSelector("body > div.k-widget.k-window > div.k-popup-edit-form.k-window-content.k-content > div > div:nth-child(6) > span > span > span.k-input")).ClickAndWait();
            int optionNum = (driver.FindElement(By.CssSelector("body > div.k-animation-container.km-popup > div > ul"))).FindElements(By.ClassName("k-item")).Count;
            Console.WriteLine(optionNum);
            string ButtonLogoCSS = "body > div.k-animation-container.km-popup > div > ul > li:nth-child(" + (rnd.Next(2, optionNum)) + ")";
            func(driver.FindElement(By.CssSelector(ButtonLogoCSS)));

            //NextScreen
            driver.FindElement(By.CssSelector("body > div.k-widget.k-window > div.k-popup-edit-form.k-window-content.k-content > div > div:nth-child(10) > span > span > span.k-input")).ClickAndWait();
            int optionNumNextScreen = (driver.FindElement(By.CssSelector("#NEXT_SCREEN_DBID_listbox"))).FindElements(By.ClassName("k-item")).Count;
            Console.WriteLine(optionNumNextScreen);
            string NextScreenXPath = "//*[@id='NEXT_SCREEN_DBID_listbox']/li[" + (rnd.Next(2, optionNumNextScreen)) + "]";
            func(driver.FindElement(By.XPath(NextScreenXPath)));

            //NextState
            driver.FindElement(By.CssSelector("body > div.k-widget.k-window > div.k-popup-edit-form.k-window-content.k-content > div > div:nth-child(14) > span > span > span.k-input")).ClickAndWait();
            int optionNumNextState = (driver.FindElement(By.CssSelector("#NEXT_STATE_DBID_listbox"))).FindElements(By.ClassName("k-item")).Count;
            Console.WriteLine(optionNumNextState);
            string NextStateXPath = "//*[@id='NEXT_STATE_DBID_listbox']/li[" + (rnd.Next(2, optionNumNextState)) + "]";
            func(driver.FindElement(By.XPath(NextStateXPath)));

            //PendingState
            driver.FindElement(By.CssSelector("body > div.k-widget.k-window > div.k-popup-edit-form.k-window-content.k-content > div > div:nth-child(16) > span > span > span.k-input")).ClickAndWait();
            int optionNumPendingState = (driver.FindElement(By.CssSelector("#PENDING_STATE_DBID_listbox"))).FindElements(By.ClassName("k-item")).Count;
            string PendingStateXPath = "//*[@id='PENDING_STATE_DBID_listbox']/li[" + (rnd.Next(2, optionNumPendingState)) + "]";
            Console.WriteLine(optionNumPendingState);
            func(driver.FindElement(By.XPath(PendingStateXPath)));

            //EntityType
            driver.FindElement(By.CssSelector("body > div.k-widget.k-window > div.k-popup-edit-form.k-window-content.k-content > div > div:nth-child(18) > span > span > span.k-input")).ClickAndWait();
            int optionNumEntityType = (driver.FindElement(By.CssSelector("#ETT_DBID_listbox"))).FindElements(By.ClassName("k-item")).Count;
            Console.WriteLine(optionNumEntityType);
            string EntityTypeCSS = "#ETT_DBID_listbox > li:nth-child(" + (rnd.Next(2, optionNumEntityType)) + ")";
            func(driver.FindElement(By.CssSelector(EntityTypeCSS)));

           

        }


        //Verify Filter Result
        private void VerifyResult(IWebDriver driver, List<string> newValue, string message, string AddorDel)
        {
            
            string expectMessage = "No items to display";
            string actualMessagge = rightPagenation.Text;

            Console.WriteLine(actualMessagge);

            //Delete and Add/Edit Verification is Different
            switch (AddorDel)
            {
                case "Del":

                    
                    if (expectMessage.Equals(actualMessagge))

                    //Compare Filter Result Pagenotation Message
                    { Console.WriteLine(message + " function test passed!"); }

                    //When There Are Two or More Buttons With Same Button Name.
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
                                Console.WriteLine(message + " function test FAILED!!!!!");
                                Console.WriteLine("There might be duplicate records, delete them and retry again");
                            }
                            else { Console.WriteLine(message + " function test pass!!!!!"); }
                        }
                    }
                    break;

                case ("AddUpdate"):
                    //Save Filter Result Value
                    if (expectMessage.Equals(actualMessagge))

                    //Compare Filter Result Pagenotation Message
                    { Console.WriteLine(message + " function test Failed! Update is not successful"); }

                    else
                    {
                        Console.WriteLine("The update data is:");
                        Console.WriteLine(newValue[0]);
                        Console.WriteLine(newValue[1]);
                        Console.WriteLine(newValue[2]);
                        Console.WriteLine(newValue[3]);

                        string result1 = firstRecordAfterFilterValue01.Text;
                        string result2 = firstRecordAfterFilterValue02.Text;
                        string result3 = firstRecordAfterFilterValue03.Text;
                        string result4 = firstRecordAfterFilterValue04.Text;

                        Console.WriteLine("The  data is:");
                        Console.WriteLine(result1);
                        Console.WriteLine(result2);
                        Console.WriteLine(result3);
                        Console.WriteLine(result4);

                        if (result1.Equals(newValue[0]) && result2.Equals(newValue[1]) && result3.Equals(newValue[2]) && result4.Equals(newValue[3]))
                        { Console.WriteLine(message + " function test passed!"); }
                        else
                        {
                            Console.WriteLine(message + " function test FAILED! There might be more than two buttons with same name");
                        }
                    }

                    

                    //Compare the UpdateValue and Filter Result
                    
                    break;

                default: break;
            }
            driver.Navigate().Refresh();
        }

    }
}
