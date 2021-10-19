
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using MvcGestaoLivros.Models;
using MvcGestaoLivros.Models.Data;
using projecto2.Controllers;

namespace MvcGestaoLivros.Controllers
{
    public class UtentesController : Controller
    {
        private dbEntities db = new dbEntities();
        // GET: Utentes
        public ActionResult Index()
        {

      
             if (Session["id_utente"] == null)
             {
                 IEnumerable<UtentesModel> livros;
                 HttpResponseMessage responseMessage = GlobalVariavel.web.GetAsync("Utentes").Result;
                 livros = responseMessage.Content.ReadAsAsync<IEnumerable<UtentesModel>>().Result;
                return View(livros);
             }
          

             return RedirectToAction("Details", new { id = (int)Session["id_utente"] });
        }

        // GET: Utentes/Details/5
        public ActionResult Details(int id)
        {

            HttpResponseMessage response = GlobalVariavel.web.GetAsync("utentes/" + id.ToString()).Result;
            UtentesModel utente = response.Content.ReadAsAsync<UtentesModel>().Result;

            //db.logins.Find()
            login user = db.logins.Find(id);


            UtenteViewModel utenteView = new UtenteViewModel();

            utenteView.id_login = user.id_login;
            utenteView.username = user.username;
            utenteView.email = user.email;
            utenteView.password = user.password;
            utenteView.flagAtiva = user.flagAtiva;
            utenteView.privilegio =(bool) user.privilegio;
            //--------------
            utenteView.id_utente = utente.id_utente;
            utenteView.nome_utente = utente.nome_utente;
            utenteView.num_tlm_utente = utente.num_tlm_utente;
            utenteView.dta_nascim_utente = utente.dta_nascim_utente;
            utenteView.endereco_utente = utente.endereco_utente;


/*< p >
    @Html.ActionLink("Editar", "Edit", new { id = Model.id_utente }) |
    @Html.ActionLink("Voltar á Lista", "Index")
</ p >*/
            return View(utenteView);
        }

        // GET: Utentes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Utentes/Create
        [HttpPost]
        public ActionResult Create(UtentesModel collection)
        {
            try
            {                 // TODO: Add insert logic here
            //https://www.youtube.com/watch?v=iublAXAm8HQ&list=TLPQMjcwMTIwMjEHLY9UXde8lA&index=8&ab_channel=CodAffection
                if (collection.id_utente == 0)
                {
                    collection.id_login = (int)Session["id_login"];
                    HttpResponseMessage httpResponse = GlobalVariavel.web.PostAsJsonAsync("utentes", collection).Result;
                  

                    int currentUtente = Uteis.ConvertStringToInt(httpResponse.Content.ReadAsStringAsync().Result);

                    TempData["SuccessMessage"] = "Criado com sucesso \n ID: " + currentUtente;
                    Session["id_utente"] = currentUtente;
                    Session["nome_user"] = collection.nome_utente;

                    //------
                    return RedirectToAction("Index");
                }
            
            }
            catch
            {
                ViewBag.Notification = "Não foi possivel guardar";
                return View();
            }
          
            return RedirectToAction("Index");

        }

    
        // GET: Utentes/Edit/5
        public ActionResult Edit(int id)
        {
            HttpResponseMessage responseMessage = GlobalVariavel.web.GetAsync("utentes/" + id.ToString()).Result;
            return View(responseMessage.Content.ReadAsAsync<UtentesModel>().Result);
            //return View();
        }

        // POST: Utentes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UtentesModel collection)
        {
            try
            {
                if(id != 0)
                {
                    // TODO: Add update logic here
                    HttpResponseMessage httpResponse = GlobalVariavel.web.PutAsJsonAsync("Utentes/" + collection.id_utente, collection).Result;
                    TempData["SuccessMessage"] = "Atualizado com sucesso";
                    return RedirectToAction("Index");
                }
      

            }
            catch
            {
                return View();
            }

            ViewBag.Notification = "Não foi possivel guardar";
            return RedirectToAction("Index");

        }

        // GET: Utentes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Utentes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
