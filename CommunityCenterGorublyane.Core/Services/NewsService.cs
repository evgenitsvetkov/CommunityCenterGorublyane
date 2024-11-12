using CommunityCenterGorublyane.Core.Contracts;
using CommunityCenterGorublyane.Core.Enumerations;
using CommunityCenterGorublyane.Core.Extensions;
using CommunityCenterGorublyane.Core.Models.News;
using CommunityCenterGorublyane.Infrastructure.Data.Common;
using CommunityCenterGorublyane.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CommunityCenterGorublyane.Core.Services
{
    public class NewsService : INewsService
    {
        private readonly IRepository repository;

        public NewsService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<NewsQueryServiceModel> AllAsync(
            string? searchTerm = null,
            NewsSorting sorting = NewsSorting.Newest,
            int currentPage = 1,
            int newsPerPage = 1)
        {
            var newsToShow = repository.AllReadOnly<News>();

            if (searchTerm != null)
            {
                string normalizedSearchTerm = searchTerm.ToLower();
                newsToShow = newsToShow
                    .Where(n => (n.Title.ToLower().Contains(normalizedSearchTerm) ||
                                n.Content.ToLower().Contains(normalizedSearchTerm)));
            }

            newsToShow = sorting switch
            {
                NewsSorting.Oldest => newsToShow.OrderBy(a => a.Id),
                _ => newsToShow.OrderByDescending(a => a.Id)
            };

            var news = await newsToShow
                .Skip((currentPage - 1) * newsPerPage)
                .Take(newsPerPage)
                .ProjectToNewsServiceModel()
                .ToListAsync();

            int totalNews = await newsToShow.CountAsync();

            return new NewsQueryServiceModel()
            {
                News = news,
                TotalNewsCount = totalNews,
            };
        }

        public async Task<int> CreateAsync(NewsFormModel model)
        {
            News news = new News()
            {
                Title = model.Title,
                Content = model.Content,
                Date = DateTime.Now,
                ImageUrl = model.ImageUrl,
            };

            await repository.AddAsync(news);
            await repository.SaveChangesAsync();
            
            return news.Id;
        }

        public async Task DeleteAsync(int newsId)
        {
            await repository.DeleteAsync<News>(newsId);
            await repository.SaveChangesAsync();
        }

        public async Task EditAsync(int newsId, NewsFormModel model)
        {
            var news = await repository.GetByIdAsync<News>(newsId);

            if (news != null)
            {
                news.Title = model.Title;
                news.Content = model.Content;
                news.ImageUrl = model.ImageUrl;

                await repository.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await repository.AllReadOnly<News>()
                .AnyAsync(n => n.Id == id);
        }

        public async Task<bool> CommentExistsAsync(int commentId)
        {
            return await repository.AllReadOnly<Comment>()
                .AnyAsync(c => c.Id == commentId);
        }

        public async Task<NewsFormModel?> GetNewsFormModelAsync(int id)
        {
            var news = await repository.AllReadOnly<News>()
                .Where(n => n.Id == id)
                .Select(n => new NewsFormModel()
                {
                    Title = n.Title,
                    Content = n.Content,
                    ImageUrl = n.ImageUrl,
                    Date = n.Date,
                })
                .FirstOrDefaultAsync();

            if (news != null)
            {
                news.Comments = await AllCommentsAsync();
            }

            return news;
        }

        public async Task<NewsDetailsServiceModel> NewsDetailsByIdAsync(int id)
        {
            return await repository.AllReadOnly<News>()
                .Where(n => n.Id == id)
                .Select(n => new NewsDetailsServiceModel()
                {
                    Id = n.Id,
                    Title = n.Title,
                    Content = n.Content,
                    Date = n.Date,
                    ImageUrl = n.ImageUrl,
                })
                .FirstAsync();
        }

        public async Task<IEnumerable<NewsCommentServiceModel>> AllCommentsAsync()
        {
            return await repository.AllReadOnly<Comment>()
                .Select(g => new NewsCommentServiceModel()
                {
                    Id = g.Id,
                    AuthorName = g.AuthorName,
                    Text = g.Text,
                    Date = g.Date
                })
                .ToListAsync();
        }
    }
}
