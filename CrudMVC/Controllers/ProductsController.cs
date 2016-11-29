using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace CrudMVC.Controllers
{
    public class ProductsController : Controller
    {
        private KaizenForceEntities db = new KaizenForceEntities();

        // GET: Kaizen_Productos
        public ActionResult Index()
        {
            return View(db.Kaizen_Productos.ToList());
        }

        // GET: Kaizen_Productos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kaizen_Productos kaizen_Productos = db.Kaizen_Productos.Find(id);
            if (kaizen_Productos == null)
            {
                return HttpNotFound();
            }
            return View(kaizen_Productos);
        }

        // GET: Kaizen_Productos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kaizen_Productos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,marca,precio,stock")] Kaizen_Productos kaizen_Productos)
        {
            if (ModelState.IsValid)
            {
                db.Kaizen_Productos.Add(kaizen_Productos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kaizen_Productos);
        }

        // GET: Kaizen_Productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kaizen_Productos kaizen_Productos = db.Kaizen_Productos.Find(id);
            if (kaizen_Productos == null)
            {
                return HttpNotFound();
            }
            return View(kaizen_Productos);
        }

        // POST: Kaizen_Productos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,marca,precio,stock")] Kaizen_Productos kaizen_Productos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kaizen_Productos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kaizen_Productos);
        }

        // GET: Kaizen_Productos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kaizen_Productos kaizen_Productos = db.Kaizen_Productos.Find(id);
            if (kaizen_Productos == null)
            {
                return HttpNotFound();
            }
            return View(kaizen_Productos);
        }

        // POST: Kaizen_Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kaizen_Productos kaizen_Productos = db.Kaizen_Productos.Find(id);
            db.Kaizen_Productos.Remove(kaizen_Productos);
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
