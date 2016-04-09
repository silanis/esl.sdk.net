using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace SDK.Examples
{
    [TestClass]
    public class DocumentPackageSettingsExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new DocumentPackageSettingsExample(  );
            example.Run();
            
            var result = example.EslClient.GetPackage( example.PackageId );
            
            Assert.IsTrue( result.Settings.EnableFirstAffidavit.HasValue);
            Assert.IsFalse( result.Settings.EnableFirstAffidavit.Value );
            
            Assert.IsTrue( result.Settings.EnableSecondAffidavit.HasValue);
            Assert.IsFalse( result.Settings.EnableSecondAffidavit.Value );
            
            Assert.IsTrue( result.Settings.ShowLanguageDropDown.HasValue);
            Assert.IsFalse( result.Settings.ShowLanguageDropDown.Value );
            
            Assert.IsTrue( result.Settings.ShowOwnerInPersonDropDown.HasValue);
            Assert.IsFalse( result.Settings.ShowOwnerInPersonDropDown.Value );

            Assert.AreEqual( 3, result.Settings.DeclineReasons.Count );
            Assert.AreEqual( example.DeclineReason1, result.Settings.DeclineReasons[0] );
            Assert.AreEqual( example.DeclineReason2, result.Settings.DeclineReasons[1] );
            Assert.AreEqual( example.DeclineReason3, result.Settings.DeclineReasons[2] );
            Assert.IsTrue( result.Settings.DisableDeclineOther.Value );

            Assert.AreEqual( 3, result.Settings.DeclineReasons.Count );
            Assert.AreEqual( example.OptOutReason1, result.Settings.OptOutReasons[0] );
            Assert.AreEqual( example.OptOutReason2, result.Settings.OptOutReasons[1] );
            Assert.AreEqual( example.OptOutReason3, result.Settings.OptOutReasons[2] );
            Assert.IsTrue( result.Settings.DisableOptOutOther.Value );
        }
    }
}

