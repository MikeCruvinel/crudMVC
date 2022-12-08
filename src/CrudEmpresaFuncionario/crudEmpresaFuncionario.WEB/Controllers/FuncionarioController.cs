using crud.DATA.Interface;
using crud.DATA.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace crudEmpresaFuncionario.WEB.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly IRepositoryEmpresa _repositoryEmpresa;
        private readonly IRepositoryFuncionario _repositoryFuncionario;

        public FuncionarioController(IRepositoryFuncionario repositoryFuncionario,
            IRepositoryEmpresa repositoryEmpresa)
        {
            _repositoryEmpresa = repositoryEmpresa;
            _repositoryFuncionario = repositoryFuncionario;
        }

        public IActionResult Index()
        {
            List<Funcionario> lst_funcionario = _repositoryFuncionario.SelecionarTodos();
            return View(lst_funcionario);
        }
        public IActionResult Create(int IdEmpresa)
        {

            ViewBag.IdEmpresa = IdEmpresa;

            return View();
        }

        [AutoValidateAntiforgeryToken]
        [HttpPost]
        public IActionResult Create(Funcionario model)
        {
            if (!ModelState.IsValid)
                return View();

            _repositoryFuncionario.Incluir(model);

            return RedirectToAction("Details", model);
        }
        public IActionResult Details(int Id)
        {
            Funcionario oFuncionario = _repositoryFuncionario.SelecionarPK(Id);
            Empresa oEmpresa = _repositoryEmpresa.SelecionarPK(oFuncionario.IdEmpresa);
            ViewBag.NomeEmpresa = oEmpresa.Nome;
            return View(oFuncionario);
        }

        public IActionResult Edit(int Id)
        {
            Funcionario oFuncionario = _repositoryFuncionario.SelecionarPK(Id);
            ViewBag.IdEmpresa = oFuncionario.IdEmpresa;
            return View(oFuncionario);
        }

        [AutoValidateAntiforgeryToken]
        [HttpPost]
        public IActionResult Edit(Funcionario model)
        {
            Funcionario oFuncionario = _repositoryFuncionario.Alterar(model);

            int Id = oFuncionario.Id;

            return RedirectToAction("Details", new { Id });
        }

        public IActionResult Delete(int Id)
        {
            _repositoryFuncionario.Excluir(Id);
            return RedirectToAction("Index", "empresa");
        }
    }
}
