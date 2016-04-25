using System;
using System.Net;
using System.Web;

namespace Silanis.ESL.SDK
{
    public class RedirectResolver
    {
        public static string ResolveUrlAfterRedirect(string url)
        {
            try 
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create (url);

                request.AllowAutoRedirect = false;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string locationHeader = response.Headers["Location"];
                return locationHeader;
            } 
            catch (WebException e) 
            {
                return url;
            } 
            catch (Exception e) 
            {
                return url;
            }

        }
    }
}

