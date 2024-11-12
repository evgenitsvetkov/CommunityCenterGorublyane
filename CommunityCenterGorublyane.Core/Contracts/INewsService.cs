using CommunityCenterGorublyane.Core.Enumerations;
using CommunityCenterGorublyane.Core.Models.News;

namespace CommunityCenterGorublyane.Core.Contracts
{
    public interface INewsService
    {
        Task<int> CreateAsync(NewsFormModel model);

        Task<NewsQueryServiceModel> AllAsync(
            string? searchTerm = null,
            NewsSorting sorting = NewsSorting.Newest,
            int currentPage = 1,
            int newsPerPage = 1);

        Task<bool> ExistsAsync(int id);

        Task<NewsDetailsServiceModel> NewsDetailsByIdAsync(int id);

        Task EditAsync(int newsId, NewsFormModel model);

        Task<NewsFormModel?> GetNewsFormModelAsync(int id);

        Task DeleteAsync(int newsId);

        public Task<bool> CommentExistsAsync(int commentId);

        public Task<IEnumerable<NewsCommentServiceModel>> AllCommentsAsync();
    }
}
