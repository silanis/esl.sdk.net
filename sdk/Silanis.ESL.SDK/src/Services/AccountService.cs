using System;
using Silanis.ESL.SDK.Internal;
using Newtonsoft.Json;
using Silanis.ESL.API;
using System.Collections.Generic;
using System.Collections;

namespace Silanis.ESL.SDK.Services
{
    public class AccountService
    {
        private AccountApiClient apiClient;

        internal AccountService(AccountApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public Sender InviteUser(AccountMember invitee)
        {
            var apiSender = new AccountMemberConverter( invitee ).ToAPISender();
            var apiResponse = apiClient.InviteUser( apiSender );
            var result = new SenderConverter( apiResponse ).ToSDKSender();
            return result;
        }

        public void SendInvite(string senderId)
        {
            apiClient.SendInvite(senderId);
        }

        public IDictionary<string, Silanis.ESL.SDK.Sender> GetSenders(Direction direction, PageRequest request)
        {
            var apiResponse = apiClient.GetSenders(direction, request);
            
            IDictionary<string, Silanis.ESL.SDK.Sender> result = new Dictionary<string, Silanis.ESL.SDK.Sender>();
            foreach ( var apiSender in apiResponse.Results ) {
                result.Add(apiSender.Email, new SenderConverter( apiSender ).ToSDKSender() );
            }
            
            return result;
        }

        public Silanis.ESL.SDK.Sender GetSender(string senderId)
        {
            var apiResponse = apiClient.GetSender(senderId);
            var result = new SenderConverter(apiResponse).ToSDKSender();
            return result;
        }

        public void DeleteSender(string senderId)
        {
            apiClient.DeleteSender( senderId );
        }

        public void UpdateSender(SenderInfo senderInfo, string senderId)
        {
            var apiSender = new SenderConverter(senderInfo).ToAPISender();
            apiSender.Id = senderId;
            apiClient.UpdateSender(apiSender, senderId);
        }

        public IDictionary<string, Silanis.ESL.SDK.Sender> GetContacts() 
        {
            var contacts = apiClient.GetContacts();

            IDictionary<string, Silanis.ESL.SDK.Sender> result = new Dictionary<string, Silanis.ESL.SDK.Sender>();
            foreach (var apiSender in contacts)
            {
                result[apiSender.Email] = new SenderConverter(apiSender).ToSDKSender();
            }

            return result;
        }

        public IList<Silanis.ESL.SDK.DelegationUser> GetDelegates(string senderId) 
        {
            IList<Silanis.ESL.SDK.DelegationUser> result = new List<Silanis.ESL.SDK.DelegationUser>();
            var apiDelegationUsers = apiClient.GetDelegates(senderId);
            foreach (var delegationUser in apiDelegationUsers) 
            {
                result.Add(new DelegationUserConverter(delegationUser).ToSDKDelegationUser());
            }
            return result;
        }

        public void UpdateDelegates(string senderId, List<string> delegateIds) 
        {
            apiClient.UpdateDelegates(senderId, delegateIds);
        }

        public void AddDelegate(string senderId, Silanis.ESL.SDK.DelegationUser delegationUser) 
        {
            var apiDelegationUser = new DelegationUserConverter(delegationUser).ToAPIDelegationUser();
            apiClient.AddDelegate(senderId, apiDelegationUser);
        }

        public void RemoveDelegate(string senderId, string delegateId) 
        {
            apiClient.RemoveDelegate(senderId, delegateId);
        }

        public void ClearDelegates(string senderId) 
        {
            apiClient.ClearDelegates(senderId);
        }
    }
}

