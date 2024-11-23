using CommunityCenterGorublyane.Core.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace CommunityCenterGorublyane.Core.Models.Activity
{
    public class AllActivitiesQueryModel
    {
        public int ActivitiesPerPage { get; init; } = 6;

        [Display(Name = "Търсене")]
        public string SearchTerm { get; init; } = null!;

        [Display(Name = "Сортиране")]
        public ActivitySorting Sorting { get; init; }

        [Display(Name = "Сегашна страница")]
        public int CurrentPage { get; init; } = 1;

        public int TotalActivitiesCount { get; set; }

        public IEnumerable<ActivityServiceModel> Activities { get; set; } = new List<ActivityServiceModel>();

    }
}
