using Microsoft.AspNetCore.Http;

namespace DemoAcmeApp.Utils
{
    public static class Url
    {
        public static string BuildUrlFromRequest(HttpRequest request) => $"{request.Scheme}://{request.Host}{request.Path}/";
    }
}
