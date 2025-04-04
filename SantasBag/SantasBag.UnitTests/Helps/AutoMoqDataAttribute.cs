using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using SantasBag.BusinessLogic.Services;

namespace SantasBag.UnitTests.Helps
{
    public class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute() : base(fixtureFactory: fixtureFactory)
        { }
        private static readonly Func<IFixture> fixtureFactory = () =>
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            fixture.Customize<RewardsService>(c => c.OmitAutoProperties());
            return fixture;
        };
    }
}
