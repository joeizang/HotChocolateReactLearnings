using System;
using System.Collections.Generic;
using System.Text;
using MyGraphqlDomain.Abstractions;
namespace MyGraphqlDomain.DomainModels
{
    public class Movie : DomainModelBase
    {
        public string MovieName { get; set; } = null!;

        public long MovieSize { get; set; }

        public string LocationOnDisk { get; set; } = null!;

        public string FileType { get; set; } = null!;

        public DateTimeOffset PlaybackTime { get; set; } // should be a TimeSpan or a long

        public MovieGenre Genre { get; set; }

        public string Thumbnail { get; set; } = null!;

    }
}