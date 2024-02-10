using TinyUrlClone.Data;

namespace TinyUrlClone.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly ApiDbContext _context;

        protected BaseRepository(ApiDbContext context)
        {
            _context = context;
        }
    }
}
