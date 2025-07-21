using Newtonsoft.Json;

namespace Autotests_on_cs.Models.APIModels.FacultetsModels;

public class GetFacultetsResponseModel
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;

    [JsonProperty("students",  NullValueHandling = NullValueHandling.Ignore)]
    public List<Students> Students { get; set; } = new();
}

public class Students
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;

    [JsonProperty("lastName")]
    public string LastName { get; set; } = string.Empty;

    [JsonProperty("age")]
    public int Age { get; set; }
}

