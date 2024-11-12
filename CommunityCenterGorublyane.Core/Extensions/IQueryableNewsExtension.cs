using CommunityCenterGorublyane.Core.Models.News;
using CommunityCenterGorublyane.Infrastructure.Data.Models;

namespace CommunityCenterGorublyane.Core.Extensions
{
    public static class IQueryableNewsExtension
    {
        public static IQueryable<NewsServiceModel> ProjectToNewsServiceModel(this IQueryable<News> news)
        {
            return news.Select(a => new NewsServiceModel()
            {
                Id = a.Id,
                Title = a.Title,
                Date = a.Date,
                ImageUrl = a.ImageUrl
            });
        }
    }
}
