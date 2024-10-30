using System.ComponentModel.DataAnnotations;
using static CommunityCenterGorublyane.Core.Constants.MessageConstants;
using static CommunityCenterGorublyane.Infrastructure.Constants.DataConstants;

namespace CommunityCenterGorublyane.Core.Models.Activity
{
    public class ActivityServiceModel
    {
        public int Id { get; set; }

        [Display(Name = "Заглавие")]
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(TitleMaxLength,
            MinimumLength = TitleMinLength,
            ErrorMessage = LengthMessage)]
        public string Title { get; set; } = string.Empty;

        [Display(Name = "Описание")]
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(DescriptionMaxLength,
            MinimumLength = DescriptionMinLength,
            ErrorMessage = LengthMessage)]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Контакти")]
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(ContactsMaxLength,
            MinimumLength = ContactsMinLength,
            ErrorMessage = LengthMessage)]
        public string Contact { get; set; } = string.Empty;

        [Display(Name = "Изображение")]
        public string? ImageUrl { get; set; } = string.Empty;
    }
}
