using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Bogus;
using Microsoft.Extensions.FileProviders;
using MyGraphqlBackend.Abstractions;
using MyGraphqlDomain.Abstractions;
using MyGraphqlDomain.DomainModels;
using NSubstitute;
using Xunit;

namespace MyGraphqlXunitTests.FileSystemServiceTests
{

    public class FileSystemServiceTest
    {
        [Fact]
        public async void GetAllFilesReturnsEnumerableWithFileInfos()
        {
            //var file = Substitute.For<IMovieFileInfo>();
            var fakeFiles = new Faker<MovieFileInfo>();
            fakeFiles
                .RuleFor(x => x.MovieName, y => y.System.FileName("mp4"))
                .RuleFor(x => x.MovieSize, y => y.System.Random.Long())
                .RuleFor(x => x.Exists, y => true)
                .RuleFor(x => x.CreatedAt, y => y.Date.Recent(40))
                .RuleFor(x => x.LocationOnDisk, y => y.System.DirectoryPath())
                .RuleFor(x => x.FileType, y => y.System.FileExt("mp4"))
                .RuleFor(x => x.PlaybackTime, y => y.Date.Timespan())
                .RuleFor(x => x.Thumbnail, y => y.System.FilePath())
                .RuleFor(x => x.Genre, y => y.Random.Enum<MovieGenre>());
            var files = fakeFiles.Generate(5);

            var pattern = new string[] { "*.mp4" };

            var enumOpt = new EnumerationOptions { RecurseSubdirectories = true, MatchCasing = MatchCasing.CaseInsensitive };

            var fileService = Substitute.For<IFileSystemService>();

            fileService
                .GetAllFiles()
                .Returns(files);

            //Act
            var result = await fileService.GetAllFiles();

            //Assert
            Assert.IsAssignableFrom<IEnumerable<IMovieFileInfo>>(result);
            Assert.All(result, item => item.FileType.Contains("mp4"));
            Assert.NotNull(result);
        }

        // public async void GetFileReturnsSingleMovieFileInfo()
        // {

        // }
    }
}