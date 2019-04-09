using LojaCFF.UI.Data;
using LojaCFF.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaCFF.UI.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly LojaCFFDataContext _contexto = new LojaCFFDataContext();

        // GET: Produto
        public ActionResult Index()
        {
            var produtos = _contexto.Produtos.ToList();
            return View(produtos);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Produto produto)
        {
            //TODO : VALIDAR

            _contexto.Produtos.Add(produto);
            _contexto.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                return View(_contexto.Produtos.Find(id));
            }

            return RedirectToAction("index");
        }

        [HttpPost]
        public ActionResult Edit(Produto produto)
        {
            //TODO : VALIDAR

            var produtoBD = _contexto.Produtos.Find(produto.Id);

            produtoBD.Nome = produto.Nome;
            produtoBD.Preco = produto.Preco;
            produtoBD.Tipo = produto.Tipo;
            produtoBD.Qtde = produto.Qtde;

            _contexto.SaveChanges();

            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var produto = _contexto.Produtos.Find(id);

            if (produto == null)
            {
                return HttpNotFound();
            }

            _contexto.Produtos.Remove(produto);
            _contexto.SaveChanges();
            // Se chegou até aqui não deu erro.
            return null;
        }

        protected override void Dispose(bool disposing)
        {
            _contexto.Dispose();
        }
    }
}
