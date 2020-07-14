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
    string TargetPath { get; }
    string[]? SearchPattern { get; }

    SearchOption? SearchOption { get; }

    EnumerationOptions EnumerationOptions { get; }
    Task<IEnumerable<IMovieFileInfo>> GetAllFiles();

    Task<IMovieFileInfo> GetFile(string movieName);

    Task<IEnumerable<IMovieFileInfo>> FindFilesBy(FindFileCondition condition);
  }

  public class FindFileCondition
  {
    public virtual DateTimeOffset? MovieDate { get; set; }

    public virtual string? MovieName { get; set; }

    public virtual float? MovieLength { get; set; }
  }
}
