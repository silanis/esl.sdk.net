using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
    [TestClass]
    public class FieldStyleUtilityTest
    {
        [TestMethod]
        public void whenBuildingBindingStringForBOUND_DATEFieldStyleThenBINDING_DATEIsReturned()
        {
            var expectedBinding = "{approval.signed}";


            var actualBinding = FieldStyleUtility.Binding(FieldStyle.BOUND_DATE);


            Assert.AreEqual(expectedBinding, actualBinding);
        }

        [TestMethod]
        public void whenBuildingBindingStringForBOUND_NAMEFieldStyleThenBINDING_NAMEIsReturned()
        {
            var expectedBinding = "{signer.name}";


            var actualBinding = FieldStyleUtility.Binding(FieldStyle.BOUND_NAME);


            Assert.AreEqual(expectedBinding, actualBinding);
        }

        [TestMethod]
        public void whenBuildingBindingStringForBOUND_TITLEFieldStyleThenBINDING_TITLEIsReturned()
        {
            var expectedBinding = "{signer.title}";


            var actualBinding = FieldStyleUtility.Binding(FieldStyle.BOUND_TITLE);


            Assert.AreEqual(expectedBinding, actualBinding);
        }

        [TestMethod]
        public void whenBuildingBindingStringForBOUND_COMPANYFieldStyleThenBINDING_COMPANYIsReturned()
        {
            var expectedBinding = "{signer.company}";


            var actualBinding = FieldStyleUtility.Binding(FieldStyle.BOUND_COMPANY);


            Assert.AreEqual(expectedBinding, actualBinding);
        }

        [TestMethod]
        public void whenBuildingBindingStringForBOUND_QRCODEFieldStyleThenNULLIsReturned()
        {
            string expectedBinding = null;


            var actualBinding = FieldStyleUtility.Binding(FieldStyle.BOUND_QRCODE);


            Assert.AreEqual(expectedBinding, actualBinding);
        }

        [TestMethod]
        public void whenBuildingBindingStringForUNBOUND_CUSTOM_FIELDFieldStyleThenNULLIsReturned()
        {
            string expectedBinding = null;


            var actualBinding = FieldStyleUtility.Binding(FieldStyle.UNBOUND_CUSTOM_FIELD);


            Assert.AreEqual(expectedBinding, actualBinding);
        }

        [TestMethod]
        public void whenBuildingBindingStringForUNBOUND_TEXT_FIELDFieldStyleThenNULLIsReturned()
        {
            string expectedBinding = null;


            var actualBinding = FieldStyleUtility.Binding(FieldStyle.UNBOUND_TEXT_FIELD);


            Assert.AreEqual(expectedBinding, actualBinding);
        }

        [TestMethod]
        public void whenBuildingBindingStringForUNBOUND_CHECK_BOXFieldStyleThenNULLIsReturned()
        {
            string expectedBinding = null;


            var actualBinding = FieldStyleUtility.Binding(FieldStyle.UNBOUND_CHECK_BOX);


            Assert.AreEqual(expectedBinding, actualBinding);
        }

        [TestMethod]
        public void whenBuildingBindingStringForUNBOUND_RADIO_BUTTONFieldStyleThenNULLIsReturned()
        {
            string expectedBinding = null;


            var actualBinding = FieldStyleUtility.Binding(FieldStyle.UNBOUND_RADIO_BUTTON);


            Assert.AreEqual(expectedBinding, actualBinding);
        }

        
        [TestMethod]
        public void whenBuildingBindingStringForDROP_LISTFieldStyleThenNULLIsReturned()
        {
            string expectedBinding = null;


            var actualBinding = FieldStyleUtility.Binding(FieldStyle.DROP_LIST);


            Assert.AreEqual(expectedBinding, actualBinding);
        }

        [TestMethod]
        public void whenBuildingBindingStringForLABELFieldStyleThenNULLIsReturned()
        {
            string expectedBinding = null;


            var actualBinding = FieldStyleUtility.Binding(FieldStyle.DROP_LIST);


            Assert.AreEqual(expectedBinding, actualBinding);
        }

        [TestMethod]
        public void whenBuildingBindingStringForAnyUnkownFieldStyleThenNULLIsReturned()
        {
            string expectedBinding = null;


            var actualBinding = FieldStyleUtility.Binding(FieldStyle.valueOf("ThisFieldStyleDoesNotExistInSDK"));


            Assert.AreEqual(expectedBinding, actualBinding);
        }

    }
}   