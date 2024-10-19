using BookOfHabitsMicroservice.Domain.Entity.Base;

namespace BookOfHabitsMicroservice.Domain.Entity.Propertys
{
    public class TemplateValues : Property
    {
        public Template Template { get; }
        public string Status { get; } //List
        public string TitleValue { get; }
        public string TitleCheck { get; }
        public string TitleReportField { get; }
        public string Tags { get; } //List
        public string TitlePositive { get; }
        public string TitleNegative { get; }

        public TemplateValues(Guid id,Template template, string status, string titleValue, string titleCheck, string titleReportField, string tags, string titlePositive, string titleNegative)
            :base(id, "TemplateValues")
        {
            Template = template;
            Status = status;
            TitleValue = titleValue;
            TitleCheck = titleCheck;
            TitleReportField = titleReportField;
            Tags = tags;
            TitlePositive = titlePositive;
            TitleNegative = titleNegative;
        }
        public TemplateValues(Template template, string status, string titleValue, string titleCheck, string titleReportField, string tags, string titlePositive, string titleNegative)
            :this(Guid.NewGuid(), template, status, titleValue,titleCheck,titleReportField,tags,titlePositive, titleNegative)
        {
                
        }
        protected TemplateValues(Template template)
            :base(Guid.NewGuid(), "TemplateValues")
        {
            Template = template;
        }
    }
}
