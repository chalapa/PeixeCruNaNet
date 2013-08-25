using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Shokudo;


namespace Shokudo.Controllers
{
    public class PrincipalController : Controller
    {
        //
        // GET: /Principal/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NovoCliente()
        {
            //var dbContext = new DataContextDataContext();
            //var userList = from user in dbContext.Users select user;

            return View();
        }

        [HttpPost]
        public ActionResult SalvarCliente(Client cliente)
        {
            if (cliente.Name == null)
            {
                ModelState.AddModelError("Nome", "Nome Obrigatório");
                return View("NovoCliente");
            }

            {
                DataContextDataContext db = new DataContextDataContext();
                var cli = new Client
                {
                    Name = cliente.Name,
                    Phone = cliente.Phone,
                    Address = cliente.Address,
                    Complement = cliente.Complement,
                    ReferencePoint = cliente.ReferencePoint,
                    Cell = cliente.Cell,
                    ClientOK = cliente.ClientOK
                };


                db.Clients.InsertOnSubmit(cli);
                db.SubmitChanges();
                
            }

            return RedirectToAction("Index");
        }

        //public List<Client> GetClientes()
        //{
        //    List<Client> _pvtList = new List<Client>

        //    return View("");
        //}
    }
}
