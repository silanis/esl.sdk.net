using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK.Builder;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
    public class FieldBuilderTest
    {
        [TestMethod]
        public void BuildsFieldWithDefaultValues()
        {
            var field = FieldBuilder.NewField().AtPosition(100, 125).Build();

            Assert.AreEqual(FieldBuilder.DEFAULT_WIDTH, field.Width);
            Assert.AreEqual(FieldBuilder.DEFAULT_HEIGHT, field.Height);
            Assert.AreEqual(FieldBuilder.DEFAULT_STYLE, field.Style);
        }

        [TestMethod]
        public void BuildsFieldWithSpecifiedValues()
        {
            var field = FieldBuilder.NewField()
				.AtPosition(100, 125)
				.OnPage(2)
				.WithSize(75, 80)
				.WithStyle(FieldStyle.UNBOUND_CHECK_BOX)
				.Build();

            Assert.AreEqual(100, field.X);
            Assert.AreEqual(125, field.Y);
            Assert.AreEqual(75, field.Width);
            Assert.AreEqual(80, field.Height);
            Assert.AreEqual(FieldStyle.UNBOUND_CHECK_BOX, field.Style);
            Assert.AreEqual(2, field.Page);
        }

        [TestMethod]
        public void CreatingNewSignatureDateFieldSetsStyle()
        {
            var field = FieldBuilder.SignatureDate().AtPosition(100, 100).Build();

            Assert.AreEqual(FieldStyle.BOUND_DATE, field.Style);
        }

        [TestMethod]
        public void creatingNewSignerNameFieldSetsStyle()
        {
            var field = FieldBuilder.SignerName().AtPosition(100, 100).Build();

            Assert.AreEqual(FieldStyle.BOUND_NAME, field.Style);
        }

        [TestMethod]
        public void creatingNewSignerTitleFieldSetsStyle()
        {
            var field = FieldBuilder.SignerTitle().AtPosition(100, 100).Build();

            Assert.AreEqual(FieldStyle.BOUND_TITLE, field.Style);
        }

        [TestMethod]
        public void creatingNewSignerCompanyFieldSetsStyle()
        {
            var field = FieldBuilder.SignerCompany().AtPosition(100, 100).Build();

            Assert.AreEqual(FieldStyle.BOUND_COMPANY, field.Style);
        }

        [TestMethod]
        public void creatingTextFieldSetsStyle()
        {
            var field = FieldBuilder.TextField().AtPosition(100, 100).Build();

            Assert.AreEqual(FieldStyle.UNBOUND_TEXT_FIELD, field.Style);
        }

        [TestMethod]
        public void creatingCheckBoxFieldSetsStyle()
        {
            var field = FieldBuilder.CheckBox().AtPosition(100, 100).Build();

            Assert.AreEqual(FieldStyle.UNBOUND_CHECK_BOX, field.Style);
        }

        [TestMethod]
        public void creatingRadioButtonFieldSetsStyle()
        {
            var field = FieldBuilder.RadioButton("group").AtPosition(100, 100).Build();

            Assert.AreEqual(FieldStyle.UNBOUND_RADIO_BUTTON, field.Style);
        }

        [TestMethod]
        public void creatingTextAreaFieldSetsStyle()
        {
            var field = FieldBuilder.TextArea().AtPosition(100, 100).Build();

            Assert.AreEqual(FieldStyle.TEXT_AREA, field.Style);
        }

        [TestMethod]
        public void creatingDropListFieldSetsStyle()
        {
            var field = FieldBuilder.DropList().AtPosition(100, 100).Build();

            Assert.AreEqual(FieldStyle.DROP_LIST, field.Style);
        }

        [TestMethod]
        public void creatingQRCodeFieldSetsStyle()
        {
            var field = FieldBuilder.QRCode().AtPosition(100, 100).Build();

            Assert.AreEqual(FieldStyle.BOUND_QRCODE, field.Style);
            Assert.AreEqual(77.0, field.Height);
            Assert.AreEqual(77.0, field.Width);
        }
    }
}