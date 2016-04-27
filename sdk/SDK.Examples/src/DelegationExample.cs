using System;
using Silanis.ESL.SDK;
using System.Collections.Generic;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class DelegationExample : SdkSample
    {

        public static void Main(string[] args)
        {
            new DelegationExample().Run();
        }

        public string Email7, Email8, Email9;

        public Sender RetrievedOwner, RetrievedSender1, RetrievedSender2, RetrievedSender3,
        RetrievedSender4, RetrievedSender5, RetrievedSender6, RetrievedSender7, RetrievedSender8, RetrievedSender9;
        public DelegationUser DelegationUser1, DelegationUser2, DelegationUser3,
        DelegationUser4, DelegationUser5, DelegationUser6, DelegationUser7, DelegationUser8, DelegationUser9;
        public IList<DelegationUser> DelegationUserListAfterAdding, DelegationUserListAfterRemoving, DelegationUserListAfterUpdating
            ,DelegationUserListAfterClearing;

        public DelegationExample()
        {
            email1 = Guid.NewGuid().ToString().Replace("-", "") + "@e-signlive.com";
            email2 = Guid.NewGuid().ToString().Replace("-", "") + "@e-signlive.com";
            email3 = Guid.NewGuid().ToString().Replace("-", "") + "@e-signlive.com";
            email4 = Guid.NewGuid().ToString().Replace("-", "") + "@e-signlive.com";
            email5 = Guid.NewGuid().ToString().Replace("-", "") + "@e-signlive.com";
            email6 = Guid.NewGuid().ToString().Replace("-", "") + "@e-signlive.com";
            Email7 = Guid.NewGuid().ToString().Replace("-", "") + "@e-signlive.com";
            Email8 = Guid.NewGuid().ToString().Replace("-", "") + "@e-signlive.com";
            Email9 = Guid.NewGuid().ToString().Replace("-", "") + "@e-signlive.com";
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
            var accountMember7 = GetAccountMember(Email7, "firstName7", "lastName7", "company7", "title7", "language7", "phoneNumber7");
            var accountMember8 = GetAccountMember(Email8, "firstName8", "lastName8", "company8", "title8", "language8", "phoneNumber8");
            var accountMember9 = GetAccountMember(Email9, "firstName9", "lastName9", "company9", "title9", "language9", "phoneNumber9");

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

            RetrievedOwner =   eslClient.AccountService.GetSender(createdOwnerMember.Id);
            RetrievedSender1 = eslClient.AccountService.GetSender(createdSender1.Id);
            RetrievedSender2 = eslClient.AccountService.GetSender(createdSender2.Id);
            RetrievedSender3 = eslClient.AccountService.GetSender(createdSender3.Id);
            RetrievedSender4 = eslClient.AccountService.GetSender(createdSender4.Id);
            RetrievedSender5 = eslClient.AccountService.GetSender(createdSender5.Id);
            RetrievedSender6 = eslClient.AccountService.GetSender(createdSender6.Id);
            RetrievedSender7 = eslClient.AccountService.GetSender(createdSender7.Id);
            RetrievedSender8 = eslClient.AccountService.GetSender(createdSender8.Id);
            RetrievedSender9 = eslClient.AccountService.GetSender(createdSender9.Id);

            DelegationUser1 = DelegationUserBuilder.NewDelegationUser(RetrievedSender1).Build();
            DelegationUser2 = DelegationUserBuilder.NewDelegationUser(RetrievedSender2).Build();
            DelegationUser3 = DelegationUserBuilder.NewDelegationUser(RetrievedSender3).Build();
            DelegationUser4 = DelegationUserBuilder.NewDelegationUser(RetrievedSender4).Build();
            DelegationUser5 = DelegationUserBuilder.NewDelegationUser(RetrievedSender5).Build();
            DelegationUser6 = DelegationUserBuilder.NewDelegationUser(RetrievedSender6).Build();
            DelegationUser7 = DelegationUserBuilder.NewDelegationUser(RetrievedSender7).Build();
            DelegationUser8 = DelegationUserBuilder.NewDelegationUser(RetrievedSender8).Build();
            DelegationUser9 = DelegationUserBuilder.NewDelegationUser(RetrievedSender9).Build();

            eslClient.AccountService.ClearDelegates(createdOwnerMember.Id);

            eslClient.AccountService.AddDelegate(createdOwnerMember.Id, DelegationUser1);
            eslClient.AccountService.AddDelegate(createdOwnerMember.Id, DelegationUser2);
            eslClient.AccountService.AddDelegate(createdOwnerMember.Id, DelegationUser3);
            DelegationUserListAfterAdding = eslClient.AccountService.GetDelegates(createdOwnerMember.Id);

            eslClient.AccountService.RemoveDelegate(createdOwnerMember.Id, DelegationUser2.Id);
            DelegationUserListAfterRemoving = eslClient.AccountService.GetDelegates(createdOwnerMember.Id);

            var delegateIds = new List<string>();
            delegateIds.Add(DelegationUser4.Id);
            delegateIds.Add(DelegationUser5.Id);
            delegateIds.Add(DelegationUser6.Id);
            delegateIds.Add(DelegationUser7.Id);
            delegateIds.Add(DelegationUser8.Id);
            delegateIds.Add(DelegationUser9.Id);

            eslClient.AccountService.UpdateDelegates(createdOwnerMember.Id, delegateIds);
            DelegationUserListAfterUpdating = eslClient.AccountService.GetDelegates(createdOwnerMember.Id);

            eslClient.AccountService.ClearDelegates(createdOwnerMember.Id);
            DelegationUserListAfterClearing = eslClient.AccountService.GetDelegates(createdOwnerMember.Id);
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

