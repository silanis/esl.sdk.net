using System;
using System.Globalization;
using Newtonsoft.Json;
using Silanis.ESL.SDK.Internal;
using Silanis.ESL.API;
using System.Collections.Generic;

namespace Silanis.ESL.SDK
{
    internal class CustomFieldApiClient
    {
        private readonly UrlTemplate _template;
        private readonly RestClient _client;
        private readonly Json _json;

        [Obsolete("Please use EslClient")]
        public CustomFieldApiClient(RestClient client, string baseUrl, JsonSerializerSettings jsonSerializerSettings)
        {
            _json = new Json(jsonSerializerSettings);
            _template = new UrlTemplate(baseUrl);
            _client = client;
        }
        internal CustomFieldApiClient(RestClient client, string baseUrl)
        {
            _json = new Json();
            _template = new UrlTemplate(baseUrl);
            _client = client;
        }

        public bool DoesCustomFieldExist(string id)
        {
            var path = _template.UrlFor(UrlTemplate.ACCOUNT_CUSTOMFIELD_ID_PATH)
                .Replace("{customFieldId}", id)
                .Build();
    
            try
            {
                var stringResponse = _client.Get(path);
                if (string.IsNullOrEmpty(stringResponse))
                {
                    return false;
                }
                _json.Deserialize<CustomFieldValue>(stringResponse);
                return true;
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not get the custom field from account." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not get the custom field from account." + " Exception: " + e.Message, e);
            }
        }

        public bool DoesCustomFieldValueExist(string id)
        {
            var path = _template.UrlFor(UrlTemplate.USER_CUSTOMFIELD_ID_PATH)
                .Replace("{customFieldId}", id)
                .Build();
    
            try
            {
                var stringResponse = _client.Get(path);
                if (String.IsNullOrEmpty(stringResponse))
                {
                    return false;
                }
                _json.Deserialize<UserCustomField>(stringResponse);
                return true;
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not get the custom field from user." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not get the custom field from user." + " Exception: " + e.Message, e);
            }
        }
        
        public API.CustomField CreateCustomField( API.CustomField apiField )
        {
            var path = _template.UrlFor(UrlTemplate.ACCOUNT_CUSTOMFIELD_PATH).Build();
    
            try
            {
                string stringResponse;
                if (DoesCustomFieldExist(apiField.Id))
                {
                    stringResponse = _client.Put(path, _json.SerializeWithSettings(apiField));
                }
                else
                {
                    stringResponse = _client.Post(path, _json.SerializeWithSettings(apiField));
                }
                
                return _json.Deserialize<API.CustomField>(stringResponse);
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not add/update the custom field to account." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not add/update the custom field to account." + " Exception: " + e.Message, e);
            }
        }

        public API.CustomField GetCustomField(string id)
        {
            var path = _template.UrlFor(UrlTemplate.ACCOUNT_CUSTOMFIELD_ID_PATH)
                .Replace("{customFieldId}", id)
                .Build();

            try 
            {
                var response = _client.Get(path);
                return _json.Deserialize<API.CustomField>(response);
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not get the custom field from account." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not get the custom field from account." + " Exception: " + e.Message, e);
            }
        }

        public IList<API.CustomField> GetCustomFields(Direction direction, PageRequest request)
        {
            var path = _template.UrlFor(UrlTemplate.ACCOUNT_CUSTOMFIELD_LIST_PATH)
                .Replace("{dir}", DirectionUtility.getDirection(direction))
                .Replace("{from}", request.From.ToString(CultureInfo.InvariantCulture))
                .Replace("{to}", request.To.ToString(CultureInfo.InvariantCulture))
                .Build();

            try 
            {
                var response = _client.Get(path);
                return _json.DeserializeWithSettings<IList<API.CustomField>> (response);
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not get the list of custom fields from account." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not get the list of custom fields from account." + " Exception: " + e.Message, e);
            }
        }

        public void DeleteCustomField( string id )
        {
            var path = _template.UrlFor(UrlTemplate.ACCOUNT_CUSTOMFIELD_ID_PATH)
                .Replace("{customFieldId}", id)
                .Build();

            try
            {
                _client.Delete(path);
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not delete the custom field from account." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not delete the custom field from account." + " Exception: " + e.Message, e);
            }
        }

        public IList<UserCustomField> GetUserCustomFields()
        {
            var path = _template.UrlFor(UrlTemplate.USER_CUSTOMFIELD_PATH).Build();
            string response;

            try 
            {
                response = _client.Get(path);
                return _json.DeserializeWithSettings<IList<UserCustomField>> (response);
            } 
            catch (EslServerException e)
            {
                throw new EslServerException("Could not get the custom fields for the user." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not get the custom fields for the user." + " Exception: " + e.Message, e);
            }
        }

        public UserCustomField GetUserCustomField(string customFieldId)
        {
            var path = _template.UrlFor(UrlTemplate.USER_CUSTOMFIELD_ID_PATH)
                .Replace("{customFieldId}", customFieldId)
                .Build();

            string response;
            try 
            {
                response = _client.Get(path);
                return _json.DeserializeWithSettings<UserCustomField> (response);
            } 
            catch (EslServerException e)
            {
                throw new EslServerException("Could not get the custom field for the user." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not get the custom field for the user." + " Exception: " + e.Message, e);
            }
        }
        
        public UserCustomField SubmitCustomFieldValue(UserCustomField apiCustomFieldValue)
        {
            var path = _template.UrlFor(UrlTemplate.USER_CUSTOMFIELD_PATH).Build();
            string response;
    
            try
            {
                var payload = _json.SerializeWithSettings(apiCustomFieldValue);
                if (DoesCustomFieldValueExist(apiCustomFieldValue.Id))
                {
                    response = _client.Put(path, payload);
                }
                else
                {
                    response = _client.Post(path, payload);
                }
                return _json.Deserialize<UserCustomField>(response);
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not add/update the custom field to account." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not add/update the custom field to account." + " Exception: " + e.Message, e);
            }
        }

        public void DeleteUserCustomField(string id) 
        {
            var path = _template.UrlFor(UrlTemplate.USER_CUSTOMFIELD_ID_PATH)
                    .Replace("{customFieldId}", id)
                    .Build();
            try 
            {
                _client.Delete(path);
            } 
            catch (EslServerException e)
            {
                throw new EslServerException("Could not delete the custom field from user." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not delete the custom field from user." + " Exception: " + e.Message, e);
            }
        }

    }
}

