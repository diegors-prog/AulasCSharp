using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.Context;
using WebApi.Domain.Entities;
using WebApi.Domain.Interfaces.RepositoryInterfaces;

namespace WebApi.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext Context;

        public UserRepository(DataContext context)
        {
            this.Context = context;
        }


        public async Task<IList<User>> GetAllAsync()
        {
            return await Context.DbSetUser.ToListAsync();
        }

        public async Task<User> GetByIdAsync(long userId)
        {
            return await Context.DbSetUser
                .FirstOrDefaultAsync(i => i.Id == userId);
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await Context.DbSetUser
                .AsNoTracking()
                .Include(i => i.Roles)
                .FirstOrDefaultAsync(i => i.Email == email);
        }

        public void Save(User user)
        {
            Context.DbSetUser.Add(user);
        }

        public void Update(User user)
        {
            Context.Entry(user).State = EntityState.Modified;
        }

        public bool Delete(long userId)
        {
            var user = Context.DbSetUser.FirstOrDefault(i => i.Id == userId);

            if (user == null)
                return false;
            else
            {
                Context.DbSetUser.Remove(user);
                return true;
            }
        }
    }
}
