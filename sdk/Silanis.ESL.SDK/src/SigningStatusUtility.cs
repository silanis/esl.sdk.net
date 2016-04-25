using System;

namespace Silanis.ESL.SDK
{
	internal class SigningStatusUtility
	{
		public static SigningStatus FromString (string status)
		{
			if ("DRAFT".Equals (status))
			{
				return SigningStatus.INACTIVE;
			} 
			else if ("COMPLETED".Equals (status))
			{
				return SigningStatus.COMPLETE;
			} 
			else if ("ARCHIVED".Equals (status))
			{
				return SigningStatus.ARCHIVED;
			} 
			else if ("DECLINED".Equals (status))
			{
				return SigningStatus.DECLINED;
			} 
			else if ("OPTED_OUT".Equals (status))
			{
				return SigningStatus.OPTED_OUT;
			} 
			else if ("EXPIRED".Equals (status))
			{
				return SigningStatus.EXPIRED;
			} 
			else if ("SIGNING_PENDING".Equals (status))
			{
				return SigningStatus.SIGNING_PENDING;
			} 
			else if ("SIGNING_COMPLETED".Equals (status))
			{
				return SigningStatus.SIGNING_COMPLETE;
			} 
            else if ("DELETED".Equals (status))
            {
                return SigningStatus.DELETED;
            } 
			else
			{
				return SigningStatus.INACTIVE;
			}
		}
	}
}