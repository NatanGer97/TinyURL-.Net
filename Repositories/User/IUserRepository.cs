using TinyUrlClone.Models;

namespace TinyUrlClone.Repositories.User
{
    public interface IUserRepository
    {
        Task<IList<Models.User>> GetUsersAsync();
        Task<Models.User> GetUserAsync(Guid id);
        Task<Models.User> CreateUserAsync(Models.User user);
    }
}
