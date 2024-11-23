using System.ComponentModel.DataAnnotations;

namespace CommunityCenterGorublyane.Core.Models.Admin.User
{
    public class UserServiceModel
    {
        [Display(Name = "Имейл")]
        public string Email { get; set; } = null!;
    }
}
