using CommunityCenterGorublyane.Core.Contracts;
using CommunityCenterGorublyane.Core.Models.Admin.User;
using CommunityCenterGorublyane.Infrastructure.Data.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CommunityCenterGorublyane.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repository;

        public UserService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IEnumerable<UserServiceModel>> AllAsync()
        {
            return await repository.AllReadOnly<IdentityUser>()
                .Select(u => new UserServiceModel()
                {
                    Email = u.Email
                })
                .ToListAsync();
        }
    }
}
