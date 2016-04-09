using Silanis.ESL.SDK;

namespace SDK.Examples
{
    public class SenderManipulationExample : SdkSample
    {
        public AccountMember AccountMember1;
        public AccountMember AccountMember2;
        public AccountMember AccountMember3;
        public SenderInfo UpdatedSenderInfo;
        public Sender RetrievedSender1, RetrievedSender2, RetrievedSender3;
        public Sender RetrievedUpdatedSender3;

        public SenderManipulationExample()
        {
            email1 = GetRandomEmail();
            email2 = GetRandomEmail();
            email3 = GetRandomEmail();
        }

        override public void Execute()
        {
            AccountMember1 = AccountMemberBuilder.NewAccountMember(email1)
                .WithFirstName( "firstName1" )
                .WithLastName( "lastName1" )
                .WithCompany( "company1" )
                .WithTitle( "title1" )
                .WithLanguage( "language1" )
                .WithPhoneNumber( "phoneNumber1" )
                .WithStatus(SenderStatus.ACTIVE)
                .Build();

            AccountMember2 = AccountMemberBuilder.NewAccountMember(email2)
                .WithFirstName( "firstName2" )
                .WithLastName( "lastName2" )
                .WithCompany( "company2" )
                .WithTitle( "title2" )
                .WithLanguage( "language2" )
                .WithPhoneNumber( "phoneNumber2" )
                .WithStatus(SenderStatus.ACTIVE)
                .Build();

            AccountMember3 = AccountMemberBuilder.NewAccountMember(email3)
                .WithFirstName( "firstName3" )
                .WithLastName( "lastName3" )
                .WithCompany( "company3" )
                .WithTitle( "title3" )
                .WithLanguage( "language3" )
                .WithPhoneNumber( "phoneNumber3" )
                .WithStatus(SenderStatus.ACTIVE)
                .Build();

            var createdSender1 = eslClient.AccountService.InviteUser(AccountMember1);
            var createdSender2 = eslClient.AccountService.InviteUser(AccountMember2);
            var createdSender3 = eslClient.AccountService.InviteUser(AccountMember3);

            RetrievedSender1 = eslClient.AccountService.GetSender(createdSender1.Id);
            RetrievedSender2 = eslClient.AccountService.GetSender(createdSender2.Id);
            RetrievedSender3 = eslClient.AccountService.GetSender(createdSender3.Id);

            eslClient.AccountService.SendInvite(createdSender1.Id);

            eslClient.AccountService.DeleteSender(createdSender2.Id);

            UpdatedSenderInfo = SenderInfoBuilder.NewSenderInfo(email3)
                .WithName("updatedFirstName", "updatedLastName")
                    .WithCompany("updatedCompany")
                    .WithTitle("updatedTitle")
                    .Build();

            eslClient.AccountService.UpdateSender(UpdatedSenderInfo, createdSender3.Id);
            RetrievedUpdatedSender3 = eslClient.AccountService.GetSender(createdSender3.Id);

            // Get senders in account
            eslClient.AccountService.GetSenders(Direction.ASCENDING, new PageRequest(1, 100));
        }
    }
}

