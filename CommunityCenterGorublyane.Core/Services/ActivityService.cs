using CommunityCenterGorublyane.Core.Contracts;
using CommunityCenterGorublyane.Core.Models.Activity;
using CommunityCenterGorublyane.Infrastructure.Data.Common;
using CommunityCenterGorublyane.Infrastructure.Data.Models;

namespace CommunityCenterGorublyane.Core.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IRepository repository;

        public ActivityService(IRepository _repository)
        {
            repository = _repository;
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
