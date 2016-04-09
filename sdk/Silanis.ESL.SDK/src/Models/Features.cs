//
using System;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class Features
	{
		
		// Fields
		
		// Accessors
		    
    [JsonProperty("attachments")]
    public Nullable<Boolean> Attachments
    {
                get; set;
        }
    
		    
    [JsonProperty("authenticatedInbox")]
    public Nullable<Boolean> AuthenticatedInbox
    {
                get; set;
        }
    
		    
    [JsonProperty("customFields")]
    public Nullable<Boolean> CustomFields
    {
                get; set;
        }
    
		    
    [JsonProperty("encryptDocuments")]
    public Nullable<Boolean> EncryptDocuments
    {
                get; set;
        }
    
		    
    [JsonProperty("evidenceSummary")]
    public Nullable<Boolean> EvidenceSummary
    {
                get; set;
        }
    
		    
    [JsonProperty("fastTrack")]
    public Nullable<Boolean> FastTrack
    {
                get; set;
        }
    
		    
    [JsonProperty("forceLogin")]
    public Nullable<Boolean> ForceLogin
    {
                get; set;
        }
    
		    
    [JsonProperty("groups")]
    public Nullable<Boolean> Groups
    {
                get; set;
        }
    
		    
    [JsonProperty("inboxFiltering")]
    public Nullable<Boolean> InboxFiltering
    {
                get; set;
        }
    
		    
    [JsonProperty("kBA")]
    public Nullable<Boolean> KBA
    {
                get; set;
        }
    
		    
    [JsonProperty("notarize")]
    public Nullable<Boolean> Notarize
    {
                get; set;
        }
    
		    
    [JsonProperty("showDocumentsPreview")]
    public Nullable<Boolean> ShowDocumentsPreview
    {
                get; set;
        }
    
		    
    [JsonProperty("tamperSealEvidence")]
    public Nullable<Boolean> TamperSealEvidence
    {
                get; set;
        }
    
		
	
	}
}