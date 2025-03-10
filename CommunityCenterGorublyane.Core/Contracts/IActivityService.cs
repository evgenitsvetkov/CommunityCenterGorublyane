﻿using CommunityCenterGorublyane.Core.Enumerations;
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

        Task<bool> ExistsAsync(int id);

        Task<ActivityDetailsServiceModel> ActivityDetailsByIdAsync(int id);

        Task EditAsync(int activityId, ActivityFormModel model);

        Task<ActivityFormModel?> GetActivityFormModelAsync(int id);

        Task DeleteAsync(int activityId);
    }
}
