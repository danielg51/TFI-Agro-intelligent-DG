using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using TFI_Agro_intelligent_DG.DTO;

namespace TFI_Agro_intelligent_DG.Helpers
{
    public class BitacoraHelper
    {
        public static async void GrabarEvento(string detalle,string userId) {

            using (var client = new HttpClient())
            {
                var bitacora = new Bitacora { UserId = userId, Detalle = detalle };
                HttpContent content = new StringContent(JsonConvert.SerializeObject(bitacora), System.Text.Encoding.UTF8, "application/json");
                var url = "https://localhost:44325/api/Seguridad";
                var postTask = client.PostAsync(url, content);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    //return RedirectToAction("Index");
                }
            }
        }
    }
}