using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyGraphqlBackend.Context
{
    public class GQLDbContext : DbContext
    {
        public GQLDbContext(DbContextOptions<GQLDbContext> options) : base(options)
        {
            
        }
    }
}
