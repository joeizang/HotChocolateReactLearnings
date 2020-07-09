using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.FileProviders;

namespace MyGraphqlBackend.Abstractions
{
    public interface IFileSystemService
    {
        IEnumerable<FileInfo> GetAllFiles(string targetFolder, string[] searchPattern, SearchOption option);

        IFileInfo GetFile(string movieName);

        IList<IFileInfo> FindFilesBy(FindFileCondition condition);
    }

    public class FindFileCondition
    {
        public DateTimeOffset? MovieDate { get; set; }

        public string? MovieName { get; set; }

        public float? MovieLength { get; set; }
    }
}
