using SocialMedia.Core.QueryFilter;

namespace SocialMedia.Infraestructure.Service
{
    public interface IUriService
    {
        Uri GetPostPaginationUri(PostQueryFilter filters, string action);
    }
}