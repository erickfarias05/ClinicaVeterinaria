using Modelo.Cadastros;
using Servico.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ClinicaVet.Controllers
{
    public class ClientesController : Controller 
    {
        private ClienteServico clientesServico = new ClienteServico();


        private ActionResult ObterVisaoClientePorId(long? id)
     {
        if (id == null)
        {
            return new HttpStatusCodeResult(
            HttpStatusCode.BadRequest);
        }
        Cliente cliente = clientesServico.ObterClientePorId((long)id);
        if (cliente == null)
        {
            return HttpNotFound();
        }
        return View(cliente);
    }

    private ActionResult GravarCliente(Cliente cliente)
    {
        try
        {
            if (ModelState.IsValid)
            {
                clientesServico.GravarCliente(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }
        catch
        {
            return View(cliente);
        }
    }

        // GET: Clientes
        public ActionResult Index()
        {
            return View(clientesServico.ObterClientesClassificadosPorCPF());
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente cliente)
        {
            return GravarCliente(cliente);
        }

        // GET: Edit
        public ActionResult Edit(long? id)
        {
            return ObterVisaoClientePorId(id);
        }
        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cliente cliente)
        {
            return GravarCliente(cliente);
        }

        // GET: Details
        public ActionResult Details(long? id)
        {
            return ObterVisaoClientePorId(id);
        }

        // GET: Delete
        public ActionResult Delete(long? id)
        {
            return ObterVisaoClientePorId(id);
        }
        // POST: Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Cliente cliente = clientesServico.EliminarClientePorId(id);
                TempData["Message"] = "Cliente foi removido";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}