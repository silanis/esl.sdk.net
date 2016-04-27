using System.Collections.Generic;

namespace Silanis.ESL.SDK
{
    /// <summary>
    /// The QRCodeService class provides methods to help create, modify, get, delete and update QR codes in documents.
    /// </summary>
    public class QRCodeService
    {
        private QRCodeApiClient apiClient;

        internal QRCodeService(QRCodeApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        /// <summary>
        ///  Add a QR code field to the document.
        /// </summary>
        /// <returns>The field Id of the added QR code.</returns>
        /// <param name="packageId">Package identifier of the DocumentPackage which contains the document to add QR code to.</param>
        /// <param name="documentId">Document identifier of the Document to add QR code to.</param>
        /// <param name="qrCodeField">Qr code field.</param>
        public string AddQRCode(PackageId packageId, string documentId, Field qrCodeField)
        {
            var apiField = new FieldConverter(qrCodeField).ToAPIField();
            return apiClient.AddQRCode(packageId.Id, documentId, apiField);
        }

        /// <summary>
        ///  Modify the QR code in document.
        /// </summary>
        /// <param name="packageId">Package identifier of the DocumentPackage which contains the document with the QR code to modify.</param>
        /// <param name="documentId">Document identifier of the Document which contains the QR code to modify.</param>
        /// <param name="qrCodeField">The new QR code field</param>
        public void ModifyQRCode(PackageId packageId, string documentId, Field qrCodeField)
        {
            var apiField = new FieldConverter(qrCodeField).ToAPIField();
            apiClient.ModifyQRCode(packageId.Id, documentId, apiField);
        }

        /// <summary>
        ///  Get the QR code from document.
        /// </summary>
        /// <returns>The QR code field.</returns>
        /// <param name="packageId">Package identifier of the DocumentPackage which contains the document with the QR code to get.</param>
        /// <param name="documentId">Document identifier of the Document to get QR code from.</param>
        /// <param name="qrCodeFieldId">Field identifier of the QR code to get.</param>
        public Field GetQRCode(PackageId packageId, string documentId, string qrCodeFieldId)
        {
            var apiField = apiClient.GetQRCode(packageId.Id, documentId, qrCodeFieldId);
            return new FieldConverter(apiField).ToSDKField();
        }

        /// <summary>
        ///  Delete the QR code from document.
        /// </summary>
        /// <param name="packageId">Package identifier of the DocumentPackage which contains the document with QR code to delete.</param>
        /// <param name="documentId">Document identifier of the Document which contains.</param>
        /// <param name="qrCodeFieldId">Field identifier of QR code to delete.</param>
        public void DeleteQRCode(PackageId packageId, string documentId, string qrCodeFieldId)
        {
            apiClient.DeleteQRCode(packageId.Id, documentId, qrCodeFieldId);
        }

        /// <summary>
        /// Update all the QR codes for a document.
        /// </summary>
        /// <param name="packageId">Package identifier of the DocumentPackage which contains the document with QR codes to update</param>
        /// <param name="documentId">Document identifier of the Document which contains the QR codes to update</param>
        /// <param name="qrCodeList">The list of QR codes (Field) to update for document</param>
        public void UpdateQRCodes(PackageId packageId, string documentId, IList<Field> qrCodeList)
        {
            IList<API.Field> fieldList = new List<API.Field>();
            foreach (var sdkField in qrCodeList)
            {
                var apiField = new FieldConverter(sdkField).ToAPIField();
                fieldList.Add(apiField);
            }

            apiClient.UpdateQRCodes(packageId.Id, documentId, fieldList);
        }
    }
}

