using CommunityCenterGorublyane.Core.Models.News;

namespace CommunityCenterGorublyane.Core.Contracts
{
    public interface ICommentService
    {
        Task<NewsCommentServiceModel> CreateCommentAsync(NewsCommentFormModel model, string userId, string username);

        Task<List<NewsCommentServiceModel>> AllCommentsAsync(int newsId);

        Task DeleteCommentAsync(int commentId);

        Task<bool> ExistAsync(int commentId);

        Task<NewsCommentServiceModel> GetNewsCommentServiceModelByIdAsync(int commentId);

        Task EditCommentAsync(int id, NewsCommentEditModel model);
    }
}
