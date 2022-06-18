using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            this._context = context;
        }
        
        public bool Delete(int entityId)
        {
            var user = _context.DbSetUser.FirstOrDefault(x => x.Id == entityId);

            if(user == null)
                return false;
            else
            {
                _context.DbSetUser.Remove(user);
                return true;
            }
        }

        public async Task<IList<User>> GetAllAsync()
        {
            return await _context.DbSetUser.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int entityId)
        {
            return await _context.DbSetUser
                .FirstOrDefaultAsync(x => x.Id == entityId);
        }

        public void Save(User entity)
        {
            _context.DbSetUser.Add(entity);
        }

        public void Update(User entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.DbSetUser
                .AsNoTracking()
                .Include(i => i.Roles)
                .FirstOrDefaultAsync(i => i.Email == email);
        }
    }
}