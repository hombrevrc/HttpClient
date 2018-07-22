using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace HttpClient
{
   class HttpClient
   {
      private HttpWebRequest request = null;
      private HttpWebResponse response = null;
      private String host;

      public HttpClient(String HostURL, CookieContainer Cookies = null, String Method = "GET", String PostBody = "")
      {
         host = new Uri(HostURL).Host;
         request = WebRequest.Create(HostURL) as HttpWebRequest;
         request.Method = Method;
         request.ContentType = "application/x-www-form-urlencoded";
         request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.99 Safari/537.36";
         request.Accept = "*/*";
         request.CookieContainer = Cookies;

         //request.Connection = "keep-alive";

         if (Method.Equals("POST") == true)
         {
            using (StreamWriter stream = new StreamWriter(request.GetRequestStream()))
            {
               stream.Write(PostBody);
               stream.Close();
            }
         }
         response = request.GetResponse() as HttpWebResponse;
      }

      ~HttpClient()
      {
         response.Close();
      }

      internal String GetWebContent()
      {
         Stream dataStream = response.GetResponseStream();

         StreamReader streamReader = new StreamReader(dataStream);
         string strContent = streamReader.ReadToEnd();
         streamReader.Close();
         dataStream.Close();

         return strContent;
      }

      internal int GetResponseCode()
      {
         return (int)response.StatusCode;
      }
   }
}
