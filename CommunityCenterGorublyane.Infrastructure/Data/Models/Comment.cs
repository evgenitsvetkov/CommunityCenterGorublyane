using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CommunityCenterGorublyane.Infrastructure.Constants.DataConstants;

namespace CommunityCenterGorublyane.Infrastructure.Data.Models
{
    [Comment("News comment")]
    public class Comment
    {
        [Key]
        [Comment("Comment identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Author's user identifier")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;

        [Required]
        [MaxLength(CommentMaxLength)]
        [Comment("Comment content")]
        public string Content { get; set; } = string.Empty;

        [Required]
        [Comment("Date of creation")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        [Comment("News identifier")]
        public int NewsId { get; set; }

        [ForeignKey(nameof(NewsId))]
        public News News { get; set; } = null!;
    }
}
