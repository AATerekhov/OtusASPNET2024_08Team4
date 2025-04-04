using BookOfHabitsMicroservice.Domain.Entity.Base;

namespace BookOfHabitsMicroservice.Domain.Entity.Propertys
{
    public class TemplateValues : Property
    {
        public string TitleStatus { get; private set; }
        public string TitleValue { get; private set; }
        public string TitleCheck { get; private set; }
        public string TitleReportField { get; private set; }
        public string TitleTags { get; private set; }
        public string TitlePositive { get; private set; }
        public string TitleNegative { get; private set; }
        public string TitleFileReceiver { get; private set; }

        public TemplateValues(Guid id , string titleStatus, string titleValue, string titleCheck, string titleReportField, string titleTags, string titlePositive, string titleNegative, string titleFileReceiver)
            :base(id, "TemplateValues")
        {
            TitleStatus = titleStatus;
            TitleValue = titleValue;
            TitleCheck = titleCheck;
            TitleReportField = titleReportField;
            TitleTags = titleTags;
            TitlePositive = titlePositive;
            TitleNegative = titleNegative;
            TitleFileReceiver = titleFileReceiver;
        }
        public TemplateValues(string titleStatus, string titleValue, string titleCheck, string titleReportField, string titleTags, string titlePositive, string titleNegative, string titleFileReceiver)
            :this(Guid.NewGuid(), titleStatus, titleValue,titleCheck,titleReportField,titleTags,titlePositive, titleNegative, titleFileReceiver)
        {
                
        }

        protected TemplateValues()
            : base(Guid.NewGuid(), "TemplateValues")
        {

        }
        public void SetTitleStatus(string titleStatus) => TitleStatus = titleStatus;
        public void SetTitleValue(string titleValue) => TitleValue = titleValue;
        public void SetTitleCheck(string titleCheck) => TitleCheck = titleCheck;
        public void SetTitleReportField(string titleReportField) => TitleReportField = titleReportField;
        public void SetTitleTags(string titleTags) => TitleTags = titleTags;
        public void SetTitlePositive(string titlePositive) => TitlePositive = titlePositive;
        public void SetTitleNegative(string titleNegative) => TitleNegative = titleNegative;
        public void SetTItleFileReceiver(string titleFIleReceiver) => TitleFileReceiver = titleFIleReceiver;
        internal TemplateValues DeepCopy() 
        {
            return new TemplateValues(titleStatus: this.TitleStatus,
                                      titleValue: this.TitleValue,
                                      titleCheck: this.TitleCheck,
                                      titleReportField: this.TitleReportField,
                                      titleTags: this.TitleTags,
                                      titlePositive: this.TitlePositive,
                                      titleNegative: this.TitleNegative,
                                      titleFileReceiver: this.TitleFileReceiver);
        }
    }
}
