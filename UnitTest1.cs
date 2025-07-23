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
        options.AddArguments("--headless");
        options.AddArgument("--incognito");
        options.AddArgument("--start-maximized");
        driver = new ChromeDriver(options); //Chrome driver with options passed as a paremeter
        //driver = new SafariDriver(); //Safari driver
        //driver.Manage().Window.Maximize();
    }

    [Test]
    public void NavigateToURL()
    {
        driver.Navigate().GoToUrl("https://admlucid.com"); //navigating to URL
        Assert.That(driver.Title, Is.EqualTo("Home Page - Admlucid"));
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

    [Test]
    public void CheckBox()
    {
        driver.Navigate().GoToUrl("https://admlucid.com/Home/WebElements");
        Assert.That(driver.Title, Is.EqualTo("- Admlucid"));
        var checkboxId = driver.FindElement(By.Id("Checkbox1"));
        checkboxId.Click();
        Assert.That(checkboxId.GetAttribute("checked"), Is.EqualTo("true")); //Assertion to validate checkbox is checked
    }

    [Test]
    public void FormSubmition()
    {
        driver.Navigate().GoToUrl("https://admlucid.com/Home/WebElements");
        Assert.That(driver.Title, Is.EqualTo("- Admlucid"));
        
        var parentsName = driver.FindElement(By.Name("Name"));
        parentsName.SendKeys("Thomas Tams-Law");
        Assert.That(parentsName.GetAttribute("value"), Is.EqualTo("Thomas Tams-Law"));
        
        var parentsEmail = driver.FindElement(By.Name("EMail"));
        parentsEmail.SendKeys("test@test.com");
        Assert.That(parentsEmail.GetAttribute("value"), Is.EqualTo("test@test.com"));
        
        var parentsPhone = driver.FindElement(By.Name("Telephone"));
        parentsPhone.SendKeys("1234567890");
        Assert.That(parentsPhone.GetAttribute("value"), Is.EqualTo("1234567890"));
        
        var childGender = driver.FindElement(By.XPath("/html/body/div/main/form/p[4]/input[2]"));
        childGender.Click();
        Assert.That(childGender.GetAttribute("value"), Is.EqualTo("girl"));
        
        var age = driver.FindElement(By.Name("age"));   //locating the element and assigning to age variable
        SelectElement select = new SelectElement(age);   //passing the age varaible into the Select Element class
        select.SelectByIndex(4);    //searches foir value based on index value
        Assert.That(age.GetAttribute("value"), Is.EqualTo("5"));
        
        var selectService = driver.FindElement(By.Name("Service"));
        var select2 = new SelectElement(selectService);
        select2.SelectByText("Preschool");
        Assert.That(selectService.GetAttribute("value"), Is.EqualTo("Preschool"));
        
        
        
    }

    [TearDown]
    public void TearDown()
    {
        driver.Close();
    }
}