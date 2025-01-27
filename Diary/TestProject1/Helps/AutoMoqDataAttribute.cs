using AutoFixture.AutoMoq;
using AutoFixture.Community.AutoMapper;
using AutoFixture;
using AutoFixture.Xunit2;
using Diary.Mapping;
using Diary.UnitTests.Applications;


namespace Diary.UnitTests.Helps
{
    public  class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute() : base(fixtureFactory: fixtureFactory)
        { }
        private static readonly Func<IFixture> fixtureFactory = () =>
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            fixture.Customize<GetHabitDiary>(c => c.OmitAutoProperties());
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
    .               ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            fixture.Customize(new AutoMapperCustomization(cfg =>
            {
                cfg.AddProfile<HabitDiaryMappingsProfile>();
            }));
            return fixture;
        };
    }
}
