using TinyUrlClone.Models;
using TinyUrlClone.Repositories.User;

namespace TinyUrlClone.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IList<User>> GetUsersAsync()
        {
            return await _userRepository.FindUsersAsync();
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            User? user= await _userRepository.FindUserByIdAsync(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            return user;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            bool isUserExist = _userRepository.UserExist(user.UserName!);
            if (isUserExist)
            {
                throw new Exception("User already exist");
            }
            await _userRepository.CreateUser(user);


            return user;
        }

        public async Task UpdateUser(User updatedUser, Guid userId)
        {
            if (!_userRepository.UserExist(userId))
            {
                throw new Exception("User not found");
            }

            await _userRepository.UpdateUser(updatedUser);
        }

        public async Task DeleteUser(Guid id)
        {
            User user = await this.GetUserByIdAsync(id);

            await _userRepository.DeleteUser(user);
        }
    }
}
