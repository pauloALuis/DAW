using MvcGestaoLivros.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MvcGestaoLivros.Controllers
{
    public class EmprestimosController : Controller
    {
        // GET: Emprestimos
        public ActionResult Index()
        {
         

            IEnumerable<EmprestimoModel> emprestimos;
            List<EmprestimoModel> historicoEmprestimo;  
            HttpResponseMessage responseMessage = GlobalVariavel.web.GetAsync("Emprestimos").Result;    
          
            emprestimos = responseMessage.Content.ReadAsAsync<IEnumerable<EmprestimoModel>>().Result;
            //emprestimos = emprestimos.OrderBy(C => C.id_emprestimo).ThenBy(C => C.Province).ThenBy(C => C.Code);
            emprestimos = emprestimos.OrderByDescending(C => C.id_emprestimo).ThenByDescending(C => C.id_emprestimo).ThenByDescending(C => C.id_emprestimo);


            if ((Session["id_utente"] != null) && ((int)Session["id_utente"] != 0) && Session["id_funcionario"] == null)
           {
                historicoEmprestimo = emprestimos.Where((e) => e.id_utente.Equals((int)Session["id_utente"])).ToList();

                return View(historicoEmprestimo);
                // IEnumerable
            }
            else
            {
                return View(emprestimos);
            }
            
           
        }
        // GET: Requisicao/Details/5
        public ActionResult DetailsFinalizado(int id)
        {

            return View();
        }

        // GET: Funcionarios/Details/5
        public ActionResult Details(int id)
        {

            HttpResponseMessage response = GlobalVariavel.web.GetAsync("Emprestimos/" + id.ToString()).Result;
            TempData["id_enco"] = id;
            TempData.Keep("id_enco");

            //emprestimos = response.Content.ReadAsAsync<IEnumerable<EmprestimoViewModel>>().Result;
            return View(response.Content.ReadAsAsync<IEnumerable<EmprestimoViewModel>>().Result);

        }

        // GET: Emprestimos/Details/5
        public ActionResult Historico()
        {
            
            IEnumerable<EmprestimoViewModel> emprestimos;
            HttpResponseMessage responseMessage = GlobalVariavel.web.GetAsync("Emprestimos").Result;
            emprestimos = responseMessage.Content.ReadAsAsync<IEnumerable<EmprestimoViewModel>>().Result;
            return View(emprestimos);
        }


        // GET: Emprestimos/Details/5
        public ActionResult Aprovar(int id = 0, bool flag = false)
        {

            if(id >= 1)
            {
                try
                {


                    HttpResponseMessage response = GlobalVariavel.web.GetAsync("Emprestimos/" + id.ToString()).Result;
                    IEnumerable<EmprestimoViewModel> emp1 = response.Content.ReadAsAsync<IEnumerable<EmprestimoViewModel>>().Result;

                    EmprestimoViewModel emp =emp1.First() ;
                    DateTime dateTime = DateTime.UtcNow.Date;
                    DateTime dateDevolucao = dateTime.AddDays(36);
                    string v = dateTime.ToString("yyyy/MM/dd");



                    EmprestimoModel newEmprestimoModel = new EmprestimoModel();
                    newEmprestimoModel.id_emprestimo = emp.id_emprestimo;
                    newEmprestimoModel.id_utente = emp.id_utente;
                    newEmprestimoModel.data_requisicao_emprestimo = DateTime.Parse(dateTime.ToString("yyyy/MM/dd"));
                    newEmprestimoModel.data_devolucao_emprestimo = DateTime.Parse(dateDevolucao.ToString("yyyy/MM/dd"));
                    newEmprestimoModel.data_entrega_emprestimo = null;
                    newEmprestimoModel.obs_emprestimo = emp.obs_emprestimo;
                    if(flag) newEmprestimoModel.status_emprestimo = "Aprovado"; else newEmprestimoModel.status_emprestimo = "Recusado";
                    newEmprestimoModel.multa_valor_emprestimo = "00.00€";
                    newEmprestimoModel.flagAtiva = (bool)emp.flagAtiva;

                //HTTP POST
                //https://www.tutorialsteacher.com/webapi/consume-web-api-put-method-in-aspnet-mvc
                //var putTask = GlobalVariavel.web.PutAsJsonAsync("Emprestimos", newEmprestimoModel);
                    var putTask = GlobalVariavel.web.PutAsJsonAsync($"Emprestimos/{newEmprestimoModel.id_emprestimo}", newEmprestimoModel).Result;


                   

                   
                    if (putTask.IsSuccessStatusCode)
                    {
                        TempData["SuccessMessage"] = "O/A Atualizado com sucesso";

                        return RedirectToAction("Index");
                    }

              
               
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }


            }


            TempData["SuccessMessage"] = "Não atualizada";
            return RedirectToAction("Index");
        }



        // GET: Emprestimos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Emprestimos/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Emprestimos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Emprestimos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Emprestimos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Emprestimos/Delete/5
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
