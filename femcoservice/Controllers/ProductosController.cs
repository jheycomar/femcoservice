using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using femcoservice.Models;
using femcoservice.Classe;

namespace femcoservice.Controllers
{
    public class ProductosController : Controller
    {
        private DataContext db ;
        public ProductosController()
        {
            db = new DataContext();
        }
        // GET: Productos
        public ActionResult Index()
        {
            return View(db.Productoes.OrderBy(f=>f.Nombre).ToList());
        }

        // GET: Productos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var producto = db.Productoes.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }

            return View(producto);
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductoView view)
        {
            if (ModelState.IsValid)
            {

                var pic = string.Empty;
                var folder = "~/Content/Images";

                if (view.ImagenFile != null)
                {
                    pic = FilesHelper.UploadPhoto(view.ImagenFile, folder);
                    pic = string.Format("{0}/{1}", folder, pic);
                }
                var producto = ToProducto(view);
                producto.Image = pic;
                db.Productoes.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(view);
        }

        private Producto ToProducto(ProductoView view)
        {
            return new Producto {
                producId=view.producId,
                Image = view.Image,
                Nombre = view.Nombre,
                Price = view.Price,
                UltimaCompra = view.UltimaCompra,
                IsActive = view.IsActive,
                Observacion = view.Observacion, };
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productoes.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(ToView(producto));
        }

        private ProductoView ToView(Producto producto)
        {
            return new ProductoView
            {
                producId = producto.producId,
                Image = producto.Image,
                Nombre = producto.Nombre,
                Price = producto.Price,
                UltimaCompra = producto.UltimaCompra,
                IsActive = producto.IsActive,
                Observacion = producto.Observacion,
            };
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductoView view)
        {
            if (ModelState.IsValid)
            {
                var pic = view.Image;
                var folder = "~/Content/Images";

                if (view.ImagenFile != null)
                {
                    pic = FilesHelper.UploadPhoto(view.ImagenFile, folder);
                    pic = string.Format("{0}/{1}", folder, pic);
                }
                var producto = ToProducto(view);
                producto.Image = pic;

              //  db.Productoes.Add(producto);
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(view);
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productoes.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Producto producto = db.Productoes.Find(id);
            db.Productoes.Remove(producto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
