using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    [TestClass]
    public class UpdatePackageExampleTest
    {
        [TestMethod]
        public void verify() {
            // Asserts that are commented out are so because updating them is not currently supported by the esl server.
        
            var example = new UpdatePackageExample();
            example.Run();

            assertPackage(example.createdPackage, example.packageToCreate);
            assertPackageSettings(example.createdSettings, example.settingsToCreate);
            assertLayoutSettings(example.createdLayoutSettings, example.layoutSettingsToCreate);

            assertPackage(example.updatedPackage, example.packageToUpdate);
            assertPackageSettings(example.updatedSettings, example.settingsToUpdate);
            assertLayoutSettings(example.updatedLayoutSettings, example.layoutSettingsToUpdate);
        }

        private void assertPackage(DocumentPackage actualPackage, DocumentPackage expectedPackage) {
            Assert.AreEqual( expectedPackage.Name, actualPackage.Name );
            Assert.AreEqual( expectedPackage.Description, actualPackage.Description );
            Assert.AreEqual( expectedPackage.EmailMessage, actualPackage.EmailMessage );
            Assert.AreEqual( expectedPackage.ExpiryDate.Value.Date, actualPackage.ExpiryDate.Value.Date );
            Assert.AreEqual( expectedPackage.Language, actualPackage.Language );
            Assert.AreEqual( expectedPackage.Autocomplete, actualPackage.Autocomplete );
            Assert.AreEqual( expectedPackage.Notarized, actualPackage.Notarized );
        }

        private void assertPackageSettings(DocumentPackageSettings actualSettings, DocumentPackageSettings expectedSettings) {
            Assert.AreEqual( expectedSettings.EnableInPerson, actualSettings.EnableInPerson );

            Assert.AreEqual( expectedSettings.EnableDecline, actualSettings.EnableDecline );
            Assert.AreEqual( expectedSettings.DeclineReasons.Count, actualSettings.DeclineReasons.Count );
            Assert.AreEqual( expectedSettings.DeclineReasons[0], actualSettings.DeclineReasons[0] );
            Assert.AreEqual( expectedSettings.DeclineReasons[1], actualSettings.DeclineReasons[1] );
            Assert.AreEqual( expectedSettings.DeclineReasons[2], actualSettings.DeclineReasons[2] );

            Assert.AreEqual( expectedSettings.LinkHref, actualSettings.LinkHref );
            Assert.AreEqual( expectedSettings.LinkText, actualSettings.LinkText );
            Assert.AreEqual( expectedSettings.LinkTooltip, actualSettings.LinkTooltip );

            Assert.AreEqual( expectedSettings.EnableOptOut, actualSettings.EnableOptOut );
            Assert.AreEqual( expectedSettings.OptOutReasons.Count, actualSettings.OptOutReasons.Count );
            Assert.AreEqual( expectedSettings.OptOutReasons[0], actualSettings.OptOutReasons[0] );
            Assert.AreEqual( expectedSettings.OptOutReasons[1], actualSettings.OptOutReasons[1] );
            Assert.AreEqual( expectedSettings.OptOutReasons[2], actualSettings.OptOutReasons[2] );
        }

        private void assertLayoutSettings(CeremonyLayoutSettings actualLayoutSettings, CeremonyLayoutSettings expectedLayoutSettings) {
            Assert.AreEqual( expectedLayoutSettings.BreadCrumbs, actualLayoutSettings.BreadCrumbs );
            Assert.AreEqual( expectedLayoutSettings.GlobalNavigation, actualLayoutSettings.GlobalNavigation );
            Assert.AreEqual( expectedLayoutSettings.IFrame, actualLayoutSettings.IFrame );
            Assert.AreEqual( expectedLayoutSettings.LogoImageLink, actualLayoutSettings.LogoImageLink );
            Assert.AreEqual( expectedLayoutSettings.LogoImageSource, actualLayoutSettings.LogoImageSource );
            Assert.AreEqual( expectedLayoutSettings.Navigator, actualLayoutSettings.Navigator );
            Assert.AreEqual( expectedLayoutSettings.ProgressBar, actualLayoutSettings.ProgressBar );
            Assert.AreEqual( expectedLayoutSettings.SessionBar, actualLayoutSettings.SessionBar );
            Assert.AreEqual( expectedLayoutSettings.ShowGlobalConfirmButton, actualLayoutSettings.ShowGlobalConfirmButton );
            Assert.AreEqual( expectedLayoutSettings.ShowGlobalDownloadButton, actualLayoutSettings.ShowGlobalDownloadButton );
            Assert.AreEqual( expectedLayoutSettings.ShowGlobalSaveAsLayoutButton, actualLayoutSettings.ShowGlobalSaveAsLayoutButton );
            Assert.AreEqual( expectedLayoutSettings.ShowTitle, actualLayoutSettings.ShowTitle );
        }
        
//        [TestMethod]
//        public void verifyCultureInfoDeserialisation()
//        {
//            JsonSerializerSettings settings = new JsonSerializerSettings ();
//            settings.NullValueHandling = NullValueHandling.Ignore;
//            settings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
//            settings.Converters.Add( new CultureInfoJsonCreationConverter() );
//
//            string json = "{ \"cultureInfo\":\"en\" }";
//            
//            Bob bob = JsonConvert.DeserializeObject<Bob> (json, settings);
//            
//            Console.Out.WriteLine( "Blah" );
//        }
    }
}

