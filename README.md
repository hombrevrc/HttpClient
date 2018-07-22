# HttpClient
The implementation of Http client based on HttpWebRequest and HttpWebResponse in C#. Cookie supported. 

The client class HttpClient supports GET and POST methods. The user can only set the minimized code in the parameters in the HttpClient constructor. When the constructor returns, the response is ready inside of the HttpClient instance.

Each request from the client side needs a seperate HttpClient instance. If the server supports cookies to save the session details, you can create a CookieContainer instance and pass it into the HttpClient instance every time. HttpClient will take advantage of it and handle the rest work for you. For example, if you want to create a program to get the information of your facebook account, obviously, you need a CookieContainer to save the session info. Just create one and provide it to the HttpClient constructors. The cookies will stay inside of this CookieContainers during its life cycle all the way.

Example:

CookieContainer SessionInfo = new CookieContainer();

HttpClient MainPage = new HttpClient("https://www.facebook.com", SessionInfo);
if (MainPage.GetResponseCode() == 200)
{
  HttpClient Login = new HttpClient("https://www.facebook.com/login.php?login_attempt=1&lwv=110", SessionInfo, "POST",
    "Login info");
  Console.WriteLine(Login.GetWebContent());
}

Be sure that "Login info" is from the correct http request. You can collect the POST body content string from the browser, it contains your credential info and maybe other private info. You can take the Google Chrome as a good example as the following reference:

https://stackoverflow.com/questions/4423061/view-http-headers-in-google-chrome
https://www.mkyong.com/computer-tips/how-to-view-http-headers-in-google-chrome/
