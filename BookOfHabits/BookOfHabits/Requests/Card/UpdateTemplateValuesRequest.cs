namespace BookOfHabits.Requests.Card
{
    public class UpdateTemplateValuesRequest
    {
        public string[]? Status { get; init; }
        public string? TitleValue { get; init; }
        public string? TitleCheck { get; init; }
        public string? TitleReportField { get; init; }
        public string[]? Tags { get; init; }
        public string? TitlePositive { get; init; }
        public string? TitleNegative { get; init; }
    }
}
