using Practica.Models;
using System;
using System.Threading.Tasks;

namespace Practica.Core.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        //Task<string> GetFirstNameAndLastName(Guid id);
        Task<bool> Upsert(User entity);
    }
}
