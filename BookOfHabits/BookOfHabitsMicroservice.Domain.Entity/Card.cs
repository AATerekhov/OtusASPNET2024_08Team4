using BookOfHabitsMicroservice.Domain.Entity.Base;
using BookOfHabitsMicroservice.Domain.Entity.Enums;
using BookOfHabitsMicroservice.Domain.Entity.Propertys;
using BookOfHabitsMicroservice.Domain.ValueObjects;

namespace BookOfHabitsMicroservice.Domain.Entity
{
    public class Card : Entity<Guid>
    {
        //public Habit Habit { get; }
        public CardOptions Options { get; private set; }
        public CardName Name { get; private set; }
        public TemplateValues TemplateValues { get; }
        public string Description { get; private set; }
        public byte[]? Image { get; private set; }
        public string TitlesCheck { get; private set; }  //List
        public string[] TitleCheckElements => TitlesCheck.Split(';', StringSplitOptions.RemoveEmptyEntries);
        public bool IsPublic { get; private set; }
        public Card(Guid id, CardName name, CardOptions options, TemplateValues titles, string description)
            : base(id)
        {
            Name = name;
            Options = options;
            TemplateValues = titles;
            Description = description;
            TitlesCheck = string.Empty;
            IsPublic = true;
        }
        public Card(CardName name, CardOptions options, TemplateValues titles, string description)
            : this(Guid.NewGuid(), name, options, titles, description)
        {

        }
        protected Card() : base(Guid.NewGuid())
        {

        }
        public void SetName(string name) => Name = new CardName(name);
        public void SetDescription(string description) => Description = description;
        public void SetImage(byte[] image) => Image = image;
        public void SetTitlesCheck(string[] titleCheckElements) => TitlesCheck = string.Join(";", titleCheckElements);
        public void SetOptions(CardOptions options) => Options = options;
        internal void Close() => IsPublic = false;
        internal Card DeepCopy()
        {
            var result = new Card(name: new CardName(this.Name.Name),
                                  options: this.Options,
                                  titles: TemplateValues.DeepCopy(),
                                  description: this.Description);
            result.Close();
            result.SetTitlesCheck(this.TitleCheckElements);
            if (this.Image is not null)
                result.SetImage(this.Image.ToArray());
            return result;
        }
    }
}
