using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Web;
using System.Web.Mvc;
using Web01.Entities;

namespace Web01.Models
{
    public class UsuarioModelo
    {

        public UsuarioEnt Login(UsuarioEnt entidad)
        {
            using (var client = new HttpClient()) {//HttpClient sirve para hacer llamadas al protocolo HTTP
                /*
                string url = "https://localhost:44303/Login";
                string miJson = JsonSerializer.Serialize(entidad);
                var payload = new StringContent(miJson, Encoding.UTF8, "application/json");
                var result = client.PostAsync(url, payload).Result;
                return result.Content.ReadFromJsonAsync<UsuarioEnt>().Result;
                */
                string url = "https://localhost:44303/Login";
                JsonContent contenido = JsonContent.Create(entidad);
                var resp = client.PostAsync(url,contenido).Result; 
                return resp.Content.ReadFromJsonAsync<UsuarioEnt>().Result;
                



            }
                
        }

        public string RegistrarCuenta(UsuarioEnt entidad)
        {
            using (var client = new HttpClient())
            {

                string url = "https://localhost:44303/RegistrarCuenta";
                JsonContent contenido = JsonContent.Create(entidad);//Conversion del obkjeto en JSON
                var resp = client.PostAsync(url, contenido).Result; //Recibir por parte de la API el la respuesta
                return resp.Content.ReadFromJsonAsync<string>().Result;
            }
        }

        public string RecuperarCuenta(UsuarioEnt entidad)
        {
            using (var client = new HttpClient())
            {

                string url = "https://localhost:44303/RecuperarCuenta";
                JsonContent contenido = JsonContent.Create(entidad);//Conversion del obkjeto en JSON
                var resp = client.PostAsync(url, contenido).Result; //Recibir por parte de la API el la respuesta
                return resp.Content.ReadFromJsonAsync<string>().Result;
            }

        }
    }
}