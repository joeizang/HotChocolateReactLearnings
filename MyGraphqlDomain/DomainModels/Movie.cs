using System;
using System.Collections.Generic;
using System.Text;
using MyGraphqlDomain.Abstractions;
namespace MyGraphqlDomain.DomainModels
{
    public class Movie : DomainModelBase
    {
        public string MovieName { get; set; }
        
        public long MovieSize { get; set; }

        public string LocationOnDisk { get; set; }
        
        public string FileType { get; set; }

        public float PlaybackTime { get; set; }

        public MovieGenre Genre { get; set; }

        public string Thumbnail { get; set; }

    }
}
