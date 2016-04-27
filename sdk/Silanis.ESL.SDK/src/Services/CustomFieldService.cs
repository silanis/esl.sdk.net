using Silanis.ESL.SDK.Builder;
using System.Collections.Generic;

namespace Silanis.ESL.SDK.Services
{
	public class CustomFieldService
	{
        private readonly CustomFieldApiClient _apiClient;
        
        internal CustomFieldService(CustomFieldApiClient apiClient)
        {
            _apiClient = apiClient;
        }
        
		///
		/// Create an account custom field.
		/// If the custom field already existed then update it.
		///
		/// @param customField
		/// @return the custom field added created or updated
		/// @throws com.silanis.esl.sdk.EslException
		///
		public CustomField CreateCustomField(CustomField customField)
		{
            var apiCustomField = new CustomFieldConverter( customField ).ToAPICustomField();
            apiCustomField = _apiClient.CreateCustomField( apiCustomField );
            return new CustomFieldConverter(apiCustomField).ToSDKCustomField();
		}

		///
		/// Determine if a custom field already existed
		///
		/// @param id of custom field
		/// @return true if existed otherwise false
		///
		public bool DoesCustomFieldExist(string customFieldId)
		{
            return _apiClient.DoesCustomFieldExist(customFieldId);
		}

        /// <summary>
        /// Get an account custom field.
        /// </summary>
        /// <returns>The account custom field.</returns>
        /// <param name="id">Id of custom field to get.</param>
        public CustomField GetCustomField(string id)
        {
            var apiCustomField = _apiClient.GetCustomField(id);
            return new CustomFieldConverter(apiCustomField).ToSDKCustomField();
        }

        /// <summary>
        /// Get the entire list of account custom fields.
        /// </summary>
        /// <returns>The list of custom fields.</returns>
        /// <param name="direction">Direction of retrieved list to be sorted in ascending or descending order by id</param>
        public IList<CustomField> GetCustomFields(Direction direction)
        {
            return GetCustomFields(direction, new PageRequest(-1, 0));
        }

        /// <summary>
        /// Get the list of account custom fields.
        /// </summary>
        /// 
        /// <returns>The list of custom fields</returns>
        /// <param name="direction">Direction of retrieved list to be sorted in ascending or descending order by id</param>
        /// <param name="request">Identifying which page of results to return.</param>
        public IList<CustomField> GetCustomFields(Direction direction, PageRequest request)
        {
            var apiCustomFieldList = _apiClient.GetCustomFields(direction, request);

            IList<CustomField> result = new List<CustomField>();
            foreach (var apiCustomField in apiCustomFieldList)
            {
                result.Add(new CustomFieldConverter(apiCustomField).ToSDKCustomField());
            }

            return result;
        }

		/// <summary>
		/// Delete an account custom field.
		/// </summary>
		/// <param name="id">id of custom field to delete.</param>
		public void DeleteCustomField(string id)
		{
            _apiClient.DeleteCustomField(id);
		}

        ///
        /// Get all custom fields for the user.
        ///
        /// @return user custom field list
        /// 
        public IList<CustomFieldValue> GetCustomFieldValues() 
        {
            var userCustomFields = _apiClient.GetUserCustomFields();

            IList<CustomFieldValue> customFieldValues = new List<CustomFieldValue>();
            foreach (var userCustomField in userCustomFields) 
            {
                customFieldValues.Add(new CustomFieldValueConverter(userCustomField).ToSDKCustomFieldValue());
            }

            return customFieldValues;
        }

        ///
        /// Get a custom field for the user.
        ///
        /// @return user custom field
        /// 
        public CustomFieldValue GetCustomFieldValue(string customFieldId) 
        {
            var userCustomField = _apiClient.GetUserCustomField(customFieldId);
            return new CustomFieldValueConverter(userCustomField).ToSDKCustomFieldValue();
        }

		///
		/// Create an user custom field.
		/// If the custom field already existed then update it.
		///
		///
		/// @param customFieldValue
		/// @return user custom field id
		/// @throws com.silanis.esl.sdk.EslException
		///
		public CustomFieldValue SubmitCustomFieldValue(CustomFieldValue customFieldValue)
        {   
            var apiCustomFieldValue = new CustomFieldValueConverter(customFieldValue).ToAPIUserCustomField();
            apiCustomFieldValue = _apiClient.SubmitCustomFieldValue(apiCustomFieldValue);
            return CustomFieldValueBuilder.CustomFieldValue(apiCustomFieldValue).build();
        }

        ///
        /// Delete an user custom field.
        ///
        /// @param id of user custom field to delete.
        ///
        public void DeleteCustomFieldValue(string id) {
            _apiClient.DeleteUserCustomField(id);
        }

		///
		/// Determine if an user custom field already existed
		///
		/// @param id of user custom field
		/// @return true if existed otherwise false
		///
		public bool DoesCustomFieldValueExist(string customFieldId)
		{
            return _apiClient.DoesCustomFieldValueExist( customFieldId );
		}
	}
}

