using CommunityCenterGorublyane.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static CommunityCenterGorublyane.Core.Constants.MessageConstants;
using static CommunityCenterGorublyane.Infrastructure.Constants.DataConstants;

namespace CommunityCenterGorublyane.Core.Models.News
{
    public class NewsFormModel
    {

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(TitleMaxLength,
            MinimumLength = TitleMinLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "Заглавие")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(DescriptionMaxLength,
            MinimumLength = DescriptionMinLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "Описание")]
        public string Content { get; set; } = string.Empty;

        [Display(Name = "Изображение")]
        public string? ImageUrl { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Публикувана")]
        public DateTime Date { get; set; }

        public IEnumerable<NewsCommentServiceModel> Comments { get; set; } = new List<NewsCommentServiceModel>();
    }
}
