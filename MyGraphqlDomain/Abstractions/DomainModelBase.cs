using System;
using System.Collections.Generic;
using System.Text;

namespace MyGraphqlDomain.Abstractions
{
    public abstract class DomainModelBase : IDomainModel
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedAt { get ; set; }
        public DateTimeOffset ModifiedAt { get; set; }
    }
}
