using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.FileProviders;
using MyGraphqlBackend.Abstractions;
using MyGraphqlDomain.Abstractions;
using MyGraphqlDomain.DomainModels;

namespace MyGraphqlBackend.Services
{
    public class FileSystemService : IFileSystemService
    {
        public IEnumerable<IMovieFileInfo> GetAllFiles(string targetFolder, string[] searchPattern, SearchOption option)
        {
            MovieFileInfo[] files = { };

            try
            {
                DirectoryInfo dir = new DirectoryInfo(targetFolder);

                foreach (var pattern in searchPattern)
                {
                    files = dir.GetFiles(pattern, option).Select(x => new MovieFileInfo
                    {
                        MovieName = x.Name,
                        CreatedAt = x.CreationTime,
                        LocationOnDisk = x.FullName,
                        FileType = x.Extension,
                        MovieSize = x.Length,
                        Exists = x.Exists,
                        PlaybackTime = 65F, //create a method that will calculate playback time on the fly
                        Thumbnail = x.FullName
                    }).ToArray();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return files;
        }

        public IMovieFileInfo GetFile(string movieName)
        {
            throw new NotImplementedException();
        }

        public IList<IMovieFileInfo> FindFilesBy(FindFileCondition condition)
        {
            throw new NotImplementedException();
        }
    }
}
