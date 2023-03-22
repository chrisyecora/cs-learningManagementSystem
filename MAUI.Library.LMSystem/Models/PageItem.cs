using System;
namespace Library.LMSystem.Models
{
    public class PageItem : ContentItem
    {
        public string? HTMLBody {
            get;
            set;
        }

        public PageItem()
        {
            Id = id++;
            HTMLBody = string.Empty;
        }

        public PageItem(ContentItem item) {
            Id = item.Id;
            Name = item.Name;
            Description = item.Description;
            HTMLBody = string.Empty;
        }
    }
}

