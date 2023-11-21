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
                string extension = Path.GetExtension(Path.GetFileName(ImgProducto.FileName)); //quitar el tipo de extension del file agregado (.png)
                string ruta = AppDomain.CurrentDomain.BaseDirectory + "Images\\" + ConProducto + extension; // Crear ruta
                ImgProducto.SaveAs(ruta); // Salvar imagen en la ruta


                productoEnt.Imagen = "/Images/" + ConProducto + extension; // guardar ruta en el objeto
                productoEnt.ConProducto = ConProducto; // guardar el id
                productModel.ActualizarRutaImagen(productoEnt);  // actualizar la imagen en el objeto

            }
            return RedirectToAction("ConsultarProductos","Producto");
        }

    }
}