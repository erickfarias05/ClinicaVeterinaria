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
    public class ConsultasController : Controller
    {
        private ConsultaServico consultasServico = new ConsultaServico();

        private ActionResult ObterVisaoConsultaPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Consulta consulta = consultasServico.ObterConsultaPorId((long)id);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            return View(consulta);
        }

        private ActionResult GravarConsulta(Consulta consulta)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    consultasServico.GravarConsulta(consulta);
                    return RedirectToAction("Index");
                }
                return View(consulta);
            }
            catch
            {
                return View(consulta);
            }
        }

        // GET: Consultas
        public ActionResult Index()
        {
            return View(consultasServico.ObterConsultasClassificadosPorData());
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Consulta consulta)
        {
            return GravarConsulta(consulta);
        }

        // GET: Edit
        public ActionResult Edit(long? id)
        {
            return ObterVisaoConsultaPorId(id);
        }
        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Consulta consulta)
        {
            return GravarConsulta(consulta);
        }

        // GET: Details
        public ActionResult Details(long? id)
        {
            return ObterVisaoConsultaPorId(id);
        }

        // GET: Delete
        public ActionResult Delete(long? id)
        {
            return ObterVisaoConsultaPorId(id);
        }
        // POST: Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Consulta consulta = consultasServico.EliminarConsultaPorId(id);
                TempData["Message"] = "Consulta foi removido";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}