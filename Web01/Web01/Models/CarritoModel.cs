using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Policy;
using System.Web;
using Web01.Entities;

namespace Web01.Models
{
    public class CarritoModel
    {
        public string UrlApi = ConfigurationManager.AppSettings["UrlApi"];


        public string RegistrarCarrito(CarritoEnt entidad) {

            using (var client = new HttpClient()) {

                string url = UrlApi + "RegistrarCarrito";
                JsonContent contenido = JsonContent.Create(entidad);
                var resp = client.PostAsync(url, contenido).Result;
                return resp.Content.ReadFromJsonAsync<string>().Result;


            }
        }

        public List<CarritoEnt> ConsultarCarrito()
        {
            using (var client = new HttpClient())
            {
                string url = UrlApi + "ConsultarCarrito";
                var resp = client.GetAsync(url).Result;
                return resp.Content.ReadFromJsonAsync<List<CarritoEnt>>().Result;
            }

        }

        public string PagarCarrito(CarritoEnt entidad)
        {

            using (var client = new HttpClient())
            {

                string url = UrlApi + "PagarCarrito";
                JsonContent contenido = JsonContent.Create(entidad);
                var resp = client.PostAsync(url, contenido).Result;
                return resp.Content.ReadFromJsonAsync<string>().Result;


            }
        }

    }
}