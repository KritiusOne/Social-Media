using SocialMedia.Core.QueryFilter;

namespace SocialMedia.Infraestructure.Service
{
    public class UriService : IUriService
    {
        private readonly string _url;
        public UriService(string baseUri)
        {
            _url = baseUri;
        }
        public Uri GetPostPaginationUri(PostQueryFilter filters, string action)
        {
            string baseUrl = $"{_url}{action}";
            return new Uri(baseUrl);
        }
    }
}
