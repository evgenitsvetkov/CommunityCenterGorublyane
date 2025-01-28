using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static CommunityCenterGorublyane.Core.Constants.MessageConstants;
using static CommunityCenterGorublyane.Infrastructure.Constants.DataConstants;

namespace CommunityCenterGorublyane.Core.Models.News
{
    public class NewsCommentEditModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(CommentMaxLength,
            MinimumLength = CommentMinLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "Коментар")]
        public string Content { get; set; } = string.Empty;
    }
}
