
using Allure.NUnit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Autotests_on_cs.Tests.APITests;

[AllureNUnit]
public class APIBaseTests
{
    [SetUp]
    public void Setup() { }

    [TearDown]
    public void Teardown() { }

    [OneTimeSetUp]
    public void OneTimeSetUp() { }

    [OneTimeTearDown]
    public void OneTimeTearDown() { }
}
