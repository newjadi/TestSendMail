using System;
using Email.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Email
{
    [TestClass]
    public class Test
    {
        ChromeDriver chrome;
        string user = "dasstest";
        string password = "12345ZaqQ";

        [TestMethod]
        public void TestMethod1()
        {
            chrome = new ChromeDriver();
            chrome.Navigate().GoToUrl("https://mail.ru/");
            chrome.Manage().Window.Maximize();
            PageHome pageHome = new PageHome();
            PageFactory.InitElements(chrome, pageHome);

            pageHome.Login.SendKeys(user);
            pageHome.ButtunSubmit.Click();
            pageHome.Password.SendKeys(password);
            pageHome.ButtunSubmit.Click();


            SendMail sendMail = new SendMail();
            PageFactory.InitElements(chrome, sendMail);

            // Ждем появления элемента, создать письмо
            WebDriverWait wait = new WebDriverWait(chrome, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(By.ClassName("compose-button")));
            sendMail.WriteMail.Click(); // Находим и нажимаем.

            // Ждем появления элемента Адрес получателя
            WebDriverWait wait1 = new WebDriverWait(chrome, TimeSpan.FromSeconds(10));
            wait1.Until(ExpectedConditions.ElementExists(By.XPath("//div/div/input")));
            sendMail.Input.SendKeys("Неизвестный получатель"); // Находим в водим в поле значение.

            // Ждем появлени элемента Тема письма
            WebDriverWait wait2 = new WebDriverWait(chrome, TimeSpan.FromSeconds(10));
            wait2.Until(ExpectedConditions.ElementExists(By.Name("Subject")));
            sendMail.Subject.SendKeys("Тема Письма"); // Находим в водим в поле значение.

            // Ждем появления элемента Тело письма
            WebDriverWait wait3 = new WebDriverWait(chrome, TimeSpan.FromSeconds(10));
            wait3.Until(ExpectedConditions.ElementExists(By.XPath("//div[3]/div[5]/div/div/div[2]/div")));
            sendMail.Body.SendKeys("Много текста");

            //Отправляем письмо
            sendMail.Send.Click();
        }
    }
}
