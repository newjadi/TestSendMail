using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Email.Pages
{
    class PageHome
    {
        //Строка для вводы логина  
       [FindsBy(How = How.Id, Using = "mailbox:login")]
       public IWebElement Login { get; set; }

        //Строка для вводы логина
       [FindsBy(How = How.Id, Using = "mailbox:password")]
       public IWebElement Password { get; set; }
        
        //Кнопка
       [FindsBy(How = How.Id, Using = "mailbox:submit")]
       public IWebElement ButtunSubmit { get; set; }

    }
}
