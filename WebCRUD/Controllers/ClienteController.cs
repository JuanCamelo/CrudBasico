using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio;

namespace WebCRUD.Controllers
{
    public class ClienteController : Controller
    {
        FachadaNegocio fnego;

        // GET: Cliente
        public ActionResult create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult create(Entidades.clieteDTO objcliet)
        {
            bool valid = false;
            try
            {
                fnego = new FachadaNegocio();
                valid = fnego.creteCliente(objcliet);
                return RedirectToAction("list");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult list()
        {
            List<Entidades.clieteDTO> listas = new List<Entidades.clieteDTO>();
            try
            {
                fnego = new FachadaNegocio();
                listas = fnego.listacliente();
                return PartialView("list",listas);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public ActionResult editar(int id)
        {
            Entidades.clieteDTO Obj = new Entidades.clieteDTO();
            fnego = new FachadaNegocio();
            Obj = fnego.getClieteById(id);
            return View(Obj);
        }

        [HttpPost]
        public ActionResult editar(int id, Entidades.clieteDTO objcliet)
        {
            bool valid = false;
            try
            {
                fnego = new FachadaNegocio();
                valid = fnego.updateCliete(id, objcliet);
                return RedirectToAction("list");
            }
            catch (Exception)
            {

                throw;
            }
        }




    }
}