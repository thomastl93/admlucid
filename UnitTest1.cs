using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;


namespace admlucid;

public class Tests
{
    IWebDriver driver;
    [SetUp]
    public void Setup()
    {
        ChromeOptions options = new ChromeOptions();
        //options.AddArguments("--headless");
        options.AddArgument("--incognito");
        options.AddArgument("--start-maximized");
        driver = new ChromeDriver(options); //Chrome driver
        //driver = new SafariDriver(); //Safari driver
        //driver.Manage().Window.Maximize();
    }

    [Test]
    public void NavigateToURL()
    {
        driver.Navigate().GoToUrl("https://admlucid.com"); //navigating to URL
        Assert.That(driver.Title, Is.EqualTo("Home Page - Admlucid"));
        //Assert.Pass();
    }

    [Test]
    public void TestTextbox()
    {
        driver.Navigate().GoToUrl("https://admlucid.com/Home/WebElements"); //navigating to URL
        Assert.That(driver.Title, Is.EqualTo("- Admlucid"));
        var locatorId = driver.FindElement(By.Id("Text1"));
        locatorId.SendKeys("Hello World");
        locatorId.Clear();
        //Assert.Pass();;
    }

    [Test]
    public void TestButton()
    {
        driver.Navigate().GoToUrl("https://admlucid.com/Home/WebElements");
        Assert.That(driver.Title, Is.EqualTo("- Admlucid"));
        var buttonId = driver.FindElement(By.Id("Button1"));
        buttonId.Click();
        Thread.Sleep(2000); //sleeps for two seconds after button click
        driver.SwitchTo().Alert().Accept(); //accepts in page alerts
        //Assert.Pass();
    }

    [Test]
    public void FileInput()
    {
        driver.Navigate().GoToUrl("https://admlucid.com/Home/WebElements");
        Assert.That(driver.Title, Is.EqualTo("- Admlucid"));
        var fileInputId = driver.FindElement(By.Id("Text1"));
        fileInputId.SendKeys(@"C:\\Users\\admlucid\\Downloads\\admlucid.png");
        Assert.That(fileInputId.GetAttribute("value"), Is.EqualTo(@"C:\\Users\\admlucid\\Downloads\\admlucid.png")); //Assertion to validate file path is entered correctly
    }

    [TearDown]
    public void TearDown()
    {
        driver.Close();
    }
}