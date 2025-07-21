using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace Autotests_on_cs.Models.APIModels.FacultetsModels;

public partial class CreateFacultetResponseModel
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("students", NullValueHandling = NullValueHandling.Ignore)]
    public List<Students> Students { get; set; } = new();
}
