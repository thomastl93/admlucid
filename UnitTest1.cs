using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace admlucid;

public class Tests
{
    IWebDriver driver;
    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
    }

    [Test]
    public void Test1()
    {
        driver.Navigate().GoToUrl("https://admlucid.com"); //navigating to URL
        Assert.That(driver.Title, Is.EqualTo("Home Page - Admlucid"));
        //Assert.Pass();
    }
    
    [TearDown]
    public void TearDown()
    {
        driver.Close();
    }
}