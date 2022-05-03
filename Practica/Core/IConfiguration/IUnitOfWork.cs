using Practica.Core.Repositories;
using System.Threading.Tasks;

namespace Practica.IConfiguration
{
    public interface IUnitOfWork
    {

        IUserRepository Users { get; }

        Task CompleteAsync();
    }
}
