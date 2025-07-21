using Allure;
using Autotests_on_cs.Helpers;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RestAPIService;

namespace Autotests_on_cs;

public class DI
{
    private static readonly Lazy<IServiceProvider> _serviceProvider = new Lazy<IServiceProvider>(Configure);
    public static IWebDriver Driver => ServiceProvider.GetRequiredService<IWebDriver>();
    public static IServiceProvider ServiceProvider => _serviceProvider.Value;
    public static AllureReportHelper AllureReportHelper => ServiceProvider.GetRequiredService<AllureReportHelper>();
    public static RestAPIHelper RestApiHelper => ServiceProvider.GetRequiredService<RestAPIHelper>();
    public static APIHelper APIHelper => ServiceProvider.GetRequiredService<APIHelper>();

    public static ServiceProvider Configure()
    {
        var services = new ServiceCollection();

        services.AddScoped<IWebDriver>(provider =>
        {
            var options = new ChromeOptions();
            options.AddArguments(
                "--disable-infobars",               // Отключает информационные бары
                "--disable-extensions",             // Отключает расширения
                "--disable-notifications",          // Блокирует уведомления
                "--disable-password-manager",       // Отключает менеджер паролей
                "--disable-save-password-bubble",   // Убирает "Сохранить пароль?"
                "--start-maximized",                 // Дополнительно: запуск в maximized режиме
                "--incognito"                       // Запуск в режиме инкогнито
            );
            options.PageLoadStrategy = PageLoadStrategy.Eager;  // Стратегия загрузки страницы

            return new ChromeDriver(options);
        });

        //Helpers
        services.AddScoped<AllureReportHelper>();
        services.AddScoped<RestAPIHelper>();
        services.AddScoped<APIHelper>();

        return services.BuildServiceProvider();
    }
}
