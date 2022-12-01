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
    public class UsuariosController : Controller
    {
        private UsuarioServico usuariosServico = new UsuarioServico();

        private ActionResult ObterVisaoUsuarioPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Usuario usuario = usuariosServico.ObterUsuarioPorId((long)id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }
        private ActionResult GravarUsuario(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    usuariosServico.GravarUsuario(usuario);
                    return RedirectToAction("Index");
                }
                return View(usuario);
            }
            catch
            {
                return View(usuario);
            }
        }

        // GET: Usuarios
        public ActionResult Index()
        {
            return View(usuariosServico.ObterUsuariosClassificadosPorNome());
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario)
        {
            return GravarUsuario(usuario);
        }

        // GET: Edit
        public ActionResult Edit(long? id)
        {
            return ObterVisaoUsuarioPorId(id);
        }
        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Usuario usuario)
        {
            return GravarUsuario(usuario);
        }
        // GET: Details
        public ActionResult Details(long? id)
        {
            return ObterVisaoUsuarioPorId(id);
        }
        // GET: Delete
        public ActionResult Delete(long? id)
        {
            return ObterVisaoUsuarioPorId(id);
        }
        // POST: Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Usuario usuario = usuariosServico.EliminarUsuarioPorId(id);
                TempData["Message"] = "Usuario " + usuario.Nome.ToUpper() + " foi removido";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}