using System;
using Silanis.ESL.SDK;
using System.Collections.Generic;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class DelegationExample : SDKSample
    {

        public static void Main(string[] args)
        {
            new DelegationExample().Run();
        }

        public string email7, email8, email9;

        public Sender retrievedOwner, retrievedSender1, retrievedSender2, retrievedSender3,
        retrievedSender4, retrievedSender5, retrievedSender6, retrievedSender7, retrievedSender8, retrievedSender9;
        public DelegationUser delegationUser1, delegationUser2, delegationUser3,
        delegationUser4, delegationUser5, delegationUser6, delegationUser7, delegationUser8, delegationUser9;
        public IList<DelegationUser> delegationUserListAfterAdding, delegationUserListAfterRemoving, delegationUserListAfterUpdating
            ,delegationUserListAfterClearing;

        public DelegationExample()
        {
            this.email1 = Guid.NewGuid().ToString().Replace("-", "") + "@e-signlive.com";
            this.email2 = Guid.NewGuid().ToString().Replace("-", "") + "@e-signlive.com";
            this.email3 = Guid.NewGuid().ToString().Replace("-", "") + "@e-signlive.com";
            this.email4 = Guid.NewGuid().ToString().Replace("-", "") + "@e-signlive.com";
            this.email5 = Guid.NewGuid().ToString().Replace("-", "") + "@e-signlive.com";
            this.email6 = Guid.NewGuid().ToString().Replace("-", "") + "@e-signlive.com";
            this.email7 = Guid.NewGuid().ToString().Replace("-", "") + "@e-signlive.com";
            this.email8 = Guid.NewGuid().ToString().Replace("-", "") + "@e-signlive.com";
            this.email9 = Guid.NewGuid().ToString().Replace("-", "") + "@e-signlive.com";
        }

        override public void Execute()
        {
            var ownerMember = GetAccountMember(senderEmail, "firstName", "lastName", "company", "title", "language", "phoneNumber");
            var accountMember1 = GetAccountMember(email1, "firstName1", "lastName", "company1", "title1", "language1", "phoneNumber1");
            var accountMember2 = GetAccountMember(email2, "firstName2", "lastName2", "company2", "title2", "language2", "phoneNumber2");
            var accountMember3 = GetAccountMember(email3, "firstName3", "lastName3", "company3", "title3", "language3", "phoneNumber3");
            var accountMember4 = GetAccountMember(email4, "firstName4", "lastName4", "company4", "title4", "language4", "phoneNumber4");
            var accountMember5 = GetAccountMember(email5, "firstName5", "lastName5", "company5", "title5", "language5", "phoneNumber5");
            var accountMember6 = GetAccountMember(email6, "firstName6", "lastName6", "company6", "title6", "language6", "phoneNumber6");
            var accountMember7 = GetAccountMember(email7, "firstName7", "lastName7", "company7", "title7", "language7", "phoneNumber7");
            var accountMember8 = GetAccountMember(email8, "firstName8", "lastName8", "company8", "title8", "language8", "phoneNumber8");
            var accountMember9 = GetAccountMember(email9, "firstName9", "lastName9", "company9", "title9", "language9", "phoneNumber9");

            var createdOwnerMember = eslClient.AccountService.InviteUser(ownerMember);
            var createdSender1 = eslClient.AccountService.InviteUser(accountMember1);
            var createdSender2 = eslClient.AccountService.InviteUser(accountMember2);
            var createdSender3 = eslClient.AccountService.InviteUser(accountMember3);
            var createdSender4 = eslClient.AccountService.InviteUser(accountMember4);
            var createdSender5 = eslClient.AccountService.InviteUser(accountMember5);
            var createdSender6 = eslClient.AccountService.InviteUser(accountMember6);
            var createdSender7 = eslClient.AccountService.InviteUser(accountMember7);
            var createdSender8 = eslClient.AccountService.InviteUser(accountMember8);
            var createdSender9 = eslClient.AccountService.InviteUser(accountMember9);

            retrievedOwner =   eslClient.AccountService.GetSender(createdOwnerMember.Id);
            retrievedSender1 = eslClient.AccountService.GetSender(createdSender1.Id);
            retrievedSender2 = eslClient.AccountService.GetSender(createdSender2.Id);
            retrievedSender3 = eslClient.AccountService.GetSender(createdSender3.Id);
            retrievedSender4 = eslClient.AccountService.GetSender(createdSender4.Id);
            retrievedSender5 = eslClient.AccountService.GetSender(createdSender5.Id);
            retrievedSender6 = eslClient.AccountService.GetSender(createdSender6.Id);
            retrievedSender7 = eslClient.AccountService.GetSender(createdSender7.Id);
            retrievedSender8 = eslClient.AccountService.GetSender(createdSender8.Id);
            retrievedSender9 = eslClient.AccountService.GetSender(createdSender9.Id);

            delegationUser1 = DelegationUserBuilder.NewDelegationUser(retrievedSender1).Build();
            delegationUser2 = DelegationUserBuilder.NewDelegationUser(retrievedSender2).Build();
            delegationUser3 = DelegationUserBuilder.NewDelegationUser(retrievedSender3).Build();
            delegationUser4 = DelegationUserBuilder.NewDelegationUser(retrievedSender4).Build();
            delegationUser5 = DelegationUserBuilder.NewDelegationUser(retrievedSender5).Build();
            delegationUser6 = DelegationUserBuilder.NewDelegationUser(retrievedSender6).Build();
            delegationUser7 = DelegationUserBuilder.NewDelegationUser(retrievedSender7).Build();
            delegationUser8 = DelegationUserBuilder.NewDelegationUser(retrievedSender8).Build();
            delegationUser9 = DelegationUserBuilder.NewDelegationUser(retrievedSender9).Build();

            eslClient.AccountService.ClearDelegates(createdOwnerMember.Id);

            eslClient.AccountService.AddDelegate(createdOwnerMember.Id, delegationUser1);
            eslClient.AccountService.AddDelegate(createdOwnerMember.Id, delegationUser2);
            eslClient.AccountService.AddDelegate(createdOwnerMember.Id, delegationUser3);
            delegationUserListAfterAdding = eslClient.AccountService.GetDelegates(createdOwnerMember.Id);

            eslClient.AccountService.RemoveDelegate(createdOwnerMember.Id, delegationUser2.Id);
            delegationUserListAfterRemoving = eslClient.AccountService.GetDelegates(createdOwnerMember.Id);

            var delegateIds = new List<string>();
            delegateIds.Add(delegationUser4.Id);
            delegateIds.Add(delegationUser5.Id);
            delegateIds.Add(delegationUser6.Id);
            delegateIds.Add(delegationUser7.Id);
            delegateIds.Add(delegationUser8.Id);
            delegateIds.Add(delegationUser9.Id);

            eslClient.AccountService.UpdateDelegates(createdOwnerMember.Id, delegateIds);
            delegationUserListAfterUpdating = eslClient.AccountService.GetDelegates(createdOwnerMember.Id);

            eslClient.AccountService.ClearDelegates(createdOwnerMember.Id);
            delegationUserListAfterClearing = eslClient.AccountService.GetDelegates(createdOwnerMember.Id);
        }

        private AccountMember GetAccountMember(string email, string firstName, string lastName, string company, string title, string language, string phoneNumber) 
        {
            return AccountMemberBuilder.NewAccountMember(email)
                .WithFirstName(firstName)
                .WithLastName(lastName)
                .WithCompany(company)
                .WithTitle(title)
                .WithLanguage(language)
                .WithPhoneNumber(phoneNumber)
                .Build();
        }
    }
}

