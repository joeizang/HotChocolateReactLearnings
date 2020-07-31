using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyGraphqlBackend.Abstractions;
using MyGraphqlBackend.Context;
using MyGraphqlBackend.CustomExceptions;
using MyGraphqlDomain.Abstractions;
using MyGraphqlDomain.DomainModels;

namespace MyGraphqlBackend.Services
{
    public class DataService<T> : IDataService<T> where T : DomainModelBase
    {
        private readonly GQLDbContext _db;
        private DbSet<T> ? _set;

        public DataService(GQLDbContext db)
        {
            _db = db;
            _set = _db.Set<T>();
        }
        public async Task DeleteOne(T entity)
        {
            if (!(entity is null))
            {
                _db.Entry(entity).State = EntityState.Deleted;
                await _db.SaveChangesAsync().ConfigureAwait(false);
            }
            throw new ArgumentNullException("You cannot remove an entity that is null!");
        }

        public DbSet<T> GetAll()
        {
            return _set!;
        }

        public async Task<T> GetOne(int id)
        {
            var result = await _set!.FindAsync(id).ConfigureAwait(false);
            if (result is null)
                throw new NotFoundException("The Entity sought after could not be found!");

            return result;
        }

        public async Task UpdateOne(T? entity)
        {
            if (!(entity is null))
            {
                _db.Entry(entity).State = EntityState.Modified;
                await _db.SaveChangesAsync().ConfigureAwait(false);
            }
            throw new ArgumentNullException("You cannot update an entity that is null!");
        }
    }
}