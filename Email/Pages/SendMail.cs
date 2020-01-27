using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Email.Pages
{
    class SendMail
    {
        //Находим кнопку написать письмо
        [FindsBy(How = How.ClassName, Using = "compose-button")]
        public IWebElement WriteMail { get; set; }

        //Находим поле Тема письма
        [FindsBy(How = How.Name, Using = "Subject")]
        public IWebElement Subject { get; set; }

        //Находим поле Адрес получателя
        [FindsBy(How = How.XPath, Using = "//div/div/input")]
        public IWebElement Input { get; set; }

        // Находим поле Тело письма
        [FindsBy(How = How.XPath, Using = "//div[3]/div[5]/div/div/div[2]/div")]
        public IWebElement Body { get; set; }

        //ОТправляем письмо
        [FindsBy(How = How.XPath, Using = "//div[2]/div/span/span/span")]
        public IWebElement Send { get; set; }
    }
}
