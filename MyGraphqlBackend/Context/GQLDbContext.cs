using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyGraphqlDomain.DomainModels;

namespace MyGraphqlBackend.Context
{
  public class GQLDbContext : DbContext
  {
    public GQLDbContext(DbContextOptions<GQLDbContext> options) : base(options)
    {

    }

    public DbSet<Movie>? Movies { get; set; }
  }
}
