using AutoFixture.AutoMoq;
using AutoFixture.Community.AutoMapper;
using AutoFixture;
using AutoFixture.Xunit2;
using BookOfHabitsMicroservice.Application.Services.Implementations.Mapping;
using BookOfHabitsMicroservice.Application.Services.Implementations;

namespace BookOfHabits.UnitTests.Hepls
{
    public class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute() : base(fixtureFactory: fixtureFactory)
        { }
        private static readonly Func<IFixture> fixtureFactory = () =>
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            fixture.Customize<CoinsApplicationService>(c => c.OmitAutoProperties());
            fixture.Customize(new AutoMapperCustomization(cfg => {
                cfg.AddProfile<CardMapping>();
                cfg.AddProfile<CoinsMapping>();
                cfg.AddProfile<HabitMapping>();
                cfg.AddProfile<PersonMapping>();
                cfg.AddProfile<RoomMapping>();
            }));
            return fixture;
        };
    }
}
