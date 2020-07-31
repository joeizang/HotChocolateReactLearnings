using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using Microsoft.EntityFrameworkCore;
using MyGraphqlBackend.CustomExceptions;
using MyGraphqlBackend.Services;
using MyGraphqlDomain.DomainModels;

namespace MyGraphqlBackend.GraphQL.Queries.Movies
{
    public class Query
    {
        public async Task<IEnumerable<Movie>> GetMoviesAsync([Service] DataService<Movie> service)
        {
            return await service.GetAll()
                .OrderBy(m => m.MovieName)
                .ThenBy(m => m.CreatedAt)
                .ToListAsync().ConfigureAwait(false);
        }

        public async Task<Movie> GetMovieAsync([Service] DataService<Movie> service, int id)
        {
            try
            {
                return await service.GetOne(id).ConfigureAwait(false);
            }
            catch (NotFoundException)
            {
                throw;
            }
        }
    }
}