using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;
using Web01.Entities;

namespace Web01.Models
{
    public class ProductoModel
    {
        string UrlApi = ConfigurationManager.AppSettings["UrlApi"];


        public List<ProductoEnt> ConsultarProductos()
        {
            using (var client = new HttpClient())
            {


                string url = UrlApi + "ConsultarProductos";
                var resp = client.GetAsync(url).Result;
                return resp.Content.ReadFromJsonAsync<List<ProductoEnt>>().Result;
            }

        }

    }
}