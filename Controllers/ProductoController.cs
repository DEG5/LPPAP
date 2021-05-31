using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Business;
using Test.Data.Entities;

namespace Test.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            ProductoBusiness productoBusiness = new ProductoBusiness();
            var lista = productoBusiness.Listar();
            return View(lista);
        }

        //CREATE

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Producto model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                var productoBusiness = new ProductoBusiness();
                productoBusiness.Agregar(model);
                return RedirectToAction("Index");
            }
            catch(Exception)
            {
                return View(model);
            }
        }

        //EDIT

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var productoBusiness = new ProductoBusiness();
            var producto = productoBusiness.Get(id);
            if(producto == null)
            {
                return View();
            }
            return View(producto);
        }

        [HttpPost]
        public ActionResult Edit(Producto model)
        {
            if(!ModelState.IsValid || model == null)
            {
                return View();
            }
            var productoBusiness = new ProductoBusiness();
            productoBusiness.Update(model);
            return RedirectToAction("Index");
        }

        //DETAILS

        [HttpGet]
        public ActionResult Details(int id)
        {
            var productoBusiness = new ProductoBusiness();
            var producto = productoBusiness.Get(id);
            if(producto == null)
            {
                return View();
            }
            return View(producto);
        }

        //DELETE

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var productoBusiness = new ProductoBusiness();
            var producto = productoBusiness.Get(id);
            return View(producto);
        }

        [HttpPost]
        public ActionResult Delete(Producto model)
        {
            var productoBusiness = new ProductoBusiness();
            productoBusiness.Eliminar(model);
            return RedirectToAction("Index");
        }
    }
}