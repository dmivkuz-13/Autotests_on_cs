using OpenQA.Selenium;
using static System.Net.Mime.MediaTypeNames;

namespace Autotests_on_cs.Pages;

public class LoginPage
{
    public static IWebElement Username => DI.Driver.FindElement(By.CssSelector("input[id = 'user-name']"));
    public static IWebElement Password => DI.Driver.FindElement(By.CssSelector("input[id='password']"));

    public static IWebElement ButtonLogin => DI.Driver.FindElement(By.CssSelector("input[id='login-button']"));
    public static IWebElement ButtonError => DI.Driver.FindElement(By.CssSelector("button[class='error-button']"));

    public static IWebElement TextError => DI.Driver.FindElement(By.CssSelector("h3[data-test='error']"));
    private static IWebElement TextPassword => DI.Driver.FindElement(By.CssSelector("div[class='login_password']"));
    private static IWebElement TextLogin => DI.Driver.FindElement(By.CssSelector("div[class='login_credentials']"));

    public static string PasswordText =>
        TextPassword.Text.Replace("Password for all users:", "").Trim();
    public static string[] LoginArray =>
        TextLogin.Text.Replace("Accepted usernames are:\r\n", "").Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
    public static string OneRandomLogin()
    {
        Random rnd = new Random();
        string login = LoginArray[rnd.Next(LoginArray.Length)];
        return login;
    }

}
