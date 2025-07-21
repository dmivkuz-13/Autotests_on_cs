using Autotests_on_cs.Models.APIModels.FacultetsModels;
using Newtonsoft.Json;

namespace Autotests_on_cs.Helpers;

public class APIHelper
{
    private readonly string _apiURL = "http://109.172.115.139:5000/api";

    public List<GetFacultetsResponseModel> GetFacultets()
    {
        List<GetFacultetsResponseModel> jsonObj = new();
        DI.AllureReportHelper.RunStep("Получение всех факультетов", () =>
        {
            var result = DI.RestApiHelper.Get($"{_apiURL}/Facultets/GetFacultets").Result;
            jsonObj = JsonConvert.DeserializeObject<List<GetFacultetsResponseModel>>(result)!;
        });

        return jsonObj;
    }

    public GetFacultetsResponseModel GetFacultetById(int id)
    {
        GetFacultetsResponseModel getFacultetsResponseModel = new();
        DI.AllureReportHelper.RunStep("Поулчение факультета по ID {id}", () =>
        {
            var result = DI.RestApiHelper.Get($"{_apiURL}/Facultets/GetFacultets/{id}").Result;
            getFacultetsResponseModel = JsonConvert.DeserializeObject<GetFacultetsResponseModel>(result)!;
        });

        return getFacultetsResponseModel;
    }

    public CreateFacultetResponseModel CreateFacultets(string name)
    {
        CreateFacultetResponseModel postResponseModel = new();
        DI.AllureReportHelper.RunStep("Создание нового факультета", () =>
        {
            var result = DI.RestApiHelper.Post($"{_apiURL}/Facultets/CreateFacultet?facultetName={name}", null).Result;
            postResponseModel = JsonConvert.DeserializeObject<CreateFacultetResponseModel>(result)!;
        });

        return postResponseModel;
    }

    public bool DeleteFacultet(int id)
    {
        bool isDelete = false;
        DI.AllureReportHelper.RunStep($"Удаление факультета по ID {id}", () =>
        {
            isDelete = DI.RestApiHelper.Delete($"{_apiURL}/Facultets/DeleteFacultet/{id}").IsCompletedSuccessfully;
        });
        return isDelete;
    }

}
