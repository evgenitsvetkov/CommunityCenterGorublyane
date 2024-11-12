using System.ComponentModel.DataAnnotations;
using static CommunityCenterGorublyane.Core.Constants.MessageConstants;
using static CommunityCenterGorublyane.Infrastructure.Constants.DataConstants;

namespace CommunityCenterGorublyane.Core.Models.News
{
    public class NewsDetailsServiceModel : NewsServiceModel
    {
        [Display(Name = "Описание")]
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(DescriptionMaxLength,
           MinimumLength = DescriptionMinLength,
           ErrorMessage = LengthMessage)]
        public string Content { get; set; } = string.Empty;

        public IEnumerable<NewsCommentServiceModel> Comments { get; set; }
    }
}
