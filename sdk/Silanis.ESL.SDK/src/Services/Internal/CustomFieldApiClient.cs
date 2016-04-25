using System;
using Silanis.ESL.SDK.Internal;
using Newtonsoft.Json;
using Silanis.ESL.API;
using System.Collections.Generic;

namespace Silanis.ESL.SDK
{
    internal class CustomFieldApiClient
    {
        private UrlTemplate template;
        private RestClient client;
        private JsonSerializerSettings settings;

        public CustomFieldApiClient(RestClient client, string baseUrl, JsonSerializerSettings settings)
        {
            template = new UrlTemplate(baseUrl);
            this.client = client;
            this.settings = settings;
        }

        public bool DoesCustomFieldExist(string id)
        {
            string path = template.UrlFor(UrlTemplate.ACCOUNT_CUSTOMFIELD_ID_PATH)
                .Replace("{customFieldId}", id)
                .Build();
    
            try
            {
                string stringResponse = client.Get(path);
                if (string.IsNullOrEmpty(stringResponse))
                {
                    return false;
                }
                JsonConvert.DeserializeObject<CustomFieldValue>(stringResponse);
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
            string path = template.UrlFor(UrlTemplate.USER_CUSTOMFIELD_ID_PATH)
                .Replace("{customFieldId}", id)
                .Build();
    
            try
            {
                string stringResponse = client.Get(path);
                if (String.IsNullOrEmpty(stringResponse))
                {
                    return false;
                }
                JsonConvert.DeserializeObject<UserCustomField>(stringResponse);
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
        
        public Silanis.ESL.API.CustomField CreateCustomField( Silanis.ESL.API.CustomField apiField )
        {
            string path = template.UrlFor(UrlTemplate.ACCOUNT_CUSTOMFIELD_PATH).Build();
    
            try
            {
                string stringResponse;
                if (DoesCustomFieldExist(apiField.Id))
                {
                    stringResponse = client.Put(path, JsonConvert.SerializeObject(apiField, settings));
                }
                else
                {
                    stringResponse = client.Post(path, JsonConvert.SerializeObject(apiField, settings));
                }
                
                return JsonConvert.DeserializeObject<Silanis.ESL.API.CustomField>(stringResponse);
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

        public Silanis.ESL.API.CustomField GetCustomField(string id)
        {
            string path = template.UrlFor(UrlTemplate.ACCOUNT_CUSTOMFIELD_ID_PATH)
                .Replace("{customFieldId}", id)
                .Build();

            try 
            {
                string response = client.Get(path);
                return JsonConvert.DeserializeObject<Silanis.ESL.API.CustomField>(response);
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

        public IList<Silanis.ESL.API.CustomField> GetCustomFields(Direction direction, PageRequest request)
        {
            string path = template.UrlFor(UrlTemplate.ACCOUNT_CUSTOMFIELD_LIST_PATH)
                .Replace("{dir}", DirectionUtility.getDirection(direction))
                .Replace("{from}", request.From.ToString())
                .Replace("{to}", request.To.ToString())
                .Build();

            try 
            {
                string response = client.Get(path);
                return JsonConvert.DeserializeObject<IList<Silanis.ESL.API.CustomField>> (response, settings);
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
            string path = template.UrlFor(UrlTemplate.ACCOUNT_CUSTOMFIELD_ID_PATH)
                .Replace("{customFieldId}", id)
                .Build();

            try
            {
                client.Delete(path);
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
            string path = template.UrlFor(UrlTemplate.USER_CUSTOMFIELD_PATH).Build();
            string response;

            try 
            {
                response = client.Get(path);
                return JsonConvert.DeserializeObject<IList<Silanis.ESL.API.UserCustomField>> (response, settings);
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
            string path = template.UrlFor(UrlTemplate.USER_CUSTOMFIELD_ID_PATH)
                .Replace("{customFieldId}", customFieldId)
                .Build();

            string response;
            try 
            {
                response = client.Get(path);
                return JsonConvert.DeserializeObject<Silanis.ESL.API.UserCustomField> (response, settings);
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
            string path = template.UrlFor(UrlTemplate.USER_CUSTOMFIELD_PATH).Build();
            string response;
    
            try
            {
                string payload = JsonConvert.SerializeObject(apiCustomFieldValue, settings);
                if (DoesCustomFieldValueExist(apiCustomFieldValue.Id))
                {
                    response = client.Put(path, payload);
                }
                else
                {
                    response = client.Post(path, payload);
                }
                return JsonConvert.DeserializeObject<UserCustomField>(response);
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
            string path = template.UrlFor(UrlTemplate.USER_CUSTOMFIELD_ID_PATH)
                    .Replace("{customFieldId}", id)
                    .Build();
            try 
            {
                client.Delete(path);
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

