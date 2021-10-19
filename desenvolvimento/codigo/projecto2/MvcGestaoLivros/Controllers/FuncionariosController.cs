using MvcGestaoLivros.Models;
using MvcGestaoLivros.Models.Data;
using projecto2.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MvcGestaoLivros.Controllers
{
    public class FuncionariosController : Controller
    {
        // GET: Funcionarios
        public ActionResult Index()
        {
            IEnumerable<FuncionariosModel> emprestimos;
            HttpResponseMessage responseMessage = GlobalVariavel.web.GetAsync("Funcionarios").Result;
            emprestimos = responseMessage.Content.ReadAsAsync<IEnumerable<FuncionariosModel>>().Result;
            return View(emprestimos);
            //return View();
        }

        // GET: Funcionarios/Details/5
        public ActionResult Details(int id)
        {
            HttpResponseMessage response = GlobalVariavel.web.GetAsync("Funcionarios/" + id.ToString()).Result;
           // var funcionarios = response.Content.ReadAsAsync<FuncionariosModel>().Result;

            return View(response.Content.ReadAsAsync<Funcionarios>().Result);

            //return View(funcionarios);
        }

        // GET: Funcionarios/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Funcionarios/Create
        [HttpPost]
        public ActionResult Create(FuncionariosModel collection)
        {


            try
            {
            
                    collection.id_login = (int)Session["id_login"];
                    HttpResponseMessage httpResponse = GlobalVariavel.web.PostAsJsonAsync("Funcionarios", collection).Result;
                    int currentUtente = Uteis.ConvertStringToInt(httpResponse.Content.ReadAsStringAsync().Result.ToString());

                    TempData["SuccessMessage"] = "Criado com sucesso \n ID: " + currentUtente;
                    Session["id_funcionario"] = currentUtente;
                    Session["nome_user"] = collection.nome_funcionario;


                    return RedirectToAction("Index");
                
              
            }
            catch
            {
                // return View(); 
                // TempData["SuccessMessage"] = "Editado com sucesso";
                //return RedirectToAction("Index");
                ViewBag.Notification = "Não foi possivel guardar";
                return RedirectToAction("Create");

            }



        }


        // GET: Funcionarios/Edit/5
        public ActionResult Edit(int id)
        {     
            if(id != 0)
            {
                HttpResponseMessage httpResponse = GlobalVariavel.web.GetAsync("Funcionarios/" + id.ToString()).Result;

                return View(httpResponse.Content.ReadAsAsync<Funcionarios>().Result);
            }
            return View();
        }

        // POST: Funcionarios/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Funcionarios collection)
        {
            try
            {


                // TODO: Add update logic here  

                FuncionariosModel model = new FuncionariosModel();
                model.id_funcionario = collection.id_funcionario;

                model.id_login = collection.id_login;
                model.email_funcionario = collection.email_funcionario;
                model.data_nascimento_funcionario = collection.data_nascimento_funcionario;
                model.contato_funcionario = collection.contato_funcionario;
                model.cc_funcionario = collection.cc_funcionario;
                model.nome_funcionario = collection.nome_funcionario;



                HttpResponseMessage httpResponse = GlobalVariavel.web.PutAsJsonAsync("Funcionarios/" + collection.id_funcionario, collection).Result;
                  //  int currentUtente = Uteis.ConvertStringToInt(httpResponse.Content.ReadAsStringAsync().Result.ToString());

                    TempData["SuccessMessage"] = "Atualizado com sucesso \n ID: " + collection.nome_funcionario ;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Funcionarios/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Funcionarios/Delete/5
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
