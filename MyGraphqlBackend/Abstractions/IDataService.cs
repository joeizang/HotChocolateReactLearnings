using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyGraphqlDomain.Abstractions;
using MyGraphqlDomain.DomainModels;

namespace MyGraphqlBackend.Abstractions
{
    public interface IDataService<T> where T : DomainModelBase
    {
        DbSet<T> GetAll();

        Task<T> GetOne(int id);

        Task UpdateOne(T entity);

        Task DeleteOne(T entity);
    }
}