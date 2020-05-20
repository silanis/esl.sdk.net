using System;
using System.IO;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class GenericFieldsExample : SDKSample
    {
        public static void Main (string [] args)
        {
            new GenericFieldsExample ().Run ();
        }

        public static readonly string DOCUMENT_NAME = "My Document";
        public static readonly string TEXTFIELD_ID = "textFieldId";
        public static readonly int TEXTFIELD_PAGE = 0;
        public static readonly Nullable<Int32> TEXTFIELD_FONT_SIZE = 0;
        public static readonly string CHECKBOX_ID = "checkboxId";
        public static readonly int CHECKBOX_PAGE = 0;
        public static readonly bool CHECKBOX_VALUE = true;
        public static readonly int RADIO_PAGE = 0;
        public static readonly double RADIO_WIDTH = 20;
        public static readonly double RADIO_HEIGHT = 20;
        public static readonly string RADIO_ID_1 = "radioId1";
        public static readonly string RADIO_ID_2 = "radioId2";
        public static readonly string RADIO_ID_3 = "radioId3";
        public static readonly string RADIO_ID_4 = "radioId4";
        public static readonly string RADIO_GROUP_1 = "group1";
        public static readonly string RADIO_GROUP_2 = "group2";
        public static readonly string DROP_LIST_ID = "dropListId";
        public static readonly int DROP_LIST_PAGE = 0;
        public static readonly string DROP_LIST_OPTION1 = "one";
        public static readonly string DROP_LIST_OPTION2 = "two";
        public static readonly string DROP_LIST_OPTION3 = "three";
        public static readonly Nullable<Int32> DROP_LIST_FONT_SIZE = 8;
        public static readonly string TEXT_AREA_ID = "textAreaId";
        public static readonly int TEXT_AREA_PAGE = 0;
        public static readonly string TEXT_AREA_VALUE = "textAreaValue";
        public static readonly Nullable<Int32> TEXT_AREA_FONT_SIZE = 10;
        public static readonly string LABEL_ID = "labelId";
        public static readonly int LABEL_PAGE = 0;
        public static readonly string LABEL_VALUE = "labelValue";
        public static readonly Nullable<Int32> LABEL_FIELD_FONT_SIZE = 16;
        public static readonly string DATEPICKER_ID = "datepickerId";
        public static readonly string DATEPICKER_NAME = "datepickerName";
        public static readonly int DATEPICKER_PAGE = 0;
        public static readonly string DATEPICKER_FORMAT = "MM-dd-YYYY";
        public static readonly string DATEPICKER_VALUE = DateTime.Today.ToString("MM-dd-yyyy");
        public static readonly Nullable<Int32> DATEPICKER_FIELD_FONT_SIZE = null;

        override public void Execute ()
        {
            DocumentPackage package = PackageBuilder.NewPackageNamed (PackageName)
                    .DescribedAs ("This is a new package")
                    .WithSigner (SignerBuilder.NewSignerWithEmail (email1)
                                .WithFirstName ("John")
                                .WithLastName ("Smith"))
                    .WithDocument (DocumentBuilder.NewDocumentNamed (DOCUMENT_NAME)
                                  .FromStream (fileStream1, DocumentType.PDF)
                                  .WithSignature (SignatureBuilder.SignatureFor (email1)
                                          .OnPage (0)
                                           .AtPosition (500, 100)
                                    .WithField (FieldBuilder.TextField ()
                                    .WithId (TEXTFIELD_ID)
                                    .WithFontSize (TEXTFIELD_FONT_SIZE)
                                    .OnPage (TEXTFIELD_PAGE)
                                    .AtPosition (500, 200))
                                  .WithField (FieldBuilder.CheckBox ()
                                   .WithId (CHECKBOX_ID)
                                   .WithValue (CHECKBOX_VALUE)
                                   .OnPage (CHECKBOX_PAGE)
                                   .AtPosition (500, 300))
                               .WithField (FieldBuilder.RadioButton (RADIO_GROUP_1)
                                   .WithId (RADIO_ID_1)
                                   .WithValue (false)
                                   .WithSize (RADIO_WIDTH, RADIO_HEIGHT)
                                   .OnPage (RADIO_PAGE)
                                   .AtPosition (500, 400))
                               .WithField (FieldBuilder.RadioButton (RADIO_GROUP_1)
                                   .WithId (RADIO_ID_2)
                                   .WithValue (true)
                                   .WithSize (RADIO_WIDTH, RADIO_HEIGHT)
                                   .OnPage (RADIO_PAGE)
                                   .AtPosition (500, 450))
                               .WithField (FieldBuilder.RadioButton (RADIO_GROUP_2)
                                   .WithId (RADIO_ID_3)
                                   .WithValue (true)
                                   .WithSize (RADIO_WIDTH, RADIO_HEIGHT)
                                   .OnPage (RADIO_PAGE)
                                   .AtPosition (500, 500))
                               .WithField (FieldBuilder.RadioButton (RADIO_GROUP_2)
                                    .WithId (RADIO_ID_4)
                                    .WithValue (false)
                                    .WithSize (RADIO_WIDTH, RADIO_HEIGHT)
                                    .OnPage (RADIO_PAGE)
                                    .AtPosition (500, 550))
                               .WithField (FieldBuilder.DropList ()
                                    .WithId (DROP_LIST_ID)
                                    .WithValue (DROP_LIST_OPTION2)
                                    .WithFontSize (DROP_LIST_FONT_SIZE)
                                    .WithValidation (FieldValidatorBuilder.Basic ()
                                        .WithOption (DROP_LIST_OPTION1)
                                        .WithOption (DROP_LIST_OPTION2)
                                        .WithOption (DROP_LIST_OPTION3))
                                    .OnPage (DROP_LIST_PAGE)
                                    .WithSize (100, 200)
                                    .AtPosition (100, 100))
                               .WithField (FieldBuilder.TextArea ()
                                   .WithId (TEXT_AREA_ID)
                                   .WithValue (TEXT_AREA_VALUE)
                                   .WithFontSize (TEXT_AREA_FONT_SIZE)
                                   .OnPage (TEXT_AREA_PAGE)
                                   .WithSize (400, 600)
                                   .AtPosition (200, 200))
                               .WithField (FieldBuilder.Label ()
                                   .WithId (LABEL_ID)
                                   .WithValue (LABEL_VALUE)
                                   .WithFontSize (LABEL_FIELD_FONT_SIZE)
                                   .OnPage (LABEL_PAGE)
                                   .WithSize (100, 60)
                                   .AtPosition (220, 220))
                               .WithField (FieldBuilder.Datepicker ()
                                   .WithId (DATEPICKER_ID)
                                   .WithName (DATEPICKER_NAME)
                                   .WithValue (DATEPICKER_VALUE)
                                   .WithFontSize (DATEPICKER_FIELD_FONT_SIZE)
                                   .OnPage (DATEPICKER_PAGE)
                                   .WithSize (100, 60)
                                   .AtPosition (150, 150)
                                   .WithValidation (FieldValidatorBuilder.DatepickerFormat (DATEPICKER_FORMAT)
                                       .Required ()))))
                    .Build ();

            packageId = eslClient.CreatePackage (package);

            eslClient.SendPackage (PackageId);
            retrievedPackage = eslClient.GetPackage (packageId);
        }
    }
}