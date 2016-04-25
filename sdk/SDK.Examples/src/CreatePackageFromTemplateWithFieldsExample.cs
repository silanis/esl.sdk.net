using System;
using System.IO;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class CreatePackageFromTemplateWithFieldsExample : SDKSample
    {
        public static void Main(string[] args)
        {
            new CreatePackageFromTemplateWithFieldsExample().Run();
        }

        public readonly string DOCUMENT_NAME = "First Document";
        public readonly string DOCUMENT_ID = "doc1";
        public readonly string TEMPLATE_NAME = "CreatePackageFromTemplateWithFieldsExample Template: " + DateTime.Now;
        public readonly string PACKAGE_DESCRIPTION = "This is a package created using the e-SignLive SDK";
        public readonly string PACKAGE_EMAIL_MESSAGE = "This message should be delivered to all signers";
        public readonly string TEMPLATE_SIGNER1_FIRST = "John";
        public readonly string TEMPLATE_SIGNER1_LAST = "Smith";

        public readonly string PACKAGE_SIGNER2_FIRST = "Elvis";
        public readonly string PACKAGE_SIGNER2_LAST = "Presley";
        public readonly string PACKAGE_SIGNER2_TITLE = "The King";
        public readonly string PACKAGE_SIGNER2_COMPANY = "Elvis Presley International";
        public readonly string PACKAGE_SIGNER2_CUSTOM_ID = "Signer2";

        public readonly string TEXTFIELD_ID = "textFieldId";
        public readonly int TEXTFIELD_PAGE = 0;
        public readonly string CHECKBOX_1_ID = "checkbox1Id";
        public readonly int CHECKBOX_1_PAGE = 0;
        public readonly string CHECKBOX_2_ID = "checkbox2Id";
        public readonly int CHECKBOX_2_PAGE = 0;
        public readonly bool CHECKBOX_2_VALUE = true;
        public readonly string RADIO_1_ID = "radio1Id";
        public readonly int RADIO_1_PAGE = 0;
        public readonly string RADIO_1_GROUP = "group";
        public readonly string RADIO_2_ID = "radio2Id";
        public readonly int RADIO_2_PAGE = 0;
        public readonly bool RADIO_2_VALUE = true;
        public readonly string RADIO_2_GROUP = "group";
        public readonly string DROP_LIST_ID = "dropListId";
        public readonly int DROP_LIST_PAGE = 0;
        public readonly string DROP_LIST_OPTION1 = "one";
        public readonly string DROP_LIST_OPTION2 = "two";
        public readonly string DROP_LIST_OPTION3 = "three";
        public readonly string TEXT_AREA_ID = "textAreaId";
        public readonly int TEXT_AREA_PAGE = 0;
        public readonly string TEXT_AREA_VALUE = "textAreaValue";
        public readonly string LABEL_ID = "labelId";
        public readonly int LABEL_PAGE = 0;
        public readonly string LABEL_VALUE = "labelValue";

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
            DocumentPackage template = PackageBuilder.NewPackageNamed(TEMPLATE_NAME)
                .DescribedAs(PACKAGE_DESCRIPTION)
                    .WithSigner(SignerBuilder.NewSignerWithEmail(email1)
                                .WithFirstName(TEMPLATE_SIGNER1_FIRST)
                                .WithLastName(TEMPLATE_SIGNER1_LAST))
                    .WithDocument(DocumentBuilder.NewDocumentNamed(DOCUMENT_NAME)
                                  .FromStream(fileStream1, DocumentType.PDF)
                                  .WithSignature(SignatureBuilder.SignatureFor(email1)
                                   .OnPage(0)
                                   .AtPosition(400, 100)
                                   .WithField(FieldBuilder.TextField()
                                       .WithId(TEXTFIELD_ID)
                                       .OnPage(TEXTFIELD_PAGE)
                                       .AtPosition(textfieldPositionX, textfieldPositionY))
                                   .WithField(FieldBuilder.CheckBox()
                                       .WithId(CHECKBOX_1_ID)
                                       .OnPage(CHECKBOX_1_PAGE)
                                       .WithSize(checkbox1Width, checkbox1Height)
                                       .AtPosition(checkbox1PositionX, checkbox1PositionY))
                                   .WithField(FieldBuilder.CheckBox()
                                       .WithId(CHECKBOX_2_ID)
                                       .WithValue(CHECKBOX_2_VALUE)
                                       .OnPage(CHECKBOX_2_PAGE)
                                       .WithSize(checkbox2Width, checkbox2Height)
                                       .AtPosition(checkbox2PositionX, checkbox2PositionY))
                                   .WithField(FieldBuilder.RadioButton(RADIO_1_GROUP)
                                       .WithId(RADIO_1_ID)
                                       .OnPage(RADIO_1_PAGE)
                                       .WithSize(radio1Width, radio1Height)
                                       .AtPosition(radio1PositionX, radio1PositionY))
                                  .WithField(FieldBuilder.RadioButton(RADIO_2_GROUP)
                                       .WithId(RADIO_2_ID)
                                       .WithValue(RADIO_2_VALUE)
                                       .OnPage(RADIO_2_PAGE)
                                       .WithSize(radio2Width, radio2Height)
                                       .AtPosition(radio2PositionX, radio2PositionY))
                                  .WithField(FieldBuilder.DropList()
                                       .WithId(DROP_LIST_ID)
                                       .WithValue(DROP_LIST_OPTION2)
                                       .WithValidation(FieldValidatorBuilder.Basic()
                                            .WithOption(DROP_LIST_OPTION1)
                                            .WithOption(DROP_LIST_OPTION2)
                                            .WithOption(DROP_LIST_OPTION3))
                                       .OnPage(DROP_LIST_PAGE)
                                       .WithSize(dropListWidth, dropListHeight)
                                       .AtPosition(dropListPositionX, dropListPositionY))
                                  .WithField(FieldBuilder.TextArea()
                                       .WithId(TEXT_AREA_ID)
                                       .WithValue(TEXT_AREA_VALUE)
                                       .OnPage(TEXT_AREA_PAGE)
                                       .WithSize(textAreaWidth, textAreaHeight)
                                       .AtPosition(textAreaPositionX, textAreaPositionY))
                                  .WithField(FieldBuilder.Label()
                                       .WithId(LABEL_ID)
                                       .WithValue(LABEL_VALUE)
                                       .OnPage(LABEL_PAGE)
                                       .WithSize(labelFieldWidth, labelFieldHeight)
                                       .AtPosition(labelFieldPositionX, labelFieldPositionY))))
                    .Build();

            PackageId templateId = eslClient.CreateTemplate(template);

            template.Id = templateId;

            DocumentPackage newPackage = PackageBuilder.NewPackageNamed(PackageName)
                .DescribedAs(PACKAGE_DESCRIPTION)
                    .WithEmailMessage(PACKAGE_EMAIL_MESSAGE)
                    .WithSigner(SignerBuilder.NewSignerWithEmail(email2)
                                .WithFirstName(PACKAGE_SIGNER2_FIRST)
                                .WithLastName(PACKAGE_SIGNER2_LAST)
                                .WithTitle(PACKAGE_SIGNER2_TITLE)
                                .WithCompany(PACKAGE_SIGNER2_COMPANY)
                                .WithCustomId(PACKAGE_SIGNER2_CUSTOM_ID))
                    .Build();

            packageId = eslClient.CreatePackageFromTemplate(templateId, newPackage);
            retrievedPackage = eslClient.GetPackage( packageId );
        }
    }
}

