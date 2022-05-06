using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.Context;
using WebApi.Domain.Entities;
using WebApi.Domain.Interfaces.RepositoryInterfaces;

namespace WebApi.Data.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DataContext Context;

        public RoleRepository(DataContext context)
        {
            this.Context = context;
        }


        public async Task<IList<Role>> GetAllAsync()
        {
            return await Context.DbSetRole.ToListAsync();
        }

        public async Task<Role> GetByIdAsync(long roleId)
        {
            return await Context.DbSetRole
                .FirstOrDefaultAsync(i => i.Id == roleId);
        }

        public void Save(Role role)
        {
            Context.DbSetRole.Add(role);
        }

        public void Update(Role role)
        {
            Context.Entry(role).State = EntityState.Modified;
        }

        public bool Delete(long roleId)
        {
            var role = Context.DbSetRole.FirstOrDefault(i => i.Id == roleId);

            if (role == null)
                return false;
            else
            {
                Context.DbSetRole.Remove(role);
                return true;
            }
        }
    }
}
