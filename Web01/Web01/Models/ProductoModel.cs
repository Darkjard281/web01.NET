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

        public long RegistrarProducto(ProductoEnt productoEnt) {

            using (var client = new HttpClient())
            {
                string url = UrlApi + "RegistrarProducto";
                JsonContent contenido = JsonContent.Create(productoEnt);//Conversion del objeto en JSON
                var resp = client.PostAsync(url, contenido).Result;
                return resp.Content.ReadFromJsonAsync<long>().Result;
            }
        }

        public string ActualizarRutaImagen(ProductoEnt productoEnt) {
            using (var client = new HttpClient())
            {
                string url = UrlApi + "ActualizarRutaImagen";
                JsonContent contenido = JsonContent.Create(productoEnt);
                var resp = client.PutAsync(url, contenido).Result;
                return resp.Content.ReadFromJsonAsync<string>().Result;
            }

        }

        public ProductoEnt ConsultaProducto(long q)
        {
            using (var client = new HttpClient())
            {


                string url = UrlApi + "ConsultaProducto?ConProducto=" + q;
                var resp = client.GetAsync(url).Result;
                return resp.Content.ReadFromJsonAsync<ProductoEnt>().Result;
            }

        }


        public string ActualizarProducto(ProductoEnt productoEnt) {

            using (var client = new HttpClient()) {
                string url = UrlApi + "ActualizarProducto";
                JsonContent contenido = JsonContent.Create(productoEnt);
                var resp = client.PutAsync(url, contenido).Result;
                return resp.Content.ReadFromJsonAsync<string>().Result;
            }
                
        }

    }
}