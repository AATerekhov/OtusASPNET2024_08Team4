using BookOfHabitsMicroservice.Domain.Entity.Base;
using BookOfHabitsMicroservice.Domain.Entity.Enums;
using BookOfHabitsMicroservice.Domain.Entity.Propertys;
using BookOfHabitsMicroservice.Domain.ValueObjects;

namespace BookOfHabitsMicroservice.Domain.Entity
{
    public class Template : Entity<Guid>
    {
        private readonly ICollection<HabitCard> _habitCards = [];
        public IReadOnlyCollection<HabitCard> ImplementingСards => [.. _habitCards];
        public TemplateName TemplateName { get; }
        public TemplateValues TemplateValues { get; }
        public OptionTemplate Options { get; }
        public Template(Guid id, TemplateName templateName, TemplateValues templateValues, OptionTemplate optionTemplate ) :base(id)
        {
            TemplateName = templateName;
            templateValues.UseInTheTemplate(this);
            TemplateValues = templateValues;
            Options = optionTemplate;
        }
        public Template(TemplateName templateName, TemplateValues templateValues, OptionTemplate optionTemplate) 
            :this(Guid.NewGuid(), templateName, templateValues,optionTemplate)
        {
                
        }
        protected Template() : base(Guid.NewGuid())
        {
        }
    }
}
