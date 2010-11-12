using System;
using Messages;
using NServiceBus;
using NServiceBus.Saga;

namespace AddNewArcEmployeeAC
{
    public class InitiateAccountCreations : Saga<EmployeeCreationData>, IAmStartedByMessages<CreateSignedOnEmployee>, IHandleMessages<EmployeeCreatedByIt>
    {
        public override void ConfigureHowToFindSaga()
        {
            ConfigureMapping<EmployeeCreatedByIt>(x => x.Id, x => x.OriginalMessageId);
        }

        public void Handle(CreateSignedOnEmployee message)
        {
        }

        public void Handle(EmployeeCreatedByIt message)
        {
            MarkAsComplete();
        }
    }

    public class EmployeeCreationData : ISagaEntity
    {
        public Guid Id { get; set; }
        public string Originator {get; set; }
        public string OriginalMessageId{get; set; }
    }
}