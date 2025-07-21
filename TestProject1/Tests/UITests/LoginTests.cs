using Autotests_on_cs.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace Autotests_on_cs.Tests.UITests;

public class LoginTests : UIBaseTests
{
    [Test]
    public void ErrorLoginTest()
    {
        DI.AllureReportHelper.TryRunStep("Проверка ошибки авторизации только с паролем", () =>
        {
            LoginPage.Password.SendKeys("asd");
            LoginPage.ButtonLogin.Click();
            CheckErrorMessage("Epic sadface: Username is required");
        });
    }

    [Test]
    public void ErrorPasswordTest()
    {
        DI.AllureReportHelper.TryRunStep("Проверка ошибки авторизации только с логином", () =>
        {
            LoginPage.Username.SendKeys("asd");
            LoginPage.ButtonLogin.Click();
            CheckErrorMessage("Epic sadface: Password is required");
        });
    }

    [Test]
    public void IncorrectLoginTest()
    {
        DI.AllureReportHelper.TryRunStep("Проверка ошибки авторизации с неверным логином", () =>
        {
            LoginPage.Username.SendKeys("asd");
            LoginPage.Password.SendKeys(LoginPage.PasswordText);
            LoginPage.ButtonLogin.Click();
            CheckErrorMessage("Epic sadface: Username and password do not match any user in this service");
        });
    }

    [Test]
    public void CorrectLoginTest()
    {
        //MainPage.Username.SendKeys();
        // - Логинимся с корректными данными, проверяем что логин прошёл успешно - Разлогиниваемся 
        DI.AllureReportHelper.TryRunStep("Проверка авторизации с корерктными данными", () =>
        {
            //string login = LoginPage.OneRandomLogin();
            string login = "standard_user";
            string password = LoginPage.PasswordText;
            LoginPage.Username.SendKeys(login);
            LoginPage.Password.SendKeys(password);
            LoginPage.ButtonLogin.Click();
            try
            {
                if (MainPage.ButtonBurgerMenu.Displayed)
                {
                    DI.AllureReportHelper.MessageInNewStep($"Авторизация с логином {login} и паролем {password} прошла успешно");
                    MainPage.ButtonBurgerMenu.Click();
                    MainPage.ButtonLogout.Click();
                }
            }
            catch (Exception ex)
            {
                DI.AllureReportHelper.ErrorMessageInNewStep($"{ex.Message}");
            }
        });

    }

    public void CheckErrorMessage(string message)
    {
        string errMessage = LoginPage.TextError.Text;
        if (errMessage == message)
            DI.AllureReportHelper.MessageInNewStep($"Найденный текст: '{errMessage}' соответствует ожидаемому: '{message}'");
        else
            DI.AllureReportHelper.ErrorMessageInNewStep($"Найденный текст: '{errMessage}' НЕ соответствует ожидаемому: '{message}'");
        LoginPage.ButtonError.Click();
    }
}
