using System;
namespace Library.LMSystem.Models
{
    public class TeachingAssistant : Person
    {
        public TeachingAssistant()
        {
        }
        public TeachingAssistant(Person person) {
            Name = person.Name;
        }
    }
}

