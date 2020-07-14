using System;
using System.Collections.Generic;
using System.Text;
using MyGraphqlDomain.DomainModels;

namespace MyGraphqlDomain.Abstractions
{
    public class MovieFileInfo : IMovieFileInfo
    {
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset ModifiedAt { get; set; }
        public string MovieName { get; set; } = null!;
        public long MovieSize { get; set; }
        public bool Exists { get; set; }
        public string LocationOnDisk { get; set; } = null!;
        public string FileType { get; set; } = null!;
        public TimeSpan PlaybackTime { get; set; }
        public MovieGenre? Genre { get; set; }
        public string Thumbnail { get; set; } = null!;
    }
}
