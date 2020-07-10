using System;
using System.Collections.Generic;
using System.Text;
using MyGraphqlDomain.DomainModels;

namespace MyGraphqlDomain.Abstractions
{
    public interface IMovieFileInfo : IDomainModel
    {
        string MovieName { get; set; }

        long MovieSize { get; set; }

        bool Exists { get; set; }

        string LocationOnDisk { get; set; }

        string FileType { get; set; }

        float PlaybackTime { get; set; }

        MovieGenre? Genre { get; set; }

        string Thumbnail { get; set; }
    }
}
