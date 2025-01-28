using CommunityCenterGorublyane.Core.Contracts;
using CommunityCenterGorublyane.Core.Models.News;
using CommunityCenterGorublyane.Infrastructure.Data.Common;
using CommunityCenterGorublyane.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CommunityCenterGorublyane.Core.Services
{
    public class CommentService : ICommentService
    {
        private readonly IRepository repository;

        public CommentService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<List<NewsCommentServiceModel>> AllCommentsAsync(int newsId)
        {
            return await repository
                .AllReadOnly<Comment>()
                .Where(c => c.NewsId == newsId)
                .Select(c => new NewsCommentServiceModel()
                {
                    Id = c.Id,
                    Username = c.User.UserName,
                    UserId = c.User.Id,
                    Content = c.Content,
                    CreatedAt = c.CreatedAt,
                })
                .ToListAsync();
        }

        public async Task<NewsCommentServiceModel> CreateCommentAsync(NewsCommentFormModel model, string userId, string username)
        {
            Comment newComment = new Comment()
            {
               UserId = userId,
               NewsId = model.NewsId,
               Content = model.Content,
               CreatedAt = DateTime.Now,
            };

            await repository.AddAsync(newComment);
            await repository.SaveChangesAsync();

            return new NewsCommentServiceModel()
            {
                Id = newComment.Id,
                UserId = userId,
                Username = username,
                Content = newComment.Content,
                CreatedAt = newComment.CreatedAt,
            };
        }

        public async Task DeleteCommentAsync(int commentId)
        {
            await repository.DeleteAsync<Comment>(commentId);
            await repository.SaveChangesAsync();
        }

        public async Task EditCommentAsync(int id, NewsCommentEditModel model)
        {
            var comment = await repository.GetByIdAsync<Comment>(id);

            if (comment != null)
            {
                comment.Content = model.Content;
                comment.CreatedAt = DateTime.Now;
                
                await repository.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistAsync(int commentId)
        {
            return await repository.AllReadOnly<Comment>()
                .AnyAsync(c => c.Id == commentId);
        }

        public async Task<NewsCommentServiceModel> GetNewsCommentServiceModelByIdAsync(int commentId)
        {
            return await repository.AllReadOnly<Comment>()
                .Where(c => c.Id == commentId)
                .Select(c => new NewsCommentServiceModel()
                {
                    Id = c.Id,
                    UserId = c.UserId,
                    Username = c.User.UserName,
                    Content = c.Content,
                    CreatedAt = c.CreatedAt,
                })
                .FirstOrDefaultAsync();
        }
    }
}
