using HotChocolate.Types;
using MyGraphqlDomain.DomainModels;

namespace MyGraphqlBackend.GraphQL.Schema
{
    public class MovieType : ObjectType<Movie>
    {
        protected override void Configure(IObjectTypeDescriptor<Movie> descriptor)
        {
            descriptor.Field(m => m.FileType)
                .Type<NonNullType<StringType>>();
            descriptor.Field(m => m.Id)
                .Type<NonNullType<IntType>>();
            descriptor.Field(m => m.Genre)
                .Type<NonNullType<MovieGenreType>>();
            descriptor.Field(m => m.LocationOnDisk)
                .Type<NonNullType<StringType>>();
            descriptor.Field(m => m.CreatedAt)
                .Type<NonNullType<DateTimeType>>();
            descriptor.Field(m => m.ModifiedAt)
                .Type<NonNullType<DateTimeType>>();
            descriptor.Field(m => m.MovieName)
                .Type<NonNullType<StringType>>();
            descriptor.Field(m => m.MovieSize)
                .Type<NonNullType<LongType>>();
            descriptor.Field(m => m.PlaybackTime)
                .Type<NonNullType<DateTimeType>>(); //cast this back to DateTime and extract TimeOfDay
            descriptor.Field(m => m.Thumbnail)
                .Type<StringType>();
        }
    }
}