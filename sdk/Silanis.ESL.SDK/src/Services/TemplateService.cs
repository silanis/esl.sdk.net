using System;
using Silanis.ESL.SDK.Internal;
using Newtonsoft.Json;
using Silanis.ESL.API;

namespace Silanis.ESL.SDK.Services
{
    public class TemplateService
    {
		private PackageService packageService;
        private TemplateApiClient apiClient;
        
        internal TemplateService(TemplateApiClient apiClient, PackageService packageService)
        {
            this.apiClient = apiClient;
			this.packageService = packageService;
        }
        
        internal PackageId CreateTemplateFromPackage(PackageId originalPackageId, Silanis.ESL.API.Package delta)
        {
            string templateId = apiClient.CreateTemplateFromPackage(originalPackageId.Id, delta);
            return new PackageId(templateId);
        }
        
        internal PackageId CreatePackageFromTemplate(PackageId templateId, Package delta)
        {
            string packageId = apiClient.CreatePackageFromTemplate(templateId.Id, delta);
            return new PackageId(packageId);
        }
            
		internal PackageId CreateTemplate(Package template)
		{
            template.Type = "TEMPLATE";
            string packageId = apiClient.CreateTemplate(template);
            return new PackageId(packageId);
		}

		public void Update(DocumentPackage template)
		{
			if (template.Id == null)
			{
				throw new ArgumentNullException("template.Id");
			}

			Silanis.ESL.API.Package apiTemplate = new DocumentPackageConverter(template).ToAPIPackage();
            apiTemplate.Type = "TEMPLATE";
            apiClient.Update(apiTemplate);
		}

		/// <summary>
		/// Deletes the document from the template.
		/// </summary>
		/// <param name="templateId">The template id.</param>
		/// <param name="document">The document to delete.</param>
		public void DeleteDocument (PackageId templateId, Document document)
		{
			DeleteDocument(templateId, document.Id);
		}

		public void DeleteDocument (PackageId templateId, string documentId)
		{
			packageService.DeleteDocument(templateId, documentId);
		}

		public void UpdateDocumentMetadata(DocumentPackage template, Document document)
		{
			packageService.UpdateDocumentMetadata(template, document);
		}

        public Placeholder AddPlaceholder(PackageId templateId, Placeholder placeholder)
        {
            return apiClient.AddPlaceholder(templateId, placeholder);
        }

        public Placeholder UpdatePlaceholder(PackageId templateId, Placeholder placeholder)
        {
            return apiClient.UpdatePlaceholder(templateId, placeholder);
        }
    }
}