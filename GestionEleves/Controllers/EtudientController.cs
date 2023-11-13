using GestionEleves.data;
using GestionEleves.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace GestionEleves.Controllers
{
    public class EtudientController : Controller
    {
        private readonly AppDbContext _dbContext;
        public EtudientController(AppDbContext db)
        {
            _dbContext = db;
        }
        // GET: EtudientController
        public ActionResult Index()
        {
            ICollection<Etudient> etudients = _dbContext.Etudients.Include(e => e.Etablissement).ToList();
            return View(etudients);
        }

        // GET: EtudientController/Details/5
        public ActionResult Details(int id)
        {
            Etudient? etudient = _dbContext.Etudients.Include(e => e.Etablissement).FirstOrDefault(s => s.EtudientID == id);
            return View(etudient);
        }

        // GET: EtudientController/Create
        public ActionResult Create()
        {
            Etudient etudient = new Etudient();
            ICollection<Etablissement>? etablissements = _dbContext.Etablissements.ToList();
            ViewBag.Etablissements = new SelectList(etablissements, "EtablissementId", "EtablissementName");
            return View(etudient);
        }

        // POST: EtudientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Etudient etudient)
        {
            try
            {
                _dbContext.Etudients.Add(etudient);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EtudientController/Edit/5
        public ActionResult Edit(int id)
        {
            Etudient? etudient = _dbContext.Etudients.Find(id);
            Debug.WriteLine(etudient?.EtablissementId);
            ICollection<Etablissement>? etablissements = _dbContext.Etablissements.ToList();
            ViewBag.Etablissements = new SelectList(etablissements, "EtablissementId", "EtablissementName");
            return View(etudient);
        }

        // POST: EtudientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Etudient etudient)
        {
            try
            {
                _dbContext.Etudients.Update(etudient);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EtudientController/Delete/5
        public ActionResult Delete(int id)
        {
            Etudient? etudient = _dbContext.Etudients.Find(id);
            return View(etudient);
        }

        // POST: EtudientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Etudient etudient)
        {
            try
            {
                _dbContext.Etudients.Remove(etudient);
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
