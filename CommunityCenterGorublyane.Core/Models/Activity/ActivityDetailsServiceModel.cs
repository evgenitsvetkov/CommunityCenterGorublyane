using System.ComponentModel.DataAnnotations;
using static CommunityCenterGorublyane.Core.Constants.MessageConstants;
using static CommunityCenterGorublyane.Infrastructure.Constants.DataConstants;

namespace CommunityCenterGorublyane.Core.Models.Activity
{
    public class ActivityDetailsServiceModel : ActivityServiceModel
    {
        [Display(Name = "Описание")]
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(DescriptionMaxLength,
            MinimumLength = DescriptionMinLength,
            ErrorMessage = LengthMessage)]
        public string Description { get; set; } = null!;
        
        [Display(Name = "Контакти")]
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(ContactsMaxLength,
            MinimumLength = ContactsMinLength,
            ErrorMessage = LengthMessage)]
        public string Contact { get; set; } = null!;
    }
}
