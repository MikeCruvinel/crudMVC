using crud.DATA.Models;
using crud.DATA.Services;
using crudEmpresaFuncionario.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crudEmpresaFuncionario.WEB.Controllers
{
    public class FuncionarioController : Controller
    {

        private FuncionarioService oFuncionarioService = new FuncionarioService();
        private EmpresaService oEmpresaService = new EmpresaService();

        public IActionResult Index()
        {
            List<Funcionario> lst_funcionario = oFuncionarioService.oRepositoryFuncionario.SelecionarTodos();
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

            oFuncionarioService.oRepositoryFuncionario.Incluir(model);

            return RedirectToAction("Details", model);
        }
        public IActionResult Details(int Id)
        {
            Funcionario oFuncionario = oFuncionarioService.oRepositoryFuncionario.SelecionarPK(Id);
            Empresa oEmpresa = oEmpresaService.oRepositoryEmpresa.SelecionarPK(oFuncionario.IdEmpresa);
            ViewBag.NomeEmpresa = oEmpresa.Nome;
            return View(oFuncionario);
        }

        public IActionResult Edit(int Id)
        {
            Funcionario oFuncionario = oFuncionarioService.oRepositoryFuncionario.SelecionarPK(Id);
            ViewBag.IdEmpresa = oFuncionario.IdEmpresa;
            return View(oFuncionario);
        }

        [AutoValidateAntiforgeryToken]
        [HttpPost]
        public IActionResult Edit(Funcionario model)
        {
            Funcionario oFuncionario = oFuncionarioService.oRepositoryFuncionario.Alterar(model);

            int Id = oFuncionario.Id;

            return RedirectToAction("Details", new { Id });
        }

        public IActionResult Delete(int Id)
        {
            oFuncionarioService.oRepositoryFuncionario.Excluir(Id);
            return RedirectToAction("Index", "empresa");
        }
    }
}
