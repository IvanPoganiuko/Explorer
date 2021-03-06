﻿using System.IO;

namespace FileTreeGrids.Extensions
{
    public static class FileSystemInfoExtensions
    {
        public static FileSystemInfo GetInfo(string path)
        {
            if (PathExtensions.IsDirectory(path))
            {
                return new DirectoryInfo(path);
            }

            return new FileInfo(path);
        }
    }
}
