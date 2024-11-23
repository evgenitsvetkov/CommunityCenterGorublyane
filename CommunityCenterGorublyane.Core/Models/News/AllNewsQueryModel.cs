using CommunityCenterGorublyane.Core.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace CommunityCenterGorublyane.Core.Models.News
{
    public class AllNewsQueryModel
    {
        public int NewsPerPage { get; init; } = 6;

        [Display(Name = "Търсене")]
        public string SearchTerm { get; init; } = null!;

        [Display(Name = "Сортиране")]
        public NewsSorting Sorting { get; init; }

        [Display(Name = "Сегашна страница")]
        public int CurrentPage { get; init; } = 1;

        public int TotalNewsCount { get; set; }

        public IEnumerable<NewsServiceModel> News { get; set; } = new List<NewsServiceModel>();
    }
}
