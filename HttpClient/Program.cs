using System;
using System.Net;

namespace HttpClient
{
    class Program
    {
        static void Main(string[] args)
        {
         CookieContainer SessionInfo = new CookieContainer();

         HttpClient MainPage = new HttpClient("https://www.facebook.com", SessionInfo);
         MainPage.GetWebContent();

         HttpClient Login = new HttpClient("https://www.facebook.com/login.php?login_attempt=1&lwv=110", SessionInfo, "POST",
            "Login info");
         Login.GetWebContent();
         

      }
    }
}
