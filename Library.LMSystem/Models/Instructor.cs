using System;
namespace Library.LMSystem.Models
{
    public class Instructor : Person
    {
        public Instructor()
        {
        }

        public Instructor(Person person) {
            Name = person.Name;
        }
    }
}

