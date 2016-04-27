using System;
using Silanis.ESL.SDK.Builder;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    public class ExceptionHandlingExample : SdkSample
    {
        public static void Main(string[] args)
        {
            new ExceptionHandlingExample().Run();
        }

        override public void Execute()
        {
            var signerBuilder = SignerBuilder.NewSignerWithEmail("john.smith@email.com")
                            .WithFirstName("John")
                            .WithLastName("Smith")
                            .WithTitle("Managing Director")
                            .WithCompany("Acme Inc.");
                            
            Signer signer;
            try
            {
                signer = signerBuilder.Build();
            }
            catch (EslException eslException)
            {
                Console.Out.WriteLine(eslException.Message);
                return;
            }

            try
            {
                eslClient.PackageService.AddSigner(new PackageId("myPackageId"),signer);                                
            }
            catch (EslServerException eslServerException)
            {
                Console.Out.WriteLine(eslServerException.Message);
                Console.Out.WriteLine(eslServerException.ServerError.Code);
                Console.Out.WriteLine(eslServerException.ServerError.Message);
                Console.Out.WriteLine(eslServerException.ServerError.Technical);
            }
            catch (EslException eslException)
            {
                Console.Out.WriteLine(eslException.Message);
            }
        }
    }
}

