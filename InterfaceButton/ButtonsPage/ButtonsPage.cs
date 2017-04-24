using OpenQA.Selenium;
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
        

        public void AddNewRecord (IWebDriver driver)
        {

            List<string> addNewRecord = new List<string>();
            addNewRecord.Add("CheckButtonName");
            addNewRecord.Add("CheckButtonDisplayTitle");
            addNewRecord.Add("CheckPreCondition");
            addNewRecord.Add("CheckValueUpdate");

            //#######Add New Record Test Here########
            driver.FindElement(By.XPath("//*[@id='grid']/div[1]/a")).ClickAndWait();

            //TextBox input
            driver.FindElement(By.Name("BTN_NAME")).EnterValue(addNewRecord[0]);
            driver.FindElement(By.Name("BTN_DISPLAY_TITLE")).EnterValue(addNewRecord[1]);
            driver.FindElement(By.Name("PRE_CONDITION")).EnterValue(addNewRecord[2]);
            driver.FindElement(By.Name("VALUE_UPDATES")).EnterValue(addNewRecord[3]);

            //Use DropdownSelect to Repeat Dropdown Selection
            DropdownSelect(driver);
            
            for (int i = 1; i < 2; i++)
            {
                try
                {
                    driver.FindElement(By.XPath("/html/body/div[6]/div[2]/div/div[27]/a[1]")).Click();
                    driver.SwitchTo().Alert().Dismiss();
                }
                catch (Exception) { Console.WriteLine("Exception caught!"); }
            }

            driver.Navigate().Refresh();

            //Use VerifyResult to Verify Record Change
            VerifyResult(driver, addNewRecord, "Add New Record", "AddUpdate");


        }

        public void EditExistingRecord(IWebDriver driver)
        {
            List<string> updateRecord = new List<string>();
            updateRecord.Add("update");
            updateRecord.Add("update2");
            updateRecord.Add("update4");
            updateRecord.Add("update5");
        }

        public void DeleteRecord(IWebDriver driver)
        {


            //######## Delete Function Test Here#########
            Filter(driver, "test");

            //Save Selected Record into deleteRecord 
            List<string> deleteRecord = new List<string>();

            deleteRecord.Add(driver.FindElement(By.XPath("//*[@id='grid']/div[4]/table/tbody/tr[1]/td[1]")).Text);
            deleteRecord.Add(driver.FindElement(By.XPath("//*[@id='grid']/div[4]/table/tbody/tr[1]/td[2]")).Text);
            deleteRecord.Add(driver.FindElement(By.XPath("//*[@id='grid']/div[4]/table/tbody/tr[1]/td[4]")).Text);
            deleteRecord.Add(driver.FindElement(By.XPath("//*[@id='grid']/div[4]/table/tbody/tr[1]/td[6]")).Text);
            Console.WriteLine("You are trying to delet button: {0},  {1},  {2} {3}", deleteRecord[0], deleteRecord[1], deleteRecord[2], deleteRecord[3]);

            driver.FindElement(By.XPath("//*[@id='grid']/div[4]/table/tbody/tr[1]/td[14]/a[2]")).ClickAndWait();
            //Delete Action Confirm
            driver.FindElement(By.XPath("//*[@id='container']/div/form/div/input")).ClickAndWait();

            //Verify Deletion Successful
            VerifyResult(driver, deleteRecord, "Delete Existing Record", "Del");


            //#######Closing Browser######
            //Refresh page
            driver.Navigate().Refresh();
            //driver.Close();
            //driver.Quit();
        }
        //Random DropDown Selection
        private static void DropdownSelect(IWebDriver driver)
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

            /*
                       //Override Theme
                       driver.FindElement(By.CssSelector("body > div.k-widget.k-window > div.k-popup-edit-form.k-window-content.k-content > div > div:nth-child(20) > span.k-widget.k-dropdown.k-header > span > span.k-input")).Click();
                       string overRideThemeXpath = "/html/body/div[14]/div/ul/li[" + rnd.Next(1,3) + "]";
                       func(driver.FindElement(By.XPath(overRideThemeXpath)));

                        //Color Selection
                        //COLOR 01
                        List<int> some = new List<int>();
                        some.Add(rnd.Next(0, 255));
                        some.Add(rnd.Next(0, 255));
                        some.Add(rnd.Next(0, 255));
                        Console.WriteLine(HexCodeConvertor(some));
                        driver.FindElement(By.CssSelector("body > div.k-widget.k-window > div.k-popup-edit-form.k-window-content.k-content > div > div:nth-child(22) > span > span > span.k-selected-color")).Click();
                        IWebElement colorValue = driver.FindElement(By.XPath("/html/body/div[13]")).FindElement(By.XPath("/div/div[1]/div/input"));
                        //IWebElement colorValue = driver.FindElement(By.XPath("//*[@className='k-selected-color']/div[1]/div/input"));

                        colorValue.Clear();
                        colorValue.EnterValue(HexCodeConvertor(some));

                        driver.FindElement(By.CssSelector("body > div.k-widget.k-window > div.k-popup-edit-form.k-window-content.k-content > div > div:nth-child(25) > label")).Click();




                        //COLOR 02
                        //driver.FindElement(By.CssSelector("body > div.k-widget.k-window > div.k-popup-edit-form.k-window-content.k-content > div > div:nth-child(24) > span > span > span.k-selected-color")).Click();

                        //COLOR 03
                        //driver.FindElement(By.CssSelector("body > div.k-widget.k-window > div.k-popup-edit-form.k-window-content.k-content > div > div:nth-child(26) > span > span > span.k-selected-color")).Click();

            */


        }

        //Convert RGB Value into HEX Code
        private static string HexCodeConvertor(List<int> rgb)
        {
            string result = "#";
            foreach (int index in rgb)
            {
                string r = Convert.ToString(rgb[0], 16);
                result = result + r;
            }
            return result.ToUpper();
        }


        //Filter 
        private static void Filter(IWebDriver driver, string filterValue)
        {
            driver.FindElement(By.XPath("//*[@id='grid']/div[3]/div/table/thead/tr/th[1]/a[1]/span")).ClickAndWait();
            IWebElement Newdriver = driver.FindElement(By.XPath("/html/body/div[5]/form/div[1]/input[1]"));
            Thread.Sleep(1000);

            Newdriver.EnterValue(filterValue);

            driver.FindElement(By.XPath("/html/body/div[5]/form/div[1]/div[2]/button[1]")).ClickAndWait();
        }


        //Verify Filter Result
        private static void VerifyResult(IWebDriver driver, List<string> newValue, string message, string AddorDel)
        {
            //Filter
            Filter(driver, newValue[0]);

            //Delete and Add/Edit Verification is Different
            switch (AddorDel)
            {
                case "Del":

                    string expectMessage = "No items to display";
                    string actualMessagge = driver.FindElement(By.CssSelector("#grid > div.k-pager-wrap.k-grid-pager.k-widget > span.k-pager-info.k-label")).Text;
                    if (expectMessage.Equals(actualMessagge))

                    //Compare Filter Result Pagenotation Message
                    { Console.WriteLine(message + " function test passed!"); }

                    //When There Are Two or More Buttons With Same Button Name.
                    else
                    {
                        for (int i = 1; i < 2; i++)
                        {
                            string resultBtnNm = driver.FindElement(By.XPath("//*[@id='grid']/div[4]/table/tbody/tr[1]/td[1]")).Text;
                            string resultBtnTt = driver.FindElement(By.XPath("//*[@id='grid']/div[4]/table/tbody/tr[1]/td[2]")).Text;
                            string resultPreCdt = driver.FindElement(By.XPath("//*[@id='grid']/div[4]/table/tbody/tr[1]/td[4]")).Text;
                            string resultVaUpdt = driver.FindElement(By.XPath("//*[@id='grid']/div[4]/table/tbody/tr[1]/td[6]")).Text;

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
                    string result1 = driver.FindElement(By.XPath("//*[@id='grid']/div[4]/table/tbody/tr/td[1]")).Text;
                    string result2 = driver.FindElement(By.XPath("//*[@id='grid']/div[4]/table/tbody/tr/td[2]")).Text;
                    string result3 = driver.FindElement(By.XPath("//*[@id='grid']/div[4]/table/tbody/tr/td[4]")).Text;
                    string result4 = driver.FindElement(By.XPath("//*[@id='grid']/div[4]/table/tbody/tr/td[6]")).Text;

                    //Compare the UpdateValue and Filter Result
                    if (result1.Equals(newValue[0]) && result2.Equals(newValue[1]) && result3.Equals(newValue[2]) && result4.Equals(newValue[3]))
                    { Console.WriteLine(message + " function test passed!"); }
                    else { Console.WriteLine(message + " function test FAILED!"); }
                    break;

                default: break;
            }
            driver.Navigate().Refresh();
        }

    }
}
