using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static CommunityCenterGorublyane.Infrastructure.Constants.DataConstants;

namespace CommunityCenterGorublyane.Infrastructure.Data.Models
{
    [Comment("Community center's activity")]
    public class Activity
    {
        [Key]
        [Comment("Activity identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        [Comment("Activity title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        [Comment("Activity description")]
        public string Description { get; set; } = string.Empty;

        [MaxLength(ContactsMaxLength)]
        [Comment("Activity contact")]
        public string Contact { get; set; } = string.Empty;

        [Comment("Activity image")]
        public string ImageUrl { get; set; } = string.Empty;
    }
}
