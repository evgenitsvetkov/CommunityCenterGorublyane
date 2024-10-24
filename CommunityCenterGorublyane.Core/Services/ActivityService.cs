using CommunityCenterGorublyane.Core.Contracts;
using CommunityCenterGorublyane.Infrastructure.Data.Common;

namespace CommunityCenterGorublyane.Core.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IRepository repository;

        public ActivityService(IRepository _repository)
        {
            repository = _repository;
        }


    }
}
