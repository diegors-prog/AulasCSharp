using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using projetoCrud.Models.Domains;

namespace projetoCrud.Models.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private DataContext context;
        public AlunoRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<List<Aluno>> GetAllAsync()
        {
            return await context.Alunos.ToListAsync();
        }

        public async Task<Aluno> GetByIdAsync(int id)
        {
            return await context.Alunos.SingleOrDefaultAsync(x => x.Id == id);
        }

        public void Create(Aluno aluno)
        {
            context.Add(aluno);
        }

        public bool Delete(int alunoId)
        {
            var aluno = context.Alunos.FirstOrDefault(i => i.Id == alunoId);

            if (aluno == null)
                return false;
            else
            {
                context.Alunos.Remove(aluno);
                return true;
            }
        }

        public void Update(Aluno aluno)
        {
            context.Entry(aluno).State = EntityState.Modified;
        }
    }
}