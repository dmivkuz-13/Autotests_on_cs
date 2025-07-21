namespace RestAPIService;

public interface IRestAPIService
{
    /// <summary>
    /// Отправить запрос Get
    /// </summary>
    /// <param name="requestUrl">URL запроса</param>
    /// <returns></returns>
    Task<string> Get(string requestUrl);

    /// <summary>
    /// Отправить запрос Post
    /// </summary>
    /// <param name="requestUrl">URL запроса</param>
    /// <param name="requestBody">Тело запроса</param>
    /// <returns></returns>
    Task<string> Post(string requestUrl, HttpContent requestBody);

    /// <summary>
    /// Отправить запрос Put
    /// </summary>
    /// <param name="requestUrl">URL запроса</param>
    /// <param name="requestBody">Тело запроса</param>
    /// <returns></returns>
    Task<string> Put(string requestUrl, HttpContent requestBody);

    /// <summary>
    /// Отправить запрос Delete
    /// </summary>
    /// <param name="requestUrl">URL запроса</param>
    /// <returns></returns>
    Task<string> Delete(string requestUrl);
}