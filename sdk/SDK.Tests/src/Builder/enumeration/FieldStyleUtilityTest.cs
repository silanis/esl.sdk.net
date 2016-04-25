using System;
using NUnit.Framework;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;
using Silanis.ESL.API;

namespace SDK.Tests
{
    [TestFixture]
    public class FieldStyleUtilityTest
    {
        [Test]
        public void whenBuildingBindingStringForBOUND_DATEFieldStyleThenBINDING_DATEIsReturned()
        {
            string expectedBinding = "{approval.signed}";


            string actualBinding = FieldStyleUtility.Binding(FieldStyle.BOUND_DATE);


            Assert.AreEqual(expectedBinding, actualBinding);
        }

        [Test]
        public void whenBuildingBindingStringForBOUND_NAMEFieldStyleThenBINDING_NAMEIsReturned()
        {
            string expectedBinding = "{signer.name}";


            string actualBinding = FieldStyleUtility.Binding(FieldStyle.BOUND_NAME);


            Assert.AreEqual(expectedBinding, actualBinding);
        }

        [Test]
        public void whenBuildingBindingStringForBOUND_TITLEFieldStyleThenBINDING_TITLEIsReturned()
        {
            string expectedBinding = "{signer.title}";


            string actualBinding = FieldStyleUtility.Binding(FieldStyle.BOUND_TITLE);


            Assert.AreEqual(expectedBinding, actualBinding);
        }

        [Test]
        public void whenBuildingBindingStringForBOUND_COMPANYFieldStyleThenBINDING_COMPANYIsReturned()
        {
            string expectedBinding = "{signer.company}";


            string actualBinding = FieldStyleUtility.Binding(FieldStyle.BOUND_COMPANY);


            Assert.AreEqual(expectedBinding, actualBinding);
        }

        [Test]
        public void whenBuildingBindingStringForBOUND_QRCODEFieldStyleThenNULLIsReturned()
        {
            string expectedBinding = null;


            string actualBinding = FieldStyleUtility.Binding(FieldStyle.BOUND_QRCODE);


            Assert.AreEqual(expectedBinding, actualBinding);
        }

        [Test]
        public void whenBuildingBindingStringForUNBOUND_CUSTOM_FIELDFieldStyleThenNULLIsReturned()
        {
            string expectedBinding = null;


            string actualBinding = FieldStyleUtility.Binding(FieldStyle.UNBOUND_CUSTOM_FIELD);


            Assert.AreEqual(expectedBinding, actualBinding);
        }

        [Test]
        public void whenBuildingBindingStringForUNBOUND_TEXT_FIELDFieldStyleThenNULLIsReturned()
        {
            string expectedBinding = null;


            string actualBinding = FieldStyleUtility.Binding(FieldStyle.UNBOUND_TEXT_FIELD);


            Assert.AreEqual(expectedBinding, actualBinding);
        }

        [Test]
        public void whenBuildingBindingStringForUNBOUND_CHECK_BOXFieldStyleThenNULLIsReturned()
        {
            string expectedBinding = null;


            string actualBinding = FieldStyleUtility.Binding(FieldStyle.UNBOUND_CHECK_BOX);


            Assert.AreEqual(expectedBinding, actualBinding);
        }

        [Test]
        public void whenBuildingBindingStringForUNBOUND_RADIO_BUTTONFieldStyleThenNULLIsReturned()
        {
            string expectedBinding = null;


            string actualBinding = FieldStyleUtility.Binding(FieldStyle.UNBOUND_RADIO_BUTTON);


            Assert.AreEqual(expectedBinding, actualBinding);
        }

        
        [Test]
        public void whenBuildingBindingStringForDROP_LISTFieldStyleThenNULLIsReturned()
        {
            string expectedBinding = null;


            string actualBinding = FieldStyleUtility.Binding(FieldStyle.DROP_LIST);


            Assert.AreEqual(expectedBinding, actualBinding);
        }

        [Test]
        public void whenBuildingBindingStringForLABELFieldStyleThenNULLIsReturned()
        {
            string expectedBinding = null;


            string actualBinding = FieldStyleUtility.Binding(FieldStyle.DROP_LIST);


            Assert.AreEqual(expectedBinding, actualBinding);
        }

        [Test]
        public void whenBuildingBindingStringForAnyUnkownFieldStyleThenNULLIsReturned()
        {
            string expectedBinding = null;


            string actualBinding = FieldStyleUtility.Binding(FieldStyle.valueOf("ThisFieldStyleDoesNotExistInSDK"));


            Assert.AreEqual(expectedBinding, actualBinding);
        }

    }
}   