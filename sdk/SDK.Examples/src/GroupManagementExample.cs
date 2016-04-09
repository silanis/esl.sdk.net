using System;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;
using System.Collections.Generic;

namespace SDK.Examples
{
    public class GroupManagementExample : SdkSample
    {
        public static void Main (string[] args)
        {
            new GroupManagementExample().Run();
        }

        public Group CreatedEmptyGroup;
        public Group CreatedGroup1;
        public Group RetrievedGroup1;
        public Group CreatedGroup2;
        public Group RetrievedGroup2;
        public Group CreatedGroup3;
        public Group RetrievedGroup3;
        public Group CreatedGroup3Updated;

        public List<Group> AllGroupsBeforeDelete;
        public List<Group> AllGroupsAfterDelete;
        public List<string> GroupMemberEmailsAfterUpdate;

        public GroupManagementExample()
        {
            email1 = GetRandomEmail();
            email2 = GetRandomEmail();
            email3 = GetRandomEmail();
            email4 = GetRandomEmail();
        }

		private void DisplayAccountGroupsAndMembers() {
			{
				var allGroups = eslClient.GroupService.GetMyGroups();
				foreach ( var group in allGroups ) {
					Console.Out.WriteLine( group.Name + " with email " + group.Email + " and id " + group.Id );
					var allMembers = eslClient.GroupService.GetGroupMembers( group.Id );
					foreach ( var member in allMembers ) {
						Console.Out.WriteLine( member.GroupMemberType + " " + member.FirstName + " " + member.LastName + " with email " + member.Email);
					}
				}
			}
		}

		private void InviteUsersToMyAccount() {
			// The group members need to be account members, if they aren't already you may need to invite them to your account.
			eslClient.AccountService.InviteUser(AccountMemberBuilder.NewAccountMember(email1)
				.WithFirstName("first1")
				.WithLastName("last1")
				.WithCompany("company1")
				.WithTitle("title1")
				.WithLanguage("language1")
				.WithPhoneNumber("phoneNumber1")
				.Build());
			eslClient.AccountService.InviteUser(AccountMemberBuilder.NewAccountMember(email2)
				.WithFirstName("first2")
				.WithLastName("last2")
				.WithCompany("company2")
				.WithTitle("title2")
				.WithLanguage("language2")
				.WithPhoneNumber("phoneNumber2")
				.Build());
			eslClient.AccountService.InviteUser(AccountMemberBuilder.NewAccountMember(email3)
				.WithFirstName("first3")
				.WithLastName("last3")
				.WithCompany("company3")
				.WithTitle("title3")
				.WithLanguage("language3")
				.WithPhoneNumber("phoneNumber3")
				.Build());
			eslClient.AccountService.InviteUser(AccountMemberBuilder.NewAccountMember(email4)
				.WithFirstName("first4")
				.WithLastName("last4")
				.WithCompany("company4")
				.WithTitle("title4")
				.WithLanguage("language4")
				.WithPhoneNumber("phoneNumber4")
				.Build());
		}

        override public void Execute()
        {
			InviteUsersToMyAccount();
			DisplayAccountGroupsAndMembers();
			var emptyGroup = GroupBuilder.NewGroup(Guid.NewGuid().ToString())
				.WithId(new GroupId(Guid.NewGuid().ToString()))
				.WithEmail("emptyGroup@email.com")
				.WithoutIndividualMemberEmailing()
				.Build();
			CreatedEmptyGroup = eslClient.GroupService.CreateGroup(emptyGroup);
			eslClient.GroupService.GetGroupMembers(CreatedEmptyGroup.Id);

			eslClient.GroupService.AddMember(CreatedEmptyGroup.Id,
			    GroupMemberBuilder.NewGroupMember(email1)
			        .AsMemberType(GroupMemberType.MANAGER)
			        .Build());
			eslClient.GroupService.InviteMember(CreatedEmptyGroup.Id,
			    GroupMemberBuilder.NewGroupMember(email3)
			        .AsMemberType(GroupMemberType.MANAGER)
			        .Build());
			Console.Out.WriteLine("GroupId: " + CreatedEmptyGroup.Id.Id);
			eslClient.GroupService.GetGroupMembers(CreatedEmptyGroup.Id);

			var group1 = GroupBuilder.NewGroup(Guid.NewGuid().ToString())
                    .WithId(new GroupId(Guid.NewGuid().ToString()))
					.WithMember(GroupMemberBuilder.NewGroupMember(email1)
						.AsMemberType(GroupMemberType.MANAGER))
					.WithMember(GroupMemberBuilder.NewGroupMember(email3)
						.AsMemberType(GroupMemberType.MANAGER))
                    .WithEmail("bob@aol.com")
                    .WithIndividualMemberEmailing()
                    .Build();
            CreatedGroup1 = eslClient.GroupService.CreateGroup(group1);
			Console.Out.WriteLine("GroupId #1: " + CreatedGroup1.Id.Id);

			eslClient.GroupService.AddMember( CreatedGroup1.Id,
                                                GroupMemberBuilder.NewGroupMember( email3 )
                                                .AsMemberType( GroupMemberType.MANAGER )
                                                .Build() );

            eslClient.GroupService.AddMember(CreatedGroup1.Id,
                GroupMemberBuilder.NewGroupMember(email4)
                                                .AsMemberType(GroupMemberType.REGULAR)
                                             .Build());

            RetrievedGroup1 = eslClient.GroupService.GetGroup(CreatedGroup1.Id);

            var group2 = GroupBuilder.NewGroup(Guid.NewGuid().ToString())
                .WithMember(GroupMemberBuilder.NewGroupMember(email2)
					.AsMemberType(GroupMemberType.MANAGER) )
                    .WithEmail("bob@aol.com")
                    .WithIndividualMemberEmailing()
                    .Build();
            CreatedGroup2 = eslClient.GroupService.CreateGroup(group2);
            RetrievedGroup2 = eslClient.GroupService.GetGroup(CreatedGroup2.Id);
			Console.Out.WriteLine("GroupId #2: " + CreatedGroup2.Id.Id);

            var group3 = GroupBuilder.NewGroup(Guid.NewGuid().ToString())
                .WithMember(GroupMemberBuilder.NewGroupMember(email3)
                            .AsMemberType(GroupMemberType.MANAGER) )
                    .WithEmail("bob@aol.com")
                    .WithIndividualMemberEmailing()
                    .Build();
            CreatedGroup3 = eslClient.GroupService.CreateGroup(group3);
            Console.Out.WriteLine("GroupId #3: " + CreatedGroup3.Id.Id);
            RetrievedGroup3 = eslClient.GroupService.GetGroup(CreatedGroup3.Id);

			AllGroupsBeforeDelete = eslClient.GroupService.GetMyGroups();

            eslClient.GroupService.DeleteGroup(CreatedGroup2.Id);

            AllGroupsAfterDelete = eslClient.GroupService.GetMyGroups();

            var updatedGroup = GroupBuilder.NewGroup(Guid.NewGuid().ToString())
                .WithMember(GroupMemberBuilder.NewGroupMember(email2)
                            .AsMemberType(GroupMemberType.MANAGER) )
                    .WithMember(GroupMemberBuilder.NewGroupMember(email3)
                                .AsMemberType(GroupMemberType.REGULAR) )
                    .WithMember(GroupMemberBuilder.NewGroupMember(email4)
                                .AsMemberType(GroupMemberType.REGULAR) )
                    .WithEmail("bob@aol.com")
                    .WithIndividualMemberEmailing()
                    .Build();

            CreatedGroup3Updated = eslClient.GroupService.UpdateGroup(updatedGroup, CreatedGroup3.Id);

            GroupMemberEmailsAfterUpdate = eslClient.GroupService.GetGroupMemberEmails(CreatedGroup3Updated.Id);

            var superDuperPackage = PackageBuilder.NewPackageNamed(PackageName)
			    .WithSigner(SignerBuilder.NewSignerFromGroup(CreatedGroup1.Id)
			                .CanChangeSigner()
			                .DeliverSignedDocumentsByEmail())
			        .WithDocument(DocumentBuilder.NewDocumentNamed("First Document")
			                      .FromStream(fileStream1, DocumentType.PDF)
			                      .WithSignature(SignatureBuilder.SignatureFor(CreatedGroup1.Id)
			                       .OnPage(0)
			                       .AtPosition(100, 100)))
			        .Build();

			var id = eslClient.CreatePackage(superDuperPackage);
			eslClient.SendPackage(id);

			eslClient.PackageService.NotifySigner(id, CreatedGroup1.Id);

			eslClient.GetPackage(id);
			
        }
    }
}

