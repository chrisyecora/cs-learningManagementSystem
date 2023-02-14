using System;
namespace Library.LMSystem.Models
{
    public class Announcement
    {
        public string? Title {
            get;
            set;
        }

        public string? Body {
            get;
            set;
        }

        public string Display => $"{Title}: {Body}";
        public Announcement() {
        }
    }
}

