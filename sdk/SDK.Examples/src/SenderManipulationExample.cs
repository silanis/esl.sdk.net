using System;
using Silanis.ESL.SDK;
using System.Collections.Generic;

namespace SDK.Examples
{
    public class SenderManipulationExample : SDKSample
    {
        public AccountMember accountMember1;
        public AccountMember accountMember2;
        public AccountMember accountMember3;
        public SenderInfo updatedSenderInfo;
        public Sender retrievedSender1, retrievedSender2, retrievedSender3;
        public Sender retrievedUpdatedSender3;

        public SenderManipulationExample()
        {
            this.email1 = GetRandomEmail();
            this.email2 = GetRandomEmail();
            this.email3 = GetRandomEmail();
        }

        override public void Execute()
        {
            accountMember1 = AccountMemberBuilder.NewAccountMember(email1)
                .WithFirstName( "firstName1" )
                .WithLastName( "lastName1" )
                .WithCompany( "company1" )
                .WithTitle( "title1" )
                .WithLanguage( "language1" )
                .WithPhoneNumber( "phoneNumber1" )
                .WithStatus(SenderStatus.ACTIVE)
                .Build();

            accountMember2 = AccountMemberBuilder.NewAccountMember(email2)
                .WithFirstName( "firstName2" )
                .WithLastName( "lastName2" )
                .WithCompany( "company2" )
                .WithTitle( "title2" )
                .WithLanguage( "language2" )
                .WithPhoneNumber( "phoneNumber2" )
                .WithStatus(SenderStatus.ACTIVE)
                .Build();

            accountMember3 = AccountMemberBuilder.NewAccountMember(email3)
                .WithFirstName( "firstName3" )
                .WithLastName( "lastName3" )
                .WithCompany( "company3" )
                .WithTitle( "title3" )
                .WithLanguage( "language3" )
                .WithPhoneNumber( "phoneNumber3" )
                .WithStatus(SenderStatus.ACTIVE)
                .Build();

            var createdSender1 = eslClient.AccountService.InviteUser(accountMember1);
            var createdSender2 = eslClient.AccountService.InviteUser(accountMember2);
            var createdSender3 = eslClient.AccountService.InviteUser(accountMember3);

            retrievedSender1 = eslClient.AccountService.GetSender(createdSender1.Id);
            retrievedSender2 = eslClient.AccountService.GetSender(createdSender2.Id);
            retrievedSender3 = eslClient.AccountService.GetSender(createdSender3.Id);

            eslClient.AccountService.SendInvite(createdSender1.Id);

            eslClient.AccountService.DeleteSender(createdSender2.Id);

            updatedSenderInfo = SenderInfoBuilder.NewSenderInfo(email3)
                .WithName("updatedFirstName", "updatedLastName")
                    .WithCompany("updatedCompany")
                    .WithTitle("updatedTitle")
                    .Build();

            eslClient.AccountService.UpdateSender(updatedSenderInfo, createdSender3.Id);
            retrievedUpdatedSender3 = eslClient.AccountService.GetSender(createdSender3.Id);

            // Get senders in account
            var senders = eslClient.AccountService.GetSenders(Direction.ASCENDING, new PageRequest(1, 100));
        }
    }
}

