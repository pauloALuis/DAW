using MvcGestaoLivros.Models;
using Newtonsoft.Json;
using projecto2.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcGestaoLivros.Controllers
{
    public class LivrosController : Controller
    {
        private List<LivroModel> BookToCart = new List<LivroModel>();
        List<LivrosModel> livros = new List<LivrosModel>();

        public LivrosController()
        {
            AllBooks();
        }

        public List<LivroModel> BookToCarts { get => BookToCart; set => BookToCart = value; }

        private List<LivrosModel> AllBooks()
        {
           HttpResponseMessage responseMessage = GlobalVariavel.web.GetAsync("Livros").Result;
           IEnumerable<LivrosModel> _livros = responseMessage.Content.ReadAsAsync<IEnumerable<LivrosModel>>().Result;
         
           livros = _livros.ToList();
           return livros;
        }

        // GET: Livros
        public ActionResult Index()
        {

            if ((int)BookToCarts.Count > 0 || Session["cart"] != null)
            {
                foreach (var item in Session["cart"] as List<MvcGestaoLivros.Models.LivroModel>)
                {
                    //BookToCart.Add(item);
                    livros.RemoveAll((x) => x.id_Livro ==item.id_livro);
                }

                return View((IEnumerable<LivrosModel>)livros);

            }


            return View((IEnumerable<LivrosModel>)livros);
        }

        // GET: Livros/Details/5
        public ActionResult Details(int id)
        {      

            HttpResponseMessage response = GlobalVariavel.web.GetAsync("LivroAutor/" + id.ToString()).Result;
            return View(response.Content.ReadAsAsync<LivroAutorViewModel>().Result);
        }



        // GET: Livros/Edit/5
        public ActionResult Edit(int id = 0)
        {
            if (Session["id_utente"] == null || (int)Session["id_utente"] <= 1)
            {
                HttpResponseMessage response = GlobalVariavel.web.GetAsync("LivroAutor/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<LivroAutorViewModel>().Result);
            }
            return RedirectToAction("Index");
           
        }
  

        // POST: Livros/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, LivroAutorViewModel collection)
        {
            try
            {
                if (Session["id_utente"] == null || (int)Session["id_utente"] <= 0)
                {
                    // TODO: Add insert logic here
                   
               

                    if (collection == null || !ModelState.IsValid)
                    {
                        ViewBag.Notification = "Não foi possivel guardar";
                        return View();
                    }

                    HttpResponseMessage httpResponse = GlobalVariavel.web.PostAsJsonAsync("Livros", collection).Result;
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        TempData["SuccessMessage"] = "Criado com sucesso \n ID: ";
                        return RedirectToAction("Index");
                    }
                   
                }else return RedirectToAction("Index");

            }
            catch
            {
                ViewBag.Notification = "Não foi possivel guardar";
                return View();
            }

            ViewBag.Notification = "Não foi possivel guardar";
            return View();
        }

        // GET: Livros/Create
        public ActionResult Create()
        {

            if (Session["id_utente"] == null || (int)Session["id_utente"] <= 0)
            {
                return View();
            } return RedirectToAction("Index");

        }

        // POST: Livros/Create
        [HttpPost]
        public ActionResult Create(LivrosModel collection)
        {
            try
            {

                if (Session["id_utente"] == null || (int)Session["id_utente"] >= 1)
                {
                    if (collection == null || !ModelState.IsValid)
                    {
                        ViewBag.Notification = "Não foi possivel guardar";
                        return View();
                    }

                    collection.id_Livro = -1;
                    // TODO: Add insert logic here
                    HttpResponseMessage httpResponse = GlobalVariavel.web.PostAsJsonAsync("Livros", collection).Result;
                    TempData["SuccessMessage"] = "Criado com sucesso \n ID: " ;  
                    return RedirectToAction("Index");               
                }

                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Notification = "Não foi possivel guardar";
                return View();
            }
        }
       
        /*
            metodo para adicionar Livro no carrinho e guardar numa lista de Livros
       * */
        public ActionResult AddCart(int id)
        {
            try
            {
                HttpResponseMessage response = GlobalVariavel.web.GetAsync("Livros/" + id.ToString()).Result;
                LivrosModel livro = response.Content.ReadAsAsync<LivrosModel>().Result;
                LivroModel newItem = new LivroModel();
                newItem.id_livro = livro.id_Livro;
                newItem.titulo_livro = livro.titulo_livro;
                newItem.editorProdutora_livro = livro.editorProdutora_livro;
                newItem.genero_livro = livro.genero_livro;
                newItem.flagAtivo = livro.flagAtivo;
                newItem.obs_livro = livro.obs_livro;
                newItem.isbn_livro = livro.isbn_livro;
                newItem.numpaginas_livro = livro.numpaginas_livro;
                newItem.piccapa_livro = livro.piccapa_livro;
                newItem.qtd_livro = 1;
                if(Session["cart"] == null)
                {
                    BookToCart.Add(newItem);
                    Session["cart"] = BookToCart;
                }
                else
                {
                    //update in listcart
                    foreach (var item in Session["cart"] as List<MvcGestaoLivros.Models.LivroModel>)
                    {
                        BookToCart.Add(item);
                    }
                    BookToCart.Add(newItem);
                    Session["cart"] = BookToCart;
                }
                Session["qtdItens"] = (int)BookToCarts.Count;
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            updateListBoo();
            return RedirectToAction("Index");
        }

        private void updateListBoo()
        {
            if((int)BookToCarts.Count > 0)
            {
                foreach (var item in Session["cart"] as List<MvcGestaoLivros.Models.LivroModel>)
                {
                    livros.RemoveAll((x) => x.id_Livro.Equals(item.id_livro));
                }
               

            }
            
        }

        //jp_@acm.org

        public ActionResult OrderFinish()
        {
            try
            {
                if (Session["cart"] != null && Session["id_utente"] != null)
                {
                      // https://localhost:44373/api/ItemEmprestimo/20
                    
                        DateTime dateTime = DateTime.UtcNow.Date;
                        DateTime dateDevolucao = dateTime.AddDays(36);
                        string v = dateTime.ToString("yyyy/MM/dd");

                        EmprestimoModel newEmprestimoModel = new EmprestimoModel();
                        newEmprestimoModel.id_utente = (int)Session["id_utente"];
                        newEmprestimoModel.data_requisicao_emprestimo = DateTime.Parse(dateTime.ToString("yyyy/MM/dd"));
                        newEmprestimoModel.data_devolucao_emprestimo = DateTime.Parse(dateDevolucao.ToString("yyyy/MM/dd"));
                        newEmprestimoModel.data_entrega_emprestimo = null;
                        newEmprestimoModel.obs_emprestimo = BookToCarts.Count+ "Item";
                        newEmprestimoModel.status_emprestimo = "Em Análise";
                        newEmprestimoModel.multa_valor_emprestimo = "00.00€";
                        newEmprestimoModel.flagAtiva = true;
                        


                        HttpResponseMessage httpResponse = GlobalVariavel.web.PostAsJsonAsync("Emprestimos", newEmprestimoModel).Result;
                        int id_emprestimo = Uteis.ConvertStringToInt(httpResponse.Content.ReadAsStringAsync().Result.ToString());


                        ItemEmprestimoModel itemEmps = new ItemEmprestimoModel();
                        itemEmps.id_emprestimo = id_emprestimo;

                        foreach (var item in Session["cart"] as List<MvcGestaoLivros.Models.LivroModel>)
                        {

                            itemEmps.id_livro = item.id_livro;
                            HttpResponseMessage httpResponses = GlobalVariavel.web.PostAsJsonAsync("ItemEmprestimo", itemEmps).Result;

                        }



                    TempData["SuccessMessage"] = "Criado com sucesso \n ID: " + id_emprestimo;
                    BookToCarts.Clear();
                    Session["cart"] = BookToCarts;  
                    Session["qtdItens"] = 0;


                    TempData["searchJob"] = id_emprestimo;
                    return RedirectToAction("StatusOrder", new { id = id_emprestimo });
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return RedirectToAction("Index");
        }

        public ActionResult Checkout()
        {
            if (Session["cart"] != null && Session["id_utente"] != null)
            {
                 return View();
            }
            
            return RedirectToAction("Index");

        }

        public ActionResult StatusOrder(int id = -1)
        {

            if (id > 0)
            {
                HttpResponseMessage response = GlobalVariavel.web.GetAsync("Emprestimos/" + id.ToString()).Result;
                IEnumerable<EmprestimoViewModel> livro = response.Content.ReadAsAsync<IEnumerable<EmprestimoViewModel>>().Result;

                TempData["endereco"] = livro.First().endereco_utente;
                TempData["nome_utente"] = livro.First().nome_utente;
                TempData["data_requisicao"] = livro.First().data_requisicao_emprestimo;
                TempData["id_emprestimo"] = livro.First().id_emprestimo;
                TempData["data_devolucao_emprestimo"] = livro.First().data_devolucao_emprestimo;
                TempData["status_emprestimo"] = livro.First().status_emprestimo;





                TempData.Keep("endereco");
                TempData.Keep("nome_utente");
                TempData.Keep("id_emprestimo");
                TempData.Keep("data_requisicao");
                TempData.Keep("data_devolucao_emprestimo");
                TempData.Keep("status_emprestimo");// = livro.First().status_emprestimo;
                return View(livro);

            }

            return RedirectToAction("Index");
        }

        public ActionResult RemoveItem(int id)
        {

            try
            {
                if (Session["cart"] != null)
                {
                    //remove item to list cart
                    foreach (var item in Session["cart"] as List<MvcGestaoLivros.Models.LivroModel>)
                    {
                        BookToCart.Add(item);
                    }

                    BookToCart.RemoveAll((x) => x.id_livro.Equals(id));

                   // BookToCart.Add(newItem);
                    Session["cart"] = BookToCart;
                }


                Session["qtdItens"] = (int)BookToCarts.Count;
                updateListBoo();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.Message);
            }
      
           return RedirectToAction("Checkout");
        }

                // GET: Livros/Delete/5
        public ActionResult Delete(int id)
        {

            if (Session["id_utente"] == null || (int)Session["id_utente"] <= 1)
            {
                    return View();

            }
            return RedirectToAction("Index");
        }

        // POST: Livros/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, LivroAutorViewModel collection)
        {
            try
            {

                if (Session["id_utente"] != null )
                {
                    return RedirectToAction("Index");
                }
                // TODO: Add delete logic here
                HttpResponseMessage response = GlobalVariavel.web.DeleteAsync("livros/"+ id.ToString()).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["Sucesso"] = "Criado com sucesso";
                    
                    return RedirectToAction("Index");


                }
            }
            catch
            {
                ViewBag.Notification = "Não foi possivel guardar";
                return View();
            }

            ViewBag.Notification = "Não foi possivel guardar";
            return View();
        }

        // GET: Livros
        public ActionResult IndexLists()
        {
            IEnumerable<LivrosModel> livros;
            HttpResponseMessage responseMessage = GlobalVariavel.web.GetAsync("Livros").Result;
            livros = responseMessage.Content.ReadAsAsync<IEnumerable<LivrosModel>>().Result;
            return View(livros);
        }
    }
}
