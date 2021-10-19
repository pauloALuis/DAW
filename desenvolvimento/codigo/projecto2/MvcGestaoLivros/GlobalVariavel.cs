using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MvcGestaoLivros
{
    public class GlobalVariavel
    {
        public static readonly HttpClient web = new HttpClient();

       // public static HttpClient web = new HttpClient();
        static GlobalVariavel()
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                web.BaseAddress = new Uri("https://localhost:44373/api/");
                web.DefaultRequestHeaders.Clear();
                web.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            }
          catch(HttpRequestException e)
          {
             Console.WriteLine("\nException Caught!");	
             Console.WriteLine("Message :{0} ",e.Message);
          }


}
    }
}