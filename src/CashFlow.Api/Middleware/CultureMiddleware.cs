using System.Globalization;

namespace CashFlow.Api.Middleware;

public class CultureMiddleware
{
    private readonly RequestDelegate _next;
    public CultureMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context)
    {
        var suportedLanguages = CultureInfo.GetCultures(CultureTypes.AllCultures).ToList();
        var requestCulture = context.Request.Headers.AcceptLanguage.FirstOrDefault();
        var cultureInfo = new CultureInfo("en");
        if (string.IsNullOrWhiteSpace(requestCulture) == false 
            && suportedLanguages.Exists(languages => languages.Name.Equals(requestCulture )))
        {
            cultureInfo = new CultureInfo("pt-BR");
        }
        CultureInfo.CurrentCulture = cultureInfo;
        CultureInfo.CurrentUICulture = cultureInfo;
        await _next(context);
    }
}