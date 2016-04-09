using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
    [TestClass]
    public class DocumentPackageSettingsBuilderTest
    {
        [TestMethod]
        public void LanguageDropDown() 
        {
            var builder = DocumentPackageSettingsBuilder.NewDocumentPackageSettings();
            var unset = builder.Build();
            Assert.IsFalse(unset.ShowLanguageDropDown.HasValue);
            var with = builder.WithLanguageDropDown().Build();
            Assert.IsTrue(with.ShowLanguageDropDown.HasValue);
            Assert.IsTrue(with.ShowLanguageDropDown.Value);
            var without = builder.WithoutLanguageDropDown().Build();
            Assert.IsTrue(without.ShowLanguageDropDown.HasValue);
            Assert.IsFalse(without.ShowLanguageDropDown.Value);
        }
        
        [TestMethod]
        public void FirstAffidavit()
        {
            var builder = DocumentPackageSettingsBuilder.NewDocumentPackageSettings();
            var unset = builder.Build();
            Assert.IsFalse(unset.EnableFirstAffidavit.HasValue);
            var with = builder.EnableFirstAffidavit().Build();
            Assert.IsTrue(with.EnableFirstAffidavit.HasValue);
            Assert.IsTrue(with.EnableFirstAffidavit.Value);
            var without = builder.DisableFirstAffidavit().Build();
            Assert.IsTrue(without.EnableFirstAffidavit.HasValue);
            Assert.IsFalse(without.EnableFirstAffidavit.Value);
            
        }

        [TestMethod]
        public void SecondAffidavit()
        {
            var builder = DocumentPackageSettingsBuilder.NewDocumentPackageSettings();
            var unset = builder.Build();
            Assert.IsFalse(unset.EnableSecondAffidavit.HasValue);
            var with = builder.EnableSecondAffidavit().Build();
            Assert.IsTrue(with.EnableSecondAffidavit.HasValue);
            Assert.IsTrue(with.EnableSecondAffidavit.Value);
            var without = builder.DisableSecondAffidavit().Build();
            Assert.IsTrue(without.EnableSecondAffidavit.HasValue);
            Assert.IsFalse(without.EnableSecondAffidavit.Value);
            
        }

        [TestMethod]
        public void ShowOwnerInPersonDropDown()
        {
            var builder = DocumentPackageSettingsBuilder.NewDocumentPackageSettings();
            var unset = builder.Build();
            Assert.IsFalse(unset.ShowOwnerInPersonDropDown.HasValue);
            var with = builder.ShowOwnerInPersonDropDown().Build();
            Assert.IsTrue(with.ShowOwnerInPersonDropDown.HasValue);
            Assert.IsTrue(with.ShowOwnerInPersonDropDown.Value);
            var without = builder.HideOwnerInPersonDropDown().Build();
            Assert.IsTrue(without.ShowOwnerInPersonDropDown.HasValue);
            Assert.IsFalse(without.ShowOwnerInPersonDropDown.Value);
            
        }
    }
}

