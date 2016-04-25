using System;

namespace Silanis.ESL.SDK
{
    internal class FieldStyleUtility
    {
        internal static string BINDING_DATE = "{approval.signed}";
        internal static string BINDING_NAME = "{signer.name}";
        internal static string BINDING_TITLE = "{signer.title}";
        internal static string BINDING_COMPANY = "{signer.company}";

        public static string Binding(FieldStyle style)
        {
            switch (style.getSdkValue())
            {
                case "BOUND_DATE":
                    return BINDING_DATE;
                case "BOUND_NAME":
                    return BINDING_NAME;
                case "BOUND_TITLE":
                    return BINDING_TITLE;
                case "BOUND_COMPANY":
                    return BINDING_COMPANY;
                case "BOUND_QRCODE":
                case "UNBOUND_CUSTOM_FIELD":
                case "UNBOUND_TEXT_FIELD":
                case "UNBOUND_CHECK_BOX":
                case "UNBOUND_RADIO_BUTTON":
                case "DROP_LIST":
                case "TEXT_AREA":
                case "LABEL":
                default:
                    return null;
            }
        }
    }
}