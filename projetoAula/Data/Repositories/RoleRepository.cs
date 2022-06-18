using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DataContext _context;

        public RoleRepository(DataContext context)
        {
            this._context = context;
        }

        public bool Delete(int entityId)
        {
            var role = _context.DbSetRole.FirstOrDefault(x => x.Id == entityId);

            if (role == null)
                return false;
            else
            {
                _context.DbSetRole.Remove(role);
                return true;
            }
        }

        public async Task<IList<Role>> GetAllAsync()
        {
            return await _context.DbSetRole.ToListAsync();
        }

        public async Task<Role> GetByIdAsync(int entityId)
        {
            return await _context.DbSetRole
                .FirstOrDefaultAsync(x => x.Id == entityId);
        }

        public void Save(Role entity)
        {
            _context.DbSetRole.Add(entity);
        }

        public void Update(Role entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}