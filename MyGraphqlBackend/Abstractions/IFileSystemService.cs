using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.FileProviders;
using MyGraphqlDomain.Abstractions;

namespace MyGraphqlBackend.Abstractions
{
    public interface IFileSystemService
    {
        IEnumerable<IMovieFileInfo> GetAllFiles(string targetFolder, string[] searchPattern, SearchOption option);

        IMovieFileInfo GetFile(string movieName);

        IList<IMovieFileInfo> FindFilesBy(FindFileCondition condition);
    }

    public class FindFileCondition
    {
        public virtual DateTimeOffset? MovieDate { get; set; }

        public virtual string? MovieName { get; set; }

        public virtual float? MovieLength { get; set; }
    }
}
