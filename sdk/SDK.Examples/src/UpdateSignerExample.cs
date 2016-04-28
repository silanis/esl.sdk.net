using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class UpdateSignerExample : SdkSample
    {
        public static void Main(string[] args)
        {
            new UpdateSignerExample().Run();
        }

        public DocumentPackage UpdatedPackage;

        public const string Signer1CustomId = "signerId1";
        public const string Signer1FirstName = "John1";
        public const string Signer1LastName = "Smith1";

        public const string Signer2CustomId = "signerId2";
        public const string Signer2FirstName = "Patty";
        public const string Signer2LastName = "Galant";

        public const string Signer3FirstName = "John2";
        public const string Signer3LastName = "Smith2";
        public const string Signer3FirstQuestion = "What's 1+1?";
        public const string Signer3FirstAnswer= "2";
        public const string Signer3SecondQuestion = "What color's the sky?";
        public const string Signer3SecondAnswer= "blue";

        override public void Execute()
        {
            var signer1 = SignerBuilder.NewSignerWithEmail(email1)
                .WithFirstName(Signer1FirstName)
                    .WithLastName(Signer1LastName)
                    .WithCustomId(Signer1CustomId)
                    .Build();

            var signer2 = SignerBuilder.NewSignerWithEmail(email2)
                .WithFirstName(Signer2FirstName)
                    .WithLastName(Signer2LastName)
                    .WithCustomId(Signer2CustomId)
                    .Build();

            var signer3 = SignerBuilder.NewSignerWithEmail(email3)
                .WithFirstName(Signer3FirstName)
                    .WithLastName(Signer3LastName)
                    .ChallengedWithQuestions(ChallengeBuilder.FirstQuestion(Signer3FirstQuestion)
                                             .Answer(Signer3FirstAnswer)
                                             .SecondQuestion(Signer3SecondQuestion)
                                             .Answer(Signer3SecondAnswer))
                    .WithCustomId(Signer1CustomId)
                    .Build();

            var signer4 = SignerBuilder.NewSignerWithEmail(email2)
                .WithFirstName(Signer2FirstName)
                    .WithLastName(Signer2LastName)
                    .WithSMSSentTo(sms1)
                    .WithCustomId(Signer2CustomId).Build();

            var superDuperPackage = PackageBuilder.NewPackageNamed(PackageName)
                .DescribedAs( "This is a package created using the e-SignLive SDK" )
                    .WithSigner(signer1)
                    .WithSigner(signer2)
                    .WithDocument( DocumentBuilder.NewDocumentNamed( "First Document" )
                                  .FromStream( fileStream1, DocumentType.PDF )
                                  .WithSignature( SignatureBuilder.SignatureFor( email1 )
                                   .OnPage( 0 )
                                   .AtPosition( 30, 100 ) )
                                  .WithSignature( SignatureBuilder.SignatureFor( email2 )
                                   .OnPage( 0 )
                                   .AtPosition( 30, 400 ) ))
                    .Build();

            packageId = eslClient.CreatePackage( superDuperPackage );
            eslClient.SendPackage( packageId );
            retrievedPackage = eslClient.GetPackage(packageId);

            eslClient.ChangePackageStatusToDraft(packageId);
            eslClient.PackageService.UpdateSigner(packageId, signer3);
            eslClient.PackageService.UpdateSigner(packageId, signer4);

            eslClient.SendPackage(packageId);
            UpdatedPackage = eslClient.GetPackage(packageId);
        }
    }
}

