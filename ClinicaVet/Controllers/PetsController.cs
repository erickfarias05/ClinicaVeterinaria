using Modelo.Cadastros;
using Servico.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ClinicaVeterinaria.Controllers
{
    public class PetsController : Controller
    {
        private PetServico petsServico = new PetServico();

        private ActionResult ObterVisaoPetPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Pet pet = petsServico.ObterPetPorId((long)id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            return View(pet);
        }
        private ActionResult GravarPet(Pet pet)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    petsServico.GravarPet(pet);
                    return RedirectToAction("Index");
                }
                return View(pet);
            }
            catch
            {
                return View(pet);
            }
        }

        // GET: Pets
        public ActionResult Index()
        {
            return View(petsServico.ObterPetsClassificadosPorNome());
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pet pet)
        {
            return GravarPet(pet);
        }

        // GET: Edit
        public ActionResult Edit(long? id)
        {
            return ObterVisaoPetPorId(id);
        }
        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Pet pet)
        {
            return GravarPet(pet);
        }
        // GET: Details
        public ActionResult Details(long? id)
        {
            return ObterVisaoPetPorId(id);
        }
        // GET: Delete
        public ActionResult Delete(long? id)
        {
            return ObterVisaoPetPorId(id);
        }
        // POST: Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Pet pet = petsServico.EliminarPetPorId(id);
                TempData["Message"] = "Pet " + pet.Nome.ToUpper() + " foi removido";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}