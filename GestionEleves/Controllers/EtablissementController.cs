using GestionEleves.data;
using GestionEleves.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionEleves.Controllers
{
    public class EtablissementController : Controller
    {
        private readonly AppDbContext _dbContext;
        public EtablissementController(AppDbContext db)
        {
            _dbContext = db;
        }
        // GET: EtablissementController
        public ActionResult Index()
        {
            var list = _dbContext.Etablissements.ToList();
            return View(list);
        }

        // GET: EtablissementController/Details/5
        public ActionResult Details(int id)
        {
            Etablissement? etablissement = _dbContext.Etablissements.Find(id);
            return View(etablissement);
        }

        // GET: EtablissementController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EtablissementController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Etablissement etablissement)
        {
            try
            {
                _dbContext.Etablissements.Add(etablissement);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EtablissementController/Edit/5
        public ActionResult Edit(int id)
        {
            Etablissement? etablissement = _dbContext.Etablissements.Find(id);
            return View(etablissement);
        }

        // POST: EtablissementController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Etablissement etablissement)
        {
            try
            {
                _dbContext.Update(etablissement);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EtablissementController/Delete/5
        public ActionResult Delete(int id)
        {
            Etablissement? etablissement = _dbContext.Etablissements.Find(id);
            return View(etablissement);
        }

        // POST: EtablissementController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Etablissement etablissement)
        {
            try
            {
                _dbContext.Etablissements.Remove(etablissement);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
