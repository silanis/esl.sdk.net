using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class GenericFieldsExample : SdkSample
    {
        public static void Main(string[] args)
        {
            new GenericFieldsExample().Run();
        }

        public static readonly string DocumentName = "My Document";
        public static readonly string TextfieldId = "textFieldId";
        public static readonly int TextfieldPage = 0;
        public static readonly string CheckboxId = "checkboxId";
        public static readonly int CheckboxPage = 0;
        public static readonly bool CheckboxValue = true;
        public static readonly int RadioPage = 0;
        public static readonly double RadioWidth = 20;
        public static readonly double RadioHeight = 20;
        public static readonly string RadioId1 = "radioId1";
        public static readonly string RadioId2 = "radioId2";
        public static readonly string RadioId3 = "radioId3";
        public static readonly string RadioId4 = "radioId4";
        public static readonly string RadioGroup1 = "group1";
        public static readonly string RadioGroup2 = "group2";
        public static readonly int DropListPage = 0;
        public static readonly string DropListId = "dropListId";
        public static readonly string DropListOption1 = "one";
        public static readonly string DropListOption2 = "two";
        public static readonly string DropListOption3 = "three";
        public static readonly string TextAreaId = "textAreaId";
        public static readonly int TextAreaPage = 0;
        public static readonly string TextAreaValue = "textAreaValue";
        public static readonly string LabelId = "labelId";
        public static readonly int LabelPage = 0;
        public static readonly string LabelValue = "labelValue";

        override public void Execute()
        {
            var package = PackageBuilder.NewPackageNamed(PackageName)
					.DescribedAs("This is a new package")
					.WithSigner(SignerBuilder.NewSignerWithEmail(email1)
					            .WithFirstName("John")
					            .WithLastName("Smith"))
                    .WithDocument(DocumentBuilder.NewDocumentNamed(DocumentName)
                                  .FromStream(fileStream1, DocumentType.PDF)
					              .WithSignature(SignatureBuilder.SignatureFor(email1)
					              		.OnPage(0)
					               		.AtPosition(500, 100)
			               		.WithField(FieldBuilder.TextField()
                                    .WithId(TextfieldId)
                                    .OnPage(TextfieldPage)
                                    .AtPosition(500, 200))
		               		   .WithField(FieldBuilder.CheckBox()
                                   .WithId(CheckboxId)
                                   .WithValue(CheckboxValue)
                                   .OnPage(CheckboxPage)
                                   .AtPosition(500, 300))
                               .WithField(FieldBuilder.RadioButton(RadioGroup1)
                                   .WithId(RadioId1)
                                   .WithValue(false)
                                   .WithSize(RadioWidth, RadioHeight)  
                                   .OnPage(RadioPage)
                                   .AtPosition(500, 400))
                               .WithField(FieldBuilder.RadioButton(RadioGroup1)
                                   .WithId(RadioId2)
                                   .WithValue(true)
                                   .WithSize(RadioWidth, RadioHeight) 
                                   .OnPage(RadioPage)
                                   .AtPosition(500, 450))
                               .WithField(FieldBuilder.RadioButton(RadioGroup2)
                                   .WithId(RadioId3)
                                   .WithValue(true)
                                   .WithSize(RadioWidth, RadioHeight)
                                   .OnPage(RadioPage)
                                   .AtPosition(500, 500))
                               .WithField(FieldBuilder.RadioButton(RadioGroup2)
                                    .WithId(RadioId4)
                                    .WithValue(false)
                                    .WithSize(RadioWidth, RadioHeight)
                                    .OnPage(RadioPage)
                                    .AtPosition(500, 550))
                               .WithField(FieldBuilder.DropList()
                                    .WithId(DropListId)
                                    .WithValue(DropListOption2)
                                    .WithValidation(FieldValidatorBuilder.Basic()
                                        .WithOption(DropListOption1)
                                        .WithOption(DropListOption2)
                                        .WithOption(DropListOption3))
                                    .OnPage(DropListPage)
                                    .WithSize(100, 200)
                               .AtPosition(100, 100))
                               .WithField(FieldBuilder.TextArea()
                                   .WithId(TextAreaId)
                                   .WithValue(TextAreaValue)
                                   .OnPage(TextAreaPage)
                                   .WithSize(400, 600)
                                   .AtPosition(200, 200))
                               .WithField(FieldBuilder.Label()
                                   .WithId(LabelId)
                                   .WithValue(LabelValue)
                                   .OnPage(LabelPage)
                                   .WithSize(100, 60)
                                   .AtPosition(220, 220))))
					.Build();

            packageId = eslClient.CreatePackage(package);

            eslClient.SendPackage(PackageId);
            retrievedPackage = eslClient.GetPackage(packageId);
        }
    }
}