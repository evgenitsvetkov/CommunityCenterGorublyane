using CommunityCenterGorublyane.Core.Contracts;
using CommunityCenterGorublyane.Core.Enumerations;
using CommunityCenterGorublyane.Core.Models.Activity;
using CommunityCenterGorublyane.Infrastructure.Data.Common;
using CommunityCenterGorublyane.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CommunityCenterGorublyane.Core.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IRepository repository;

        public ActivityService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<ActivityQueryServiceModel> AllAsync(
            string? searchTerm = null, 
            ActivitySorting sorting = ActivitySorting.Newest, 
            int currentPage = 1, 
            int activitiesPerPage = 1)
        {
            var activitiesToShow = repository.AllReadOnly<Activity>();

            if (searchTerm != null)
            {
                string normalizedSearchTerm = searchTerm.ToLower();
                activitiesToShow = activitiesToShow
                    .Where(a => (a.Title.ToLower().Contains(normalizedSearchTerm) ||
                                a.Contact.ToLower().Contains(normalizedSearchTerm) ||
                                a.Description.ToLower().Contains(normalizedSearchTerm)));
            }

            activitiesToShow = sorting switch
            {
                ActivitySorting.Oldest => activitiesToShow.OrderBy(a => a.Id),
                _ => activitiesToShow.OrderByDescending(a => a.Id)
            };

            var activities = await activitiesToShow
                .Skip((currentPage - 1) * activitiesPerPage)
                .Take(activitiesPerPage)
                .Select(a => new ActivityServiceModel()
                {
                    Id = a.Id,
                    Title = a.Title,
                    Description = a.Description,
                    Contact = a.Contact,
                    ImageUrl = a.ImageUrl,
                })
                .ToListAsync();

            int totalActivities = await activitiesToShow.CountAsync();

            return new ActivityQueryServiceModel()
            {
                Activities = activities,
                TotalActivitiesCount = totalActivities
            };
        }

        public async Task<int> CreateAsync(ActivityFormModel model)
        {
            Activity activity = new Activity()
            {
                Title = model.Title,
                Description = model.Description,
                Contact = model.Contact,
                ImageUrl = model.ImageUrl,
            };

            await repository.AddAsync(activity);
            await repository.SaveChangesAsync();

            return activity.Id;
        }
    }
}
