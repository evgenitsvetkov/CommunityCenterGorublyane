using CommunityCenterGorublyane.Core.Enumerations;
using CommunityCenterGorublyane.Core.Models.Activity;

namespace CommunityCenterGorublyane.Core.Contracts
{
    public interface IActivityService
    {
        Task<int> CreateAsync(ActivityFormModel model);

        Task<ActivityQueryServiceModel> AllAsync(
            string? searchTerm = null,
            ActivitySorting sorting = ActivitySorting.Newest,
            int currentPage = 1,
            int activitiesPerPage = 1);
    }
}
