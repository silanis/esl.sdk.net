using System;
using System.IO;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class SignerManipulationExample : SDKSample
    {

        override public void Execute()
        {
            Placeholder signer1Id = new Placeholder( Guid.NewGuid().ToString() );
            DocumentPackage superDuperPackage = 
                PackageBuilder.NewPackageNamed(PackageName)
                .DescribedAs("This is a package created using the e-SignLive SDK")
                .WithSigner(SignerBuilder.NewSignerWithEmail(email1)
                            .WithFirstName("firstName1")
                            .WithLastName("lastName1")
                            .WithTitle("Title1")
            )
                .WithSigner(SignerBuilder.NewSignerWithEmail(email2)
                            .WithFirstName("firstName2")
                            .WithLastName("lastName2")
                            .WithTitle("Title2")
            )
                .Build();

            packageId = eslClient.CreatePackage(superDuperPackage);
            
            DocumentPackage createdPackage = eslClient.GetPackage(packageId);
            
            string signerId = createdPackage.GetSigner(email1).Id;
            string signer2Id = createdPackage.GetSigner(email2).Id;
            
//            eslClient.SignerService.UpdateSigner( packageId, signerId, SignerBuilder.NewSignerWithEmail(email1)
//                                                                    .WithFirstName("firstName1b")
//                                                                    .WithLastName("lastName1b")
//                                                                    .WithTitle("title1b") );

			string addedSignerId = eslClient.PackageService.AddSigner(packageId, 
                                                                      SignerBuilder.NewSignerWithEmail(email3)
                                                                              .WithFirstName("firstName3")
                                                                              .WithLastName("lastName3")
                                                                              .WithTitle("Title3")
                                                                              .Build()
            );
                                                                              
			string placeHolderId = eslClient.PackageService.AddSigner(packageId,
                                                                      SignerBuilder.NewSignerPlaceholder(new Placeholder("placeHolderRoleId"))
                                                                                .Build()
            );                                                                                    

            Group avengers = eslClient.GroupService.CreateGroup( GroupBuilder.NewGroup(  Guid.NewGuid().ToString() ).WithEmail("bob@aol.com").Build() );                                                                                
			string addedGroupSignerId = eslClient.PackageService.AddSigner( packageId,
                                                                           SignerBuilder.NewSignerFromGroup( avengers.Id )
                                                                                .Build() );
                                                                                                                                                                
			eslClient.PackageService.RemoveSigner( packageId, placeHolderId );                                                                                
			eslClient.PackageService.RemoveSigner( packageId, signerId );
            
			eslClient.PackageService.UpdateSigner( packageId, SignerBuilder.NewSignerWithEmail("timbob@aol.com")
                            .WithCustomId( signer2Id )
                            .WithFirstName("updateFirstName1")
                            .WithLastName("updateLastName1")
                            .WithTitle("UpdatedTitle1")
                            .Build() );

			Signer retrievedSigner = eslClient.PackageService.GetSigner(packageId, addedSignerId);
            //eslClient.SendPackage(packageId);
            eslClient.PackageService.UnlockSigner(PackageId, addedSignerId);
        }
    }
}

