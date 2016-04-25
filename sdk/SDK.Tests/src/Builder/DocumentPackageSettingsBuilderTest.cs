using System;
using NUnit.Framework;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
    public class DocumentPackageSettingsBuilderTest
    {
        [Test]
        public void LanguageDropDown() 
        {
            DocumentPackageSettingsBuilder builder = DocumentPackageSettingsBuilder.NewDocumentPackageSettings();
            DocumentPackageSettings unset = builder.Build();
            Assert.IsFalse(unset.ShowLanguageDropDown.HasValue);
            DocumentPackageSettings with = builder.WithLanguageDropDown().Build();
            Assert.IsTrue(with.ShowLanguageDropDown.HasValue);
            Assert.IsTrue(with.ShowLanguageDropDown.Value);
            DocumentPackageSettings without = builder.WithoutLanguageDropDown().Build();
            Assert.IsTrue(without.ShowLanguageDropDown.HasValue);
            Assert.IsFalse(without.ShowLanguageDropDown.Value);
        }
        
        [Test]
        public void FirstAffidavit()
        {
            DocumentPackageSettingsBuilder builder = DocumentPackageSettingsBuilder.NewDocumentPackageSettings();
            DocumentPackageSettings unset = builder.Build();
            Assert.IsFalse(unset.EnableFirstAffidavit.HasValue);
            DocumentPackageSettings with = builder.EnableFirstAffidavit().Build();
            Assert.IsTrue(with.EnableFirstAffidavit.HasValue);
            Assert.IsTrue(with.EnableFirstAffidavit.Value);
            DocumentPackageSettings without = builder.DisableFirstAffidavit().Build();
            Assert.IsTrue(without.EnableFirstAffidavit.HasValue);
            Assert.IsFalse(without.EnableFirstAffidavit.Value);
            
        }

        [Test]
        public void SecondAffidavit()
        {
            DocumentPackageSettingsBuilder builder = DocumentPackageSettingsBuilder.NewDocumentPackageSettings();
            DocumentPackageSettings unset = builder.Build();
            Assert.IsFalse(unset.EnableSecondAffidavit.HasValue);
            DocumentPackageSettings with = builder.EnableSecondAffidavit().Build();
            Assert.IsTrue(with.EnableSecondAffidavit.HasValue);
            Assert.IsTrue(with.EnableSecondAffidavit.Value);
            DocumentPackageSettings without = builder.DisableSecondAffidavit().Build();
            Assert.IsTrue(without.EnableSecondAffidavit.HasValue);
            Assert.IsFalse(without.EnableSecondAffidavit.Value);
            
        }

        [Test]
        public void ShowOwnerInPersonDropDown()
        {
            DocumentPackageSettingsBuilder builder = DocumentPackageSettingsBuilder.NewDocumentPackageSettings();
            DocumentPackageSettings unset = builder.Build();
            Assert.IsFalse(unset.ShowOwnerInPersonDropDown.HasValue);
            DocumentPackageSettings with = builder.ShowOwnerInPersonDropDown().Build();
            Assert.IsTrue(with.ShowOwnerInPersonDropDown.HasValue);
            Assert.IsTrue(with.ShowOwnerInPersonDropDown.Value);
            DocumentPackageSettings without = builder.HideOwnerInPersonDropDown().Build();
            Assert.IsTrue(without.ShowOwnerInPersonDropDown.HasValue);
            Assert.IsFalse(without.ShowOwnerInPersonDropDown.Value);
            
        }
    }
}

