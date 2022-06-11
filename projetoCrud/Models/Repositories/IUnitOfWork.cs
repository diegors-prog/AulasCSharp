using System.Threading.Tasks;

namespace projetoCrud.Models.Repositories
{
    public interface IUnitOfWork
    {
        Task CommitAsync();

        IAlunoRepository AlunoRepository { get; }
    }
}
