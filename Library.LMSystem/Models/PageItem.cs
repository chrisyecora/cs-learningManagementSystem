using System;
namespace Library.LMSystem.Models
{
    public class PageItem : ContentItem
    {
        public string? HTMLBody {
            get;
            set;
        }

        public override string Display => base.Display;

        public PageItem()
        {
        }
    }
}

