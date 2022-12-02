using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace TestAutomationProject
{
    public class BrowserController {

        public IWebDriver driver;

        public void initBrowser()
        {
            driver = new ChromeDriver();
        }

        public void Maximize() {
          driver.Manage().Window.Maximize();
            }
        public void NavigateURL(string NewURL)
        {
            driver.Url = NewURL;

        }
        public void CLickElementByXpath(string xPath)
        {
            By elem = By.XPath(xPath);
            driver.FindElement(elem).Click();
        }
        public void CheckElementExistsByXPath(string xPath)
        {
            By elem = By.XPath(xPath);
            driver.FindElement(elem);
        }
        public void EnterTextByXPath(string xpath, string text)
        {
            CheckElementExistsByXPath(xpath);
            By elem = By.XPath(xpath);

            driver.FindElement(elem).SendKeys(text);

        }
        
    }

    public class Class1
    {
        BrowserController brContr = new BrowserController();

        [SetUp]
        public void BuildUp() 
        {
            brContr.initBrowser();
            brContr.Maximize();
            brContr.NavigateURL("https://testpages.herokuapp.com/styled/calculator");
        
        }
        [TearDown]

        public void tearDown()
        {
            brContr.driver.Close();
        }
            

        [Test]  

        public void CheckIfFirstMathIsCorrect() 
        {
            brContr.EnterTextByXPath("//input[@id='number1']", "2");
            brContr.EnterTextByXPath("//input[@id='number2']", "2");
            brContr.CLickElementByXpath("//input[@id='calculate']");
            brContr.CheckElementExistsByXPath("//span[@id='answer']");

        }

        [Test]
        
        public void CheckIfSecondMathIsCorrect()
        {
            brContr.EnterTextByXPath("//input[@id='number1']", "-5");
            brContr.EnterTextByXPath("//input[@id='number2']", "3");
            brContr.CLickElementByXpath("//input[@id='calculate']");
            brContr.CheckElementExistsByXPath("//span[@id='answer']");
        }

        [Test]
        public void CheckIfThirdMathIsCorrect()
        {
            brContr.EnterTextByXPath("//input[@id='number1']", "a");
            brContr.EnterTextByXPath("//input[@id='number2']", "b");
            brContr.CLickElementByXpath("//input[@id='calculate']");
            brContr.CheckElementExistsByXPath("//span[@id='answer']");
        }


    }


}