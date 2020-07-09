using System;
using System.Collections.Generic;
using System.Text;

namespace MyGraphqlDomain.Abstractions
{
    public interface IDomainModel
    {
        DateTimeOffset CreatedAt { get; set; }
        DateTimeOffset ModifiedAt { get; set; }
    }
}
