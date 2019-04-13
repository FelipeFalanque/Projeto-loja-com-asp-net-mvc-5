using LojaCFF.Data.EF;
using LojaCFF.Data.EF.Repositories;
using LojaCFF.Domain.Entities;
using LojaCFF.Domain.Interfaces.Repositories;
using LojaCFF.UI.ViewModel.Produto;
using LojaCFF.UI.ViewModel.Produto.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaCFF.UI.Controllers
{
    [Authorize]
    public class ProdutosController : Controller
    {
        private readonly IProdutoRepository _repoProduto = new ProdutoRepositoryEF();
        private readonly ITipoProdutoRepository _repoTipoProduto = new TipoProdutoRepositoryEF();

        // GET: Produto
        public ActionResult Index()
        {
            var produtos = _repoProduto.Get().ToProdutosViewsModels();
            return View(produtos);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var tipos = _repoTipoProduto.Get();
            ViewBag.Tipos = tipos;

            return View();
        }

        [HttpPost]
        public ActionResult Add(ProdutoViewModel produtoVM)
        {
            var produto = produtoVM.ToProduto();

            //TODO : VALIDAR
            if (ModelState.IsValid)
            {
                _repoProduto.Add(produto);

                return RedirectToAction("index");
            }

            var tipos = _repoTipoProduto.Get();
            ViewBag.Tipos = tipos;

            return View(produtoVM);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                var tipos = _repoTipoProduto.Get();
                ViewBag.Tipos = tipos;

                return View(_repoProduto.Get((int)id).ToProdutoViewModel());
            }

            return RedirectToAction("index");
        }

        [HttpPost]
        public ActionResult Edit(ProdutoViewModel produtoVM)
        {
            var produto = produtoVM.ToProduto();

            //TODO : VALIDAR
            if (ModelState.IsValid)
            {
                var produtoBD = _repoProduto.Get(produto.Id);

                produtoBD.Nome = produto.Nome;
                produtoBD.Preco = produto.Preco;
                produtoBD.TipoProdutoId = produto.TipoProdutoId;
                produtoBD.Qtde = produto.Qtde;

                _repoProduto.Edit(produtoBD);

                return RedirectToAction("index");
            }

            var tipos = _repoTipoProduto.Get();
            ViewBag.Tipos = tipos;

            return View(produtoVM);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var produto = _repoProduto.Get(id);

            if (produto == null)
            {
                return HttpNotFound();
            }

            _repoProduto.Delete(produto);

            return null;
        }

        protected override void Dispose(bool disposing)
        {
            _repoProduto.Dispose();
            _repoTipoProduto.Dispose();
        }
    }
}
