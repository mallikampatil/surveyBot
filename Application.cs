using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Threading;

namespace SurveyBot.Reference
{
    class Application
    {
        //IMPORTANT NOTE:
        //Make sure you have the following Nuget Packages Installed in Visual Studio
        //Right click "SurveyBot" -> Manage NuGet Packages for Solution -> Browse
        //Search and install the following packages: 1.) Selenium.WebDriver 2.) Selenium.WebDriver.ChromeDriver
        public void Run()
        {
            //Initializes webDriver to open a Chrome Web Browser
            IWebDriver chrome = new ChromeDriver();

            NavigateToWebpage(chrome, "https://uic.ca1.qualtrics.com/jfe/form/SV_7O6vHDsiqPdFpxc");

            List<string> emailAddresses = SetEmailAddresses();

            foreach (string emailAddress in emailAddresses)
            {
                //3 Parameters: 1.) driver 2.) the text that we want to add to the field 3.) X-Path where the item is located
                EnterText(chrome, " ", "//input[@id='QR~QID12']");

                EnterText(chrome, " ", "//input[@id='QR~QID10']");

                //Allows the browser to wait 1000 milliseconds
                Thread.Sleep(10000);
            }

            chrome.Quit();

            Environment.Exit(0);
        }

        //Navigates and opens the url in the chrome browser
        private static void NavigateToWebpage(IWebDriver chrome, string url)
        {
            chrome.Navigate().GoToUrl(url);
            chrome.Manage().Window.Maximize();
        }

        //Method to enter text into the specific text box
        private static void EnterText(IWebDriver chrome, string text, string xpath)
        {
            chrome.FindElement(By.XPath(xpath)).SendKeys(text);
        }

        //Able to select the desired radio button
        private static void SelectRadioButton(IWebDriver chrome, string buttonName)
        {
            string xpath = "//span[contains(.,'" + buttonName + "')]//span";
            chrome.FindElement(By.XPath(xpath)).Click();
        }

        //Click the Submit Button to finish the quiz
        private static void Submit(IWebDriver chrome, string xpath, bool sleep = false)
        {
            chrome.FindElement(By.XPath(xpath)).Click();

            if (sleep == true) { Thread.Sleep(1000); }
        }

        //List of Email Addresses to send the survey results to 
        private static List<string> SetEmailAddresses()
        {
            List<string> emailAddresses = new List<string>();
            //Add your emailAddresses here:
            //emailAddresses.Add(" ");
            return emailAddresses;
        }
    }
}
