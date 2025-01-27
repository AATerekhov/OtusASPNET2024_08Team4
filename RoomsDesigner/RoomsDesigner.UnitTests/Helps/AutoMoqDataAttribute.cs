using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Community.AutoMapper;
using AutoFixture.Xunit2;
using RoomsDesigner.Application.Models.Participant;
using RoomsDesigner.Application.Services.Implementations;
using RoomsDesigner.Application.Services.Implementations.Mapping;
using RoomsDesigner.Domain.Entity;
using System.Net.Mail;

namespace RoomsDesigner.UnitTests.Helps
{
    public class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute() : base(fixtureFactory: fixtureFactory)
        { }
        private static readonly Func<IFixture> fixtureFactory = () =>
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            fixture.Customize<СaseService>(c => c.OmitAutoProperties());
            fixture.Customize<ParticipantService>(c => c.OmitAutoProperties());
            fixture.Customize<Participant>(c => c.WithAutoProperties());
            fixture.Customize<Case>(c => c.WithAutoProperties());
            fixture.Customize<CreateParticipantModel>(c => c.With(x => x.UserMail, fixture.Create<MailAddress>().Address));
            fixture.Customize(new AutoMapperCustomization(cfg => {
                cfg.AddProfile<CaseMapping>();
                cfg.AddProfile<ParticipantMapping>();
            }));
            return fixture;
        };
    }
}
