using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.FileProviders;
using MyGraphqlBackend.Abstractions;

namespace MyGraphqlBackend.Services
{
    public class FileSystemService : IFileSystemService
    {
        public IEnumerable<FileInfo> GetAllFiles(string targetFolder, string[] searchPattern, SearchOption option)
        {
            FileInfo[] files = { };
            var dir = new DirectoryInfo(targetFolder);

            foreach (var pattern in searchPattern)
            {
                files = dir.GetFiles(pattern, option);
            }

            return files;
        }

        public IFileInfo GetFile(string movieName)
        {
            throw new NotImplementedException();
        }

        public IList<IFileInfo> FindFilesBy(FindFileCondition condition)
        {
            throw new NotImplementedException();
        }
    }
}
