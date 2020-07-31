using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.FileProviders;
using MyGraphqlBackend.Abstractions;
using MyGraphqlDomain.Abstractions;
using MyGraphqlDomain.DomainModels;
using Xabe.FFmpeg;

namespace MyGraphqlBackend.Services
{
    public class FileSystemService : IFileSystemService
    {
        public FileSystemService(string targetFolder, string[] ? searchPattern, SearchOption? options, EnumerationOptions? enumerationOptions)
        {
            if (targetFolder.Equals(string.Empty) || targetFolder.Count() < 2)
                throw new ArgumentException("The filesystem path provided is in an invalid state!");
            TargetPath = targetFolder;

            DirInfo = new DirectoryInfo(TargetPath);

            //check the state of the array of search patterns to know what to do.
            if (searchPattern is null)
            {
                SearchPattern = new string[] { "*.mp4", "*.mkv", "*.flv", "*.avi", "*.mpg" };
            }
            else
            {
                SearchPattern = searchPattern;
            }

            //check the state of SearchOptions
            if (options is null)
            {
                this.SearchOption = System.IO.SearchOption.TopDirectoryOnly;
            }
            this.SearchOption = options;

            if (enumerationOptions is null)
            {
                this.EnumerationOptions = new System.IO.EnumerationOptions { MatchCasing = MatchCasing.CaseInsensitive, RecurseSubdirectories = true };
            }
            else
            {
                this.EnumerationOptions = enumerationOptions;
            }
        }
        public string TargetPath { get; }

        public string[] ? SearchPattern { get; }

        public SearchOption? SearchOption { get; }

        public EnumerationOptions EnumerationOptions { get; }

        private DirectoryInfo DirInfo { get; set; }

        public async Task<IEnumerable<IMovieFileInfo>> GetAllFiles()
        {
            FileInfo[] temp = { };

            try
            {

                foreach (var pattern in SearchPattern!)
                {
                    temp = DirInfo.GetFiles(pattern, EnumerationOptions);
                }
                MovieFileInfo[] files = await Task.WhenAll(temp.Select(CreateMovieFileInfo));
                return files;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IMovieFileInfo> GetFile(string movieName)
        {
            MovieFileInfo file;

            try
            {
                FileInfo temp = null!;

                foreach (var pattern in SearchPattern!)
                {
                    temp = DirInfo.GetFiles(pattern, EnumerationOptions)
                        .SingleOrDefault(x => x.Name.Equals(movieName) || x.FullName.Contains(movieName));
                }
                file = await CreateMovieFileInfo(temp);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return file;
        }

        public async Task<IEnumerable<IMovieFileInfo>> FindFilesBy(FindFileCondition condition)
        {
            FileInfo[] temp = null!;

            if (!(SearchPattern is null))
            {
                foreach (var pattern in SearchPattern)
                {
                    temp = DirInfo
                        .GetFiles(pattern, EnumerationOptions)
                        .Where(x => condition?.MovieName != null && (x.Name.Contains(condition.MovieName)))
                        .ToArray();
                }

                return await Task.WhenAll(temp.Select(CreateMovieFileInfo));
            }
            else
            {
                return new List<MovieFileInfo>();
            }

        }

        private async Task<MovieFileInfo> CreateMovieFileInfo(FileInfo file)
        {
            var mediaTemp =
                new MovieFileInfo
                {
                    LocationOnDisk = file.FullName,
                    MovieName = file.Name,
                    MovieSize = file.Length,
                    CreatedAt = file.CreationTime,
                    Exists = file.Exists,
                    Thumbnail = file.FullName,
                    PlaybackTime = await CalculatePlaybackTime(file.FullName),
                    FileType = file.Extension
                };
            return mediaTemp;
        }

        private async Task<TimeSpan> CalculatePlaybackTime(string filePath)
        {
            TimeSpan mediaDuration;
            try
            {
                var mediaInfo = await FFmpeg.GetMediaInfo(filePath);
                mediaDuration = mediaInfo.Duration;
            }
            catch (System.Exception)
            {
                mediaDuration = TimeSpan.MinValue;
            }
            return mediaDuration;
        }
    }
}