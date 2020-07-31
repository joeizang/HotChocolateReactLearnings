using System.Collections.Generic;
using HotChocolate.Types;
using MyGraphqlBackend.GraphQL.Schema;

namespace MyGraphqlBackend.GraphQL.Queries.Movies
{
    public class MovieQueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Field(q => q.GetMoviesAsync(default !))
                .UseFiltering()
                .UseSorting()
                .Type<NonNullType<ListType<MovieType>>>();
            descriptor.Field(q => q.GetMovieAsync(default !, default !))
                .Argument("id", x => x.Type<NonNullType<IntType>>());

        }
    }
}