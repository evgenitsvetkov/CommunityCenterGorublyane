using CommunityCenterGorublyane.Core.Models.Admin.User;

namespace CommunityCenterGorublyane.Core.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<UserServiceModel>> AllAsync();
    }
}
