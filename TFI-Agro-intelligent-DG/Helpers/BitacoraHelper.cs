using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace TFI_Agro_intelligent_DG.Helpers
{
    public class BitacoraHelper
    {
        public static async void GrabarEvento(string detalle,string userId) {
        
            //string URI = "https://localhost:44325/api/Seguridad";
            //string myParameters =  string.Format("?detalle={0}&userId={1}",detalle,userId);

            //using (WebClient wc = new WebClient())
            //{
            //    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            //    string HtmlResult = wc.UploadString(URI, myParameters);
            //}
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44325");
                var content = new FormUrlEncodedContent(new[]
                {
                new KeyValuePair<string, string>("detalle", detalle),
                new KeyValuePair<string, string>("userId", userId)
            });
                
                var result = await client.PostAsync("/api/seguridad", content);
                string resultContent = await result.Content.ReadAsStringAsync();
                Console.WriteLine(resultContent);
            }
        }
    }
}