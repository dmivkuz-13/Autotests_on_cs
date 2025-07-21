using Autotests_on_cs.Models.APIModels.FacultetsModels;

namespace Autotests_on_cs.Tests.APITests;

public class APIPostTests : APIBaseTests
{
    [Test]
    public void APIPostCreateFacultet()
    {
        // получить все факультеты,
        int countFacultetsBefore = DI.APIHelper.GetFacultets().Count();
        // создать новый факультет,
        string name = "Автоматизированного тестирования";
        var facultet = DI.APIHelper.CreateFacultets(name);
        int countFacultetsAfter = DI.APIHelper.GetFacultets().Count();
        // проверить что он корректно создался,
        var getFacultet = DI.APIHelper.GetFacultetById(facultet.Id);
        DI.AllureReportHelper.RunStep($"Проверка результатов теста", () =>
        {
            if (countFacultetsAfter - countFacultetsBefore == 1)
                DI.AllureReportHelper.MessageInNewStep("Добавлен один факультет");
            else DI.AllureReportHelper.ErrorMessageInNewStep("Количество факультетов не увеличилось");

            if (name == facultet.Name)
                DI.AllureReportHelper.MessageInNewStep($"Полученное название факультета совпадает с ожидаемым");
            else DI.AllureReportHelper.ErrorMessageInNewStep("Получен другой факультет");
        });
        // удалить его.
        DI.APIHelper.DeleteFacultet(facultet.Id);

    }
}
