using CommunityCenterGorublyane.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CommunityCenterGorublyane.Components
{
    public class CommentComponent : ViewComponent
    {
        private readonly ICommentService commentService;

        public CommentComponent(ICommentService _commentService)
        {
            commentService = _commentService;

        }

        public async Task<IViewComponentResult> InvokeAsync(int newsId)
        {
            var comments = await commentService.AllCommentsAsync(newsId);

            return await Task.FromResult<IViewComponentResult>(View(comments));
        }
    }
}
