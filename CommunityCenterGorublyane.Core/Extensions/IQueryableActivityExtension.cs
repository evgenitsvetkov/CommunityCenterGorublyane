using CommunityCenterGorublyane.Core.Models.Activity;
using CommunityCenterGorublyane.Infrastructure.Data.Models;

namespace System.Linq
{
    public static class IQueryableActivityExtension
    {
        public static IQueryable<ActivityServiceModel> ProjectToActivityServiceModel(this IQueryable<Activity> activities)
        {
            return activities.Select(a => new ActivityServiceModel()
            {
                Id = a.Id,
                Title = a.Title,
                //Description = a.Description,
                //Contact = a.Contact,
                ImageUrl = a.ImageUrl
            });
        }
    }
}
