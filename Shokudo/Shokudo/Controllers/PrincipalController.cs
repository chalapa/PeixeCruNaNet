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
            DataContextDataContext db = new DataContextDataContext();
            var cli = new Client
            {
                Name = "Felipe",
                Phone = 41352118,
                Adress = "Estrada de São Francisco",
                Cell = 83170899
            };

            db.Clients.InsertOnSubmit(cli);
            db.SubmitChanges();

            return View();
        }

    }
}
