namespace Vidli.Core.HttpContext
{
    public static class GetUri
    {
        public static Uri Uri(HttpRequest request, string id)
        {
            var uriBuilder = new UriBuilder
            {
                Scheme = request.Scheme,
                Host = request.Host.Host,
                Port = request.Host.Port.GetValueOrDefault(80),
                Path = $"{request.Path}{id}"
            };

            return uriBuilder.Uri;
        }

    }
}
