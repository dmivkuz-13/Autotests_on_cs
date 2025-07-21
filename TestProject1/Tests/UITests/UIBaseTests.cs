using Allure.NUnit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Autotests_on_cs.Tests.UITests;

[AllureNUnit]
public class UIBaseTests
{
    [SetUp]
    public void Setup()
    {
        DI.Driver.Navigate().GoToUrl("https://www.saucedemo.com/");
    }

    [TearDown]
    public void Teardown()
    {
    }

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
    }

    [OneTimeTearDown]
    public void OneTimeTearDown() 
    {
        DI.Driver.Close();
    }
}