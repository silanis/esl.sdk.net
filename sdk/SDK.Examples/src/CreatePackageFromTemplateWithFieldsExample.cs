using System;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class CreatePackageFromTemplateWithFieldsExample : SdkSample
    {
        public static void Main(string[] args)
        {
            new CreatePackageFromTemplateWithFieldsExample().Run();
        }

        public readonly string DocumentName = "First Document";
        public readonly string DocumentId = "doc1";
        public readonly string TemplateName = "CreatePackageFromTemplateWithFieldsExample Template: " + DateTime.Now;
        public readonly string PackageDescription = "This is a package created using the e-SignLive SDK";
        public readonly string PackageEmailMessage = "This message should be delivered to all signers";
        public readonly string TemplateSigner1First = "John";
        public readonly string TemplateSigner1Last = "Smith";

        public readonly string PackageSigner2First = "Elvis";
        public readonly string PackageSigner2Last = "Presley";
        public readonly string PackageSigner2Title = "The King";
        public readonly string PackageSigner2Company = "Elvis Presley International";
        public readonly string PackageSigner2CustomId = "Signer2";

        public readonly string TextfieldId = "textFieldId";
        public readonly int TextfieldPage = 0;
        public readonly string Checkbox1Id = "checkbox1Id";
        public readonly int Checkbox1Page = 0;
        public readonly string Checkbox2Id = "checkbox2Id";
        public readonly int Checkbox2Page = 0;
        public readonly bool Checkbox2Value = true;
        public readonly string Radio1Id = "radio1Id";
        public readonly int Radio1Page = 0;
        public readonly string Radio1Group = "group";
        public readonly string Radio2Id = "radio2Id";
        public readonly int Radio2Page = 0;
        public readonly bool Radio2Value = true;
        public readonly string Radio2Group = "group";
        public readonly string DropListId = "dropListId";
        public readonly int DropListPage = 0;
        public readonly string DropListOption1 = "one";
        public readonly string DropListOption2 = "two";
        public readonly string DropListOption3 = "three";
        public readonly string TextAreaId = "textAreaId";
        public readonly int TextAreaPage = 0;
        public readonly string TextAreaValue = "textAreaValue";
        public readonly string LabelId = "labelId";
        public readonly int LabelPage = 0;
        public readonly string LabelValue = "labelValue";

        private int textfieldPositionX = 400;
        private int textfieldPositionY = 200;
        private double checkbox1Width = 20;
        private double checkbox1Height = 20;
        private int checkbox1PositionX = 400;
        private int checkbox1PositionY = 300;
        private double checkbox2Width = 20;
        private double checkbox2Height = 20;
        private int checkbox2PositionX = 400;
        private int checkbox2PositionY = 350;
        private double radio1Width = 20;
        private double radio1Height = 20;
        private int radio1PositionX = 400;
        private int radio1PositionY = 400;
        private double radio2Width = 20;
        private double radio2Height = 20;
        private int radio2PositionX = 400;
        private int radio2PositionY = 450;
        private double dropListWidth = 100;
        private double dropListHeight = 200;
        private int dropListPositionX = 100;
        private int dropListPositionY = 100;
        private double textAreaWidth = 400;
        private double textAreaHeight = 600;
        private int textAreaPositionX = 200;
        private int textAreaPositionY = 200;
        private double labelFieldWidth = 100;
        private double labelFieldHeight = 60;
        private int labelFieldPositionX = 150;
        private int labelFieldPositionY = 150;

        override public void Execute()
        {
            var template = PackageBuilder.NewPackageNamed(TemplateName)
                .DescribedAs(PackageDescription)
                    .WithSigner(SignerBuilder.NewSignerWithEmail(email1)
                                .WithFirstName(TemplateSigner1First)
                                .WithLastName(TemplateSigner1Last))
                    .WithDocument(DocumentBuilder.NewDocumentNamed(DocumentName)
                                  .FromStream(fileStream1, DocumentType.PDF)
                                  .WithSignature(SignatureBuilder.SignatureFor(email1)
                                   .OnPage(0)
                                   .AtPosition(400, 100)
                                   .WithField(FieldBuilder.TextField()
                                       .WithId(TextfieldId)
                                       .OnPage(TextfieldPage)
                                       .AtPosition(textfieldPositionX, textfieldPositionY))
                                   .WithField(FieldBuilder.CheckBox()
                                       .WithId(Checkbox1Id)
                                       .OnPage(Checkbox1Page)
                                       .WithSize(checkbox1Width, checkbox1Height)
                                       .AtPosition(checkbox1PositionX, checkbox1PositionY))
                                   .WithField(FieldBuilder.CheckBox()
                                       .WithId(Checkbox2Id)
                                       .WithValue(Checkbox2Value)
                                       .OnPage(Checkbox2Page)
                                       .WithSize(checkbox2Width, checkbox2Height)
                                       .AtPosition(checkbox2PositionX, checkbox2PositionY))
                                   .WithField(FieldBuilder.RadioButton(Radio1Group)
                                       .WithId(Radio1Id)
                                       .OnPage(Radio1Page)
                                       .WithSize(radio1Width, radio1Height)
                                       .AtPosition(radio1PositionX, radio1PositionY))
                                  .WithField(FieldBuilder.RadioButton(Radio2Group)
                                       .WithId(Radio2Id)
                                       .WithValue(Radio2Value)
                                       .OnPage(Radio2Page)
                                       .WithSize(radio2Width, radio2Height)
                                       .AtPosition(radio2PositionX, radio2PositionY))
                                  .WithField(FieldBuilder.DropList()
                                       .WithId(DropListId)
                                       .WithValue(DropListOption2)
                                       .WithValidation(FieldValidatorBuilder.Basic()
                                            .WithOption(DropListOption1)
                                            .WithOption(DropListOption2)
                                            .WithOption(DropListOption3))
                                       .OnPage(DropListPage)
                                       .WithSize(dropListWidth, dropListHeight)
                                       .AtPosition(dropListPositionX, dropListPositionY))
                                  .WithField(FieldBuilder.TextArea()
                                       .WithId(TextAreaId)
                                       .WithValue(TextAreaValue)
                                       .OnPage(TextAreaPage)
                                       .WithSize(textAreaWidth, textAreaHeight)
                                       .AtPosition(textAreaPositionX, textAreaPositionY))
                                  .WithField(FieldBuilder.Label()
                                       .WithId(LabelId)
                                       .WithValue(LabelValue)
                                       .OnPage(LabelPage)
                                       .WithSize(labelFieldWidth, labelFieldHeight)
                                       .AtPosition(labelFieldPositionX, labelFieldPositionY))))
                    .Build();

            var templateId = eslClient.CreateTemplate(template);

            template.Id = templateId;

            var newPackage = PackageBuilder.NewPackageNamed(PackageName)
                .DescribedAs(PackageDescription)
                    .WithEmailMessage(PackageEmailMessage)
                    .WithSigner(SignerBuilder.NewSignerWithEmail(email2)
                                .WithFirstName(PackageSigner2First)
                                .WithLastName(PackageSigner2Last)
                                .WithTitle(PackageSigner2Title)
                                .WithCompany(PackageSigner2Company)
                                .WithCustomId(PackageSigner2CustomId))
                    .Build();

            packageId = eslClient.CreatePackageFromTemplate(templateId, newPackage);
            retrievedPackage = eslClient.GetPackage( packageId );
        }
    }
}

