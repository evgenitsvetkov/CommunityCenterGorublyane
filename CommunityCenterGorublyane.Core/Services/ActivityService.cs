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

        public async Task<ActivityDetailsServiceModel> ActivityDetailsByIdAsync(int id)
        {
            return await repository.AllReadOnly<Activity>()
                .Where(a => a.Id == id)
                .Select(a => new ActivityDetailsServiceModel()
                {
                    Id = a.Id,
                    Title = a.Title,
                    Description = a.Description,
                    Contact = a.Contact,
                    ImageUrl = a.ImageUrl
                })
                .FirstAsync();
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
                .ProjectToActivityServiceModel()
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

        public async Task EditAsync(int activityId, ActivityFormModel model)
        {
            var activity = await repository.GetByIdAsync<Activity>(activityId);

            if (activity != null)
            {
                activity.Title = model.Title;
                activity.Description = model.Description;
                activity.Contact = model.Contact;
                activity.ImageUrl = model.ImageUrl;

                await repository.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await repository.AllReadOnly<Activity>()
                .AnyAsync(a => a.Id == id);
        }

        public async Task<ActivityFormModel?> GetActivityFormModelAsync(int id)
        {
            return await repository.AllReadOnly<Activity>()
                .Where(a => a.Id == id)
                .Select(a => new ActivityFormModel()
                {
                    Title = a.Title,
                    Description = a.Description,
                    Contact = a.Contact,
                    ImageUrl = a.ImageUrl
                })
                .FirstOrDefaultAsync();
        }
    }
}
