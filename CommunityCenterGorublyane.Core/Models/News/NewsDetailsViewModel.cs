using System.ComponentModel.DataAnnotations;

namespace CommunityCenterGorublyane.Core.Models.News
{
    public class NewsDetailsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Заглавие")]
        public string Title { get; set; } = string.Empty;

        [Display(Name = "Описание")]
        public string Content { get; set; } = string.Empty;

        [Display(Name = "Публикувана")]
        public DateTime Date { get; set; }

        [Display(Name = "Изображение")]
        public string? ImageUrl { get; set; } = string.Empty;
    }
}
