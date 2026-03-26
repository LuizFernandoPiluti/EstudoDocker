using EstudoDocker.DataBase.Context;
using EstudoDocker.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace EstudoDocker.DataBase.Repositories
{
    public class BaseRepository<TEntity> : IBaseRespository<TEntity> where TEntity : class
    {
        protected readonly EstudoDockerDbContext _context;
    
        public async Task  AddAsync(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
           await  _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var obj = await GetByIdAsync(id).ConfigureAwait(false);
            await DeleteAsync(obj);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return null;
            }
            else
            {
                return entity;
            }
        }

        public async Task UpdateAsync(TEntity entity)
        {
       
           _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
