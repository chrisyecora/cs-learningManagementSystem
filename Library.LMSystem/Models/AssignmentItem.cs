using System;
namespace Library.LMSystem.Models
{
    public class AssignmentItem : ContentItem
    {
        public Assignment? Assignment {
            get;
            set;
        }

        public override string Display => base.Display;
        public AssignmentItem()
        {
        }
    }
}

