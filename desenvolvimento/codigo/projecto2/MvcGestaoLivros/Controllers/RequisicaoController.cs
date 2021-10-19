using MvcGestaoLivros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcGestaoLivros.Controllers
{
    public class RequisicaoController : Controller
    {
        private LivrosController livrosOrder;

        public RequisicaoController()
        {
            this.livrosOrder = new LivrosController();
        }

        // GET: Requisicao
        public ActionResult Index()
        {
            List<LivroModel> orders = this.livrosOrder.BookToCarts;
            return View(orders);
        }

        // GET: Requisicao/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


 

        // GET: Requisicao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Requisicao/Create
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

        // GET: Requisicao/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Requisicao/Edit/5
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

        // GET: Requisicao/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Requisicao/Delete/5
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
