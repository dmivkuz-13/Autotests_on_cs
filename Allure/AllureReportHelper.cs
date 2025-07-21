
using Allure.Net.Commons;
using NUnit.Framework;
using System;

namespace Allure;

public class AllureReportHelper : IReportHelper
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public void ErrorMessageInNewStep(string titelStep, string? errorMessage = null, bool fatalError = false)
    {
        errorMessage ??= titelStep;

        if (fatalError)
            RunStep(titelStep, () => { throw new NotImplementedException(); });
        else
            try
            {
                TryRunStep(titelStep, () => { throw new Exception(errorMessage); });
            }
            catch { }        
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public void MessageInNewStep(string titelStep) => RunStep(titelStep, () => { });

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public void RunStep(string name, Action action) => AllureApi.Step($"[{DateTime.Now:HH:mm:ss}] {name}", action);

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public T RunStep<T>(string name, Func<T> func) => AllureApi.Step($"[{DateTime.Now:HH:mm:ss}] {name}", func);

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public void TryRunStep(string name, Action action)
    {
        try
        {
            AllureApi.Step($"[{DateTime.Now:HH:mm:ss}] {name}", action);
        }
        catch (Exception ex)
        {
            Assert.Warn(ex.Message);
        }
    }
}
