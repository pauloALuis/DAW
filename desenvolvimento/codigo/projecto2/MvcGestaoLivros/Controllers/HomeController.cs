using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using MvcGestaoLivros.Models;
using MvcGestaoLivros.Models.Data;
using projecto2.Controllers;

namespace MvcGestaoLivros.Controllers
{
    public class HomeController : Controller
    {
       private dbEntities db = new dbEntities();
        public ActionResult Index()
        {
            //https://www.youtube.com/watch?v=EyrKUSwi4uI&t=446s&ab_channel=CodAffection

            if (Session["id_login"] != null )
                return RedirectToAction("Index", "Livros");

            return RedirectToAction("Login" );

        }

        public ActionResult SignUp()
        {

            return View();
        }


        [HttpPost]
        public ActionResult SignUp(login collection)
        {


            try
            {
               // collection.username = collection.email;
                collection.privilegio = (bool)collection.privilegio;

                if (db.logins.Any(x => x.username == collection.username || x.email == collection.email))
                {
                    ViewBag.Notification = "Username/email já existe";
                    return View();
                }
                else
                {
                    

                    if ((bool)collection.privilegio)
                    {//para criar Utente
                  
                        collection.flagAtiva = false;
                        db.logins.Add(collection);
                        db.SaveChanges();
                        saveSession(collection.id_login, collection.username.ToString(), (bool)collection.privilegio);

                        return RedirectToAction("Create", "Utentes");

                    }
                    else
                    {
                        //para criar funcionario
                        collection.flagAtiva = true;
                        db.logins.Add(collection);
                        db.SaveChanges();
                        saveSession(collection.id_login, collection.username.ToString()
                          , (bool)collection.privilegio);
                        return RedirectToAction("Create", "Funcionarios");
                    }
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        //- raise a new exception nesting
                        //- the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
        }


        
        public ActionResult Logout()
        {
            Session.Clear();

            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

         [HttpPost]
         [ValidateAntiForgeryToken]
        public ActionResult Login(login _login)
        {
            //Session.Clear();
            var checkLogin = db.logins.Where( ids => (ids.email.TrimEnd().TrimStart().Equals(_login.email.TrimEnd().TrimStart()) || ids.username.TrimEnd().TrimStart().Equals(_login.username.TrimEnd().TrimStart())) && 
            ids.password.Equals(_login.password)).FirstOrDefault();

            if (checkLogin != null)
            {
                if ((bool)checkLogin.privilegio)
                {

                    //-- Session["id_login"] = checkLogin.id_login;
                    /****
                            HttpResponseMessage responseMessage = GlobalVariavel.web.GetAsync("Utentes").Result;
                        livros = responseMessage.Content.ReadAsAsync<IEnumerable<UtentesModel>>().Result;
                     * 
                     */
                    saveSession(checkLogin.id_login, checkLogin.username, (bool)checkLogin.privilegio);


                    HttpResponseMessage responseMessage = GlobalVariavel.web.GetAsync("Utentes").Result;
                    IEnumerable<UtentesModel>utentes = responseMessage.Content.ReadAsAsync<IEnumerable<UtentesModel>>().Result;
                    
                    Session["id_utente"] = utentes.Where((x) => x.id_login.Equals(checkLogin.id_login)).FirstOrDefault().id_utente;
                    Session["qtdItens"] = 0;

                    return RedirectToAction("Index", "Livros");

                }
                else 
                {

                    HttpResponseMessage responseMessage = GlobalVariavel.web.GetAsync("Funcionarios").Result;
                    IEnumerable<FuncionariosModel> utentes = responseMessage.Content.ReadAsAsync<IEnumerable<FuncionariosModel>>().Result;

                    Session["id_funcionario"] = utentes.Where((x) => x.id_login.Equals(checkLogin.id_login)).FirstOrDefault().id_funcionario;
                    saveSession(checkLogin.id_login, checkLogin.username, (bool)checkLogin.privilegio);
                    return RedirectToAction("Index", "Funcionarios");
                }

            }

            ViewBag.Notification = "Username/Palavra passe Incorreto!";
            return View();
        }

        private void saveSession(int idlogin, String username, bool previlegio)
        {
            Session["id_login"] = idlogin; //
            Session["username"] = username;
            Session["previlegio"] = (bool)previlegio;
        }
   
    }
}