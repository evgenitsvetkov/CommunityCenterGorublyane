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
        [MaxLength(AuthorNameMaxLength)]
        [Comment("Author's comment")]
        public string AuthorName { get; set; } = string.Empty;

        [Required]
        [MaxLength(ContentMaxLength)]
        [Comment("Comment content")]
        public string Text { get; set; } = string.Empty;

        [Required]
        [Comment("Date of creation")]
        public DateTime Date { get; set; }

        [Required]
        [Comment("News identifier")]
        public int NewsId { get; set; }

        [ForeignKey(nameof(NewsId))]
        public News News { get; set; } = null!;
    }
}
