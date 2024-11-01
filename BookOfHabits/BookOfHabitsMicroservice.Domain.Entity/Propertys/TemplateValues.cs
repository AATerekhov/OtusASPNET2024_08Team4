using BookOfHabitsMicroservice.Domain.Entity.Base;

namespace BookOfHabitsMicroservice.Domain.Entity.Propertys
{
    public class TemplateValues : Property
    {
        //public Card Card { get; }
        public string StatusString { get; private set; } //List
        public string[] Status => StatusString.Split(';', StringSplitOptions.RemoveEmptyEntries);
        public string TitleValue { get; private set; }
        public string TitleCheck { get; private set; }
        public string TitleReportField { get; private set; }
        public string TagsString { get; private set; } //List
        public string[] Tags => TagsString.Split(';', StringSplitOptions.RemoveEmptyEntries);
        public string TitlePositive { get; private set; }
        public string TitleNegative { get; private set; }

        public TemplateValues(Guid id , string status, string titleValue, string titleCheck, string titleReportField, string tags, string titlePositive, string titleNegative)
            :base(id, "TemplateValues")
        {
            StatusString = status;
            TitleValue = titleValue;
            TitleCheck = titleCheck;
            TitleReportField = titleReportField;
            TagsString = tags;
            TitlePositive = titlePositive;
            TitleNegative = titleNegative;
        }
        public TemplateValues(string status, string titleValue, string titleCheck, string titleReportField, string tags, string titlePositive, string titleNegative)
            :this(Guid.NewGuid(), status, titleValue,titleCheck,titleReportField,tags,titlePositive, titleNegative)
        {
                
        }

        protected TemplateValues()
            : base(Guid.NewGuid(), "TemplateValues")
        {

        }
        public void SetStatus(string[] status) => StatusString = string.Join(";", status);
        public void SetTags(string[] tags) => TagsString = string.Join(";", tags);
        public void SetTitleValue(string titleValue) => TitleValue = titleValue;
        public void SetTitleCheck(string titleCheck) => TitleCheck = titleCheck;
        public void SetTitleReportField(string titleReportField) => TitleReportField = titleReportField;
        public void SetTitlePositive(string titlePositive) => TitlePositive = titlePositive;
        public void SetTitleNegative(string titleNegative) => TitleNegative = titleNegative;
        internal TemplateValues DeepCopy() 
        {
            return new TemplateValues(status: this.StatusString,
                                      titleValue: this.TitleValue,
                                      titleCheck: this.TitleCheck,
                                      titleReportField: this.TitleReportField,
                                      tags: this.TagsString,
                                      titlePositive: this.TitlePositive,
                                      titleNegative: this.TitleNegative);
        }
    }
}
