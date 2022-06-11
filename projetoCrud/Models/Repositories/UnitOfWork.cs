using System;
using System.Threading.Tasks;

namespace projetoCrud.Models.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            this._context = context;
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        private IAlunoRepository _AlunoRepository;


        public IAlunoRepository AlunoRepository
        {
            get { return _AlunoRepository ??= new AlunoRepository(_context); }
        }
    }
}
