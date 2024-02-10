using Microsoft.EntityFrameworkCore;
using TinyUrlClone.Data;
using TinyUrlClone.Models;

namespace TinyUrlClone.Repositories.User
{
    public class UserRepository : BaseRepository
    {
        public UserRepository(ApiDbContext context) : base(context)
        {
        }

        public async Task<List<Models.User>> FindUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<Models.User?> FindUserByIdAsync(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task UpdateUser(Models.User updatedUser)
        {
            _context.Entry(updatedUser).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }

        public async Task CreateUser(Models.User newUser)
        {
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            
        }

        public async Task DeleteUser(Models.User userToDelete)
        {
            _context.Users.Remove(userToDelete);
            await _context.SaveChangesAsync();
        }

        public bool UserExist(Guid id)
        {
            bool? isExist = _context.Users?.Any(user => user.Id == id);
            return isExist.GetValueOrDefault();
        }

        public bool UserExist(string username)
        {
            bool? isExist = _context.Users?.Any(user => user.UserName == username);
            return isExist.GetValueOrDefault();
        }
    }
}
