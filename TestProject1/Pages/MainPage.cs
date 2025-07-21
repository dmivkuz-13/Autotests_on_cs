using OpenQA.Selenium;

namespace Autotests_on_cs.Pages;

public class MainPage
{
    public static IWebElement ButtonBurgerMenu => DI.Driver.FindElement(By.CssSelector("button[id='react-burger-menu-btn']"));
    public static IWebElement ButtonLogout => DI.Driver.FindElement(By.CssSelector("a[id='logout_sidebar_link']"));
}
