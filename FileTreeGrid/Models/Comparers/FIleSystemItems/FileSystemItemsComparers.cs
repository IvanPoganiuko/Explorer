﻿using FileTreeGrid.Models.Comparers.FIleSystemItems;
using FileTreeGrids.Models.FileSystemItems;
using System.Collections.Generic;

namespace FileTreeGrid.Models.Comparers.FileSystemItems
{
    public static class FileSystemItemsComparers
    {
        //Static fields
        public static IComparer<FileSystemItem> NameComparer;

        //Constructors
        static FileSystemItemsComparers()
        {
            NameComparer = new NameComparer();
        }
    }
}
