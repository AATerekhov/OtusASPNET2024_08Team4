using BookOfHabitsMicroservice.Domain.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BookOfHabitsMicroservice.Domain.Entity
{
    public class HabitCard : Entity<Guid>
    {
        public Template Template { get; }
        public Habit  Habit { get; }
        public string Description { get; }
        public byte[] Image { get; }
        public string TitleCheckElements { get; }  //List
        public HabitCard(Guid id,Template template, Habit habit, string description, byte[] image, string titleCheckElements)
            :base(id)
        {
            Template = template;
            Habit = habit;
            Description = description;
            Image = image;
            TitleCheckElements = titleCheckElements;
        }
        public HabitCard(Template template, Habit habit, string description, byte[] image, string titleCheckElements)
            : this(Guid.NewGuid(), template, habit, description, image,titleCheckElements) 
        { 

        }
        protected HabitCard(Guid id) : base(id)
        {

        }
    }
}
