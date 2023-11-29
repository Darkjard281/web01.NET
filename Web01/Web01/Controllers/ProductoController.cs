using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web01.Entities;
using Web01.Models;


namespace Web01.Controllers
{
    public class ProductoController : Controller
    {
        
        ProductoModel productModel = new ProductoModel();

        [HttpGet]
        public ActionResult ConsultarProductos()
        {
            var datos = productModel.ConsultarProductos();
            return View(datos);
        }

        [HttpGet]
        public ActionResult RegistrarProducto() {
            return View();
        }

        [HttpPost]
        public ActionResult RegistrarProducto(HttpPostedFileBase ImgProducto, ProductoEnt productoEnt)//ImgProducto recibido de la vista con el name
        {
            productoEnt.Estado = true;
            productoEnt.Imagen = String.Empty;

            long ConProducto = productModel.RegistrarProducto(productoEnt);

            if (ConProducto > 0) {
                string extension = Path.GetExtension(Path.GetFileName(ImgProducto.FileName)); //Extraer el tipo de extension del file agregado (.png)
                string ruta = AppDomain.CurrentDomain.BaseDirectory + "Images\\" + ConProducto + extension; // Crear ruta
                ImgProducto.SaveAs(ruta); // Salvar imagen en la ruta


                productoEnt.Imagen = "/Images/" + ConProducto + extension; // guardar ruta en el objeto
                productoEnt.ConProducto = ConProducto; // guardar el id
                productModel.ActualizarRutaImagen(productoEnt);  // actualizar la imagen en el objeto

            }
            return RedirectToAction("ConsultarProductos","Producto");
        }


        [HttpGet]
        public ActionResult ActualizarProducto(long q)
        {
            var datos = productModel.ConsultaProducto(q);
            return View(datos);

        }

        [HttpPost]
        public ActionResult ActualizarProducto(HttpPostedFileBase ImgProducto,ProductoEnt productoEnt)
        {

            ProductoEnt producto = productModel.ConsultaProducto(productoEnt.ConProducto);


            if (ImgProducto != null) {
                var viejaRuta = AppDomain.CurrentDomain.BaseDirectory + producto.Imagen;
                FileInfo file = new FileInfo(viejaRuta);
                if (file.Exists)
                {
                    file.Delete();
                    
                }

                string extension = Path.GetExtension(Path.GetFileName(ImgProducto.FileName));
                string nombreArchivo = (productoEnt.ConProducto).ToString() + extension;
                string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", nombreArchivo);
                ImgProducto.SaveAs(ruta); // Salvar la nueva imagen

                productoEnt.Imagen = "/Images/" + nombreArchivo;

            }

            var resp = productModel.ActualizarProducto(productoEnt);
            if (resp == "OK")
            {
                return RedirectToAction("ConsultarProductos", "Producto");
            }
            else {
                ViewBag.Mensaje = "No se ha podido efectuar el cambio";
                return View();
            }
            
            
        }

    }
}