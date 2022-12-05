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
    public class VeterinariosController : Controller
    {
        private VeterinarioServico veterinariosServico = new VeterinarioServico();

        private ActionResult ObterVisaoVeterinarioPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Veterinario veterinario = veterinariosServico.ObterVeterinarioPorId((long)id);
            if (veterinario == null)
            {
                return HttpNotFound();
            }
            return View(veterinario);
        }
        private ActionResult GravarVeterinario(Veterinario veterinario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    veterinariosServico.GravarVeterinario(veterinario);
                    return RedirectToAction("Index");
                }
                return View(veterinario);
            }
            catch
            {
                return View(veterinario);
            }
        }

        // GET: Animal
        public ActionResult Index()
        {
            return View(veterinariosServico.ObterVeterinariosClassificadosPorCMV());
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Veterinario veterinario)
        {
            return GravarVeterinario(veterinario);
        }

        // GET: Edit
        public ActionResult Edit(long? id)
        {
            return ObterVisaoVeterinarioPorId(id);
        }
        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Veterinario veterinario)
        {
            return GravarVeterinario(veterinario);
        }

        // GET: Details
        public ActionResult Details(long? id)
        {
            return ObterVisaoVeterinarioPorId(id);
        }

        // GET: Delete
        public ActionResult Delete(long? id)
        {
            return ObterVisaoVeterinarioPorId(id);
        }
        // POST: Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Veterinario veterinario = veterinariosServico.EliminarVeterinarioPorId(id);
                TempData["Message"] = "Veterinario" + veterinario.crmv + " foi removido";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}