using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Practica.Data;
using Practica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practica.Core.Repositories
{
    public class UserRepository: GenericRepository<User>, IUserRepository
    {
        public UserRepository(
            AppDbContext context,
            ILogger logger) : base(context, logger)
        {
            

        }

        public override async Task<IEnumerable<User>> All() {

            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {


                _logger.LogError(ex, "{Repo} all method error", typeof(UserRepository));
                return new List<User>();    
            }
        
        }

        public override async Task<bool> Upsert(User entity) {

            try
            {
                var existingUser = await dbSet.
                Where(x => x.UserId == entity.UserId).FirstOrDefaultAsync();

                if (existingUser == null)
                {
                    return await Add(entity);
                }
                existingUser.FirstName = entity.FirstName;
                existingUser.LastName = entity.LastName;
                existingUser.Email = entity.Email;

                return true;

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "{Repo} Upsert method error", typeof(UserRepository));
                return false;
            }
        }

        public override async Task<bool> Delete(Guid id) 
        {

            try
            {
                var exist = await dbSet.Where(x => x.UserId == id).FirstOrDefaultAsync();
                if (exist != null) 
                {
                    dbSet.Remove(exist);
                    return true;
                }

                return false;   
                       
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete method error", typeof(UserRepository));
                return false;
            }
        
        }
    } 
}
