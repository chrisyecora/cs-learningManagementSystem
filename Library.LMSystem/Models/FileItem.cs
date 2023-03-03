using System;
namespace Library.LMSystem.Models
{
    public class FileItem : ContentItem
    {
        public string? Path {
            get;
            set;
        }

        public FileItem()
        {
            Id = id++;
            Path = string.Empty;
        }

        public FileItem(ContentItem item) {
            Id = item.Id;
            Name = item.Name;
            Description = item.Description;
            Path = string.Empty;
        }
    }
}

