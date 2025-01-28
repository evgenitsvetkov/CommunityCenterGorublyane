using CommunityCenterGorublyane.Core.Contracts;
using System.ComponentModel.DataAnnotations;
using static CommunityCenterGorublyane.Core.Constants.MessageConstants;
using static CommunityCenterGorublyane.Infrastructure.Constants.DataConstants;

namespace CommunityCenterGorublyane.Core.Models.Activity
{
    public class ActivityServiceModel : IActivityModel
    {
        public int Id { get; set; }

        [Display(Name = "Заглавие")]
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(TitleMaxLength,
            MinimumLength = TitleMinLength,
            ErrorMessage = LengthMessage)]
        public string Title { get; set; } = null!;
        
        [Display(Name = "Изображение")]
        public string? ImageUrl { get; set; } = string.Empty;
    }
}
