using CommunityCenterGorublyane.Core.Contracts;
using CommunityCenterGorublyane.Core.Models.News;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CommunityCenterGorublyane.Controllers
{
    public class CommentController : BaseController
    {
        private readonly ICommentService commentService;
        private readonly INewsService newsService;

        public CommentController(ICommentService _commentService, INewsService _newsService)
        {
            commentService = _commentService;
            newsService = _newsService;

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> AddComment([FromBody]NewsCommentFormModel model)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return Unauthorized();
            }
        
            if (await newsService.ExistsAsync(model.NewsId) == false)
            {
                return BadRequest();
            }

            var userId = this.User.Id();
            var username = User.Identity.Name;

            if (ModelState.IsValid)
            {
                var newComment = await commentService.CreateCommentAsync(model, userId, username);

                return Json(new { success = true, createdAt = newComment.CreatedAt, username = newComment.Username, content = model.Content, commentId = newComment.Id });
            }            

            return BadRequest(new { success = false, message = "Невалиден коментар."});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteComment([FromBody]NewsCommentDeleteModel model)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return Unauthorized();
            }

            var userId = this.User.Id();

            if (await commentService.ExistAsync(model.Id) == false)
            {
                return BadRequest();
            }

            var comment = await commentService.GetNewsCommentServiceModelByIdAsync(model.Id);

            if (!this.User.IsAdmin() && comment.UserId != userId)
            {
                return Forbid();
            }

            if (ModelState.IsValid && comment != null)
            {
                await commentService.DeleteCommentAsync(comment.Id);

                return Json(new { success = true });
            }

            return BadRequest(new { success = false, message = "Възникна проблем при изтриване на коментара." });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> EditComment([FromBody]NewsCommentEditModel model)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return Unauthorized();
            }

            var userId = this.User.Id();

            if (await commentService.ExistAsync(model.Id) == false)
            {
                return BadRequest();
            }

            var comment = await commentService.GetNewsCommentServiceModelByIdAsync(model.Id);

            if (!this.User.IsAdmin() && comment.UserId != userId)
            {
                return Forbid();
            }

            if (ModelState.IsValid == false)
            {
                return BadRequest(new { success = false, message = "Коментарът е твърде дълъг." });
            }

            await commentService.EditCommentAsync(model.Id, model);

            return Json(new { success = true });
        }
    }
}
