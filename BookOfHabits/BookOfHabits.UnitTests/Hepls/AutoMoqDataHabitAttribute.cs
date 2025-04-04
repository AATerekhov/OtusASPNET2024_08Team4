using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Community.AutoMapper;
using AutoFixture.Xunit2;
using BookOfHabitsMicroservice.Application.Services.Implementations;
using BookOfHabitsMicroservice.Application.Services.Implementations.Mapping;

namespace BookOfHabits.UnitTests.Hepls
{
    public class AutoMoqDataHabitAttribute : AutoDataAttribute
    {
        public AutoMoqDataHabitAttribute() : base(fixtureFactory: fixtureFactory)
        { }
        private static readonly Func<IFixture> fixtureFactory = () =>
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            fixture.Customize<HabitsApplicationService>(c => c.OmitAutoProperties());
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
