using CommunityCenterGorublyane.Core.Contracts;
using System.ComponentModel.DataAnnotations;
using static CommunityCenterGorublyane.Core.Constants.MessageConstants;
using static CommunityCenterGorublyane.Infrastructure.Constants.DataConstants;

namespace CommunityCenterGorublyane.Core.Models.Activity
{
    public class ActivityFormModel : IActivityModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(TitleMaxLength,
            MinimumLength = TitleMinLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "Заглавие")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(DescriptionMaxLength,
            MinimumLength = DescriptionMinLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "Описание")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(ContactsMaxLength,
            MinimumLength = ContactsMinLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "Контакти")]
        public string Contact { get; set; } = null!;

        [Display(Name = "Изображение")]
        public string? ImageUrl { get; set; }
    }
}
