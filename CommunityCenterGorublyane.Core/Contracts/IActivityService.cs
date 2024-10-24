using CommunityCenterGorublyane.Core.Models.Activity;

namespace CommunityCenterGorublyane.Core.Contracts
{
    public interface IActivityService
    {
        Task<int> CreateAsync(ActivityFormModel model);
    }
}
