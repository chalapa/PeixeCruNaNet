using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Shokudo;
using Shokudo.Models;


namespace Shokudo.Controllers
{
    public class PrincipalController : Controller
    {
        DataContextDataContext db = new DataContextDataContext();

        public ActionResult Index()
        {
            var list = GetListClient();

            return View(list);
        }

        public ActionResult NovoCliente()
        {
            //var dbContext = new DataContextDataContext();
            //var userList = from user in dbContext.Users select user;

            return View();
        }

        private List<Cliente> GetListClient()
        {
            List<DYF_CLIENT> a = (from x in db.DYF_CLIENTs
                                  select x).ToList();

            List<Cliente> listModel = new List<Cliente>();

            
            foreach (DYF_CLIENT dbClient in a)
            {
                Cliente model = new Cliente();

                model.ClientID = dbClient.ClientId;
                model.Name = dbClient.Name;
                model.ReferencePoint = dbClient.ReferencePoint;
                model.Phone = dbClient.Phone;
                model.Cell = dbClient.Cell;
                model.Address = dbClient.Address;
                model.ClientOK = dbClient.ClientOk;
                model.Complement = dbClient.Complement;
                listModel.Add(model);

            }
            return listModel;
        }

        public ActionResult PesquisarCliente(int searchValue)
        {


                List<DYF_CLIENT> a = (from x in db.DYF_CLIENTs
                                      where x.Phone == searchValue
                                      select x).ToList();

                List<Cliente> listModel = new List<Cliente>();

                foreach (DYF_CLIENT dyfClient in a)
                {
                    Cliente model = new Cliente();

                    model.ClientID = dyfClient.ClientId;
                    model.Name = dyfClient.Name;
                    model.ReferencePoint = dyfClient.ReferencePoint;
                    model.Phone = dyfClient.Phone;
                    model.Cell = dyfClient.Cell;
                    model.Address = dyfClient.Address;
                    model.ClientOK = dyfClient.ClientOk;
                    model.Complement = dyfClient.Complement;

                    listModel.Add(model);
                }
                return View("Index", listModel);

        }

        [HttpPost]
        public ActionResult SalvarCliente(DYF_CLIENT cliente)
        {
            if (cliente.Name == null)
            {
                ModelState.AddModelError("Nome", "Nome Obrigatório");
                return View("NovoCliente");
            }

            {
                DataContextDataContext db = new DataContextDataContext();
                DYF_CLIENT cli = new DYF_CLIENT
                {
                    Name = cliente.Name,
                    Phone = cliente.Phone,
                    Address = cliente.Address,
                    Complement = cliente.Complement,
                    ReferencePoint = cliente.ReferencePoint,
                    ClientOk = cliente.ClientOk,
                    Cell = cliente.Cell
                };

                if (Session["ClientEdit"] != null)
                {
                    int edit = ((int)Session["ClientEdit"]);
                    var result = UpdateClient(edit);
                    return RedirectToAction("Index");
                }
                else
                {
                    db.DYF_CLIENTs.InsertOnSubmit(cli);
                    db.SubmitChanges();
                    return RedirectToAction("Index");
                }
            }
        }

        public bool UpdateClient(int clienteid)
        {
            var result = false;

            var usuarioSel = from us in db.DYF_CLIENTs
                             where us.ClientId == clienteid
                             select us;
            UpdateModel(usuarioSel.SingleOrDefault());
            db.SubmitChanges();

            return result;
        }

        public ActionResult Delete(int id)
        {
            try
            {
                db.DYF_CLIENTs.DeleteOnSubmit(
                    db.DYF_CLIENTs.Where(p => p.ClientId == id).SingleOrDefault());
                db.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
            }

        }

        public ActionResult Edit(int id)
        {
            Session["ClientEdit"] = id;


            DYF_CLIENT clientid = (from x in db.DYF_CLIENTs
                                   where x.ClientId == id
                                   select x).FirstOrDefault();

            Cliente cliente = new Cliente();

            cliente.ClientID = clientid.ClientId;
            cliente.Name = clientid.Name;
            cliente.ReferencePoint = clientid.ReferencePoint;
            cliente.Phone = clientid.Phone;
            cliente.Cell = clientid.Cell;
            cliente.Address = clientid.Address;
            cliente.ClientOK = clientid.ClientOk;
            cliente.Complement = clientid.Complement;


            return View("NovoCliente", cliente);
        }
    }
}
