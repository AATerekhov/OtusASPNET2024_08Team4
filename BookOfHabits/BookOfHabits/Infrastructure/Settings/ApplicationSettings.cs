namespace BookOfHabits.Infrastructure.Settings
{
    public class ApplicationSettings
    {
        public ApiGateWaySettings ApiGateWaySettings { get; set; }
        //public string ConnectionString { get; set; }
        public RmqSettings RmqSettings { get; set; }
    }
}
