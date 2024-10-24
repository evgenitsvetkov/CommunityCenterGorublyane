using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static CommunityCenterGorublyane.Infrastructure.Constants.DataConstants;

namespace CommunityCenterGorublyane.Infrastructure.Data.Models
{
    [Comment("Community center's news")]
    public class News
    {
        [Key]
        [Comment("News identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        [Comment("News title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(ContentMaxLength)]
        [Comment("News content")]
        public string Content { get; set; } = string.Empty;

        [Comment("News image")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [Comment("Date of publication")]
        public DateTime Date { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
