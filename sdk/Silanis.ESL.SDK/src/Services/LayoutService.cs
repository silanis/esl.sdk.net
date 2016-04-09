using System;
using System.Collections.Generic;

namespace Silanis.ESL.SDK
{
    /// <summary>
    /// The LayoutService class provides methods to help create, get and apply document layouts.
    /// </summary>
    public class LayoutService
    {
        private LayoutApiClient apiClient;

        internal LayoutService(LayoutApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        /// <summary>
        /// Create a document layout from an already created DocumentPackage. Will only save document fields for one document
        /// in the package.
        /// </summary>
        /// <returns>The layout id.</returns>
        /// <param name="layout">The DocumentPackage with one document from which to create layout.</param>
        public string CreateLayout(DocumentPackage layout)
        {
            var layoutToCreate = new DocumentPackageConverter(layout).ToAPIPackage();
            foreach (var document in layout.Documents)
            {
                layoutToCreate.AddDocument(new DocumentConverter(document).ToAPIDocument(layoutToCreate));
            }

            return apiClient.CreateLayout(layoutToCreate, layout.Id.Id);
        }

        /// <summary>
        /// Get a list of layouts (DocumentPackages).
        /// </summary>
        /// <returns>The list of layouts.</returns>
        /// <param name="direction">Retrieved list to be sorted in ascending or descending order by name.</param>
        /// <param name="request">Identifying which page of results to return.</param>
        public IList<DocumentPackage> GetLayouts(Direction direction, PageRequest request)
        {
            var results = apiClient.GetLayouts(direction, request);

            IList<DocumentPackage> layouts = new List<DocumentPackage>();
            foreach (var layout in results.Results)
            {
                layouts.Add(new DocumentPackageConverter(layout).ToSDKPackage());
            }

            return layouts;
        }

        /// <summary>
        /// Apply a document layout to a document in a DocumentPackage. Adds fields to signer's signature or if the signer
        /// does not exist, will create placeholders.
        /// </summary>
        /// <param name="packageId">The package id of the DocumentPackage to apply layout.</param>
        /// <param name="documentId">The document id of the document to apply layout.</param>
        /// <param name="layoutId">The layout id of the layout to apply.</param>
        public void ApplyLayout(PackageId packageId, String documentId, String layoutId)
        {
            apiClient.ApplyLayout(packageId.Id, documentId, layoutId);
        }

    }
}

