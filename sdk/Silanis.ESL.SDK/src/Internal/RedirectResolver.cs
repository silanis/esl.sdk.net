using System;
using System.Net;

namespace Silanis.ESL.SDK
{
    public class RedirectResolver
    {
        public static string ResolveUrlAfterRedirect(string url)
        {
            try 
            {
                var request = (HttpWebRequest)WebRequest.Create (url);

                request.AllowAutoRedirect = false;
                var response = (HttpWebResponse)request.GetResponse();
                var locationHeader = response.Headers["Location"];
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

