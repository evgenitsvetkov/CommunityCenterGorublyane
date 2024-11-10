using CommunityCenterGorublyane.Core.Contracts;
using System.ComponentModel.DataAnnotations;

namespace CommunityCenterGorublyane.Core.Models.Activity
{
    public class ActivityDetailsViewModel : IActivityModel
    {
        public int Id { get; set; }

        [Display(Name = "Заглавие")]
        public string Title { get; set; } = string.Empty;

        [Display(Name = "Описание")]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Контакти")]
        public string Contact { get; set; } = string.Empty;

        public string? ImageUrl { get; set; } = string.Empty;
    }
}
