﻿using System;
namespace Library.LMSystem.Models
{
    public class AssignmentItem : ContentItem
    {
        public Assignment? Assignment {
            get;
            set;
        }
        public AssignmentItem()
        {
            Id = id++;
        }

        public AssignmentItem(ContentItem item) {
            Id = item.Id;
            Name = item.Name;
            Description = item.Description;
        }
    }
}

