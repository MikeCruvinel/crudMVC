using crud.DATA.Interface;
using crud.DATA.Models;
using crudEmpresaFuncionario.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace crudEmpresaFuncionario.WEB.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly IRepositoryEmpresa _repositoryEmpresa;
        private readonly IRepositoryFuncionario _repositoryFuncionario;

        public EmpresaController(IRepositoryFuncionario repositoryFuncionario,
            IRepositoryEmpresa repositoryEmpresa)
        {
            _repositoryEmpresa = repositoryEmpresa;
            _repositoryFuncionario = repositoryFuncionario;
        }

        public IActionResult Index()
        {
            List<Empresa> lst_Empresa = _repositoryEmpresa.SelecionarTodos();
            return View(lst_Empresa);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Empresa model)
        {
            if (!ModelState.IsValid)
                return View();

            _repositoryEmpresa.Incluir(model);

            return RedirectToAction("Index");
        }

        public IActionResult Details(int Id)
        {
            ViewModel oEmpresaViewModel = new ViewModel();
            oEmpresaViewModel.oEmpresa = _repositoryEmpresa.SelecionarPK(Id);
            oEmpresaViewModel.oListFuncionario = _repositoryFuncionario.SelecionarByIdEmpresa
                (oEmpresaViewModel.oEmpresa.Id);

            return View(oEmpresaViewModel);
        }

        public IActionResult Edit(int Id)
        {
            Empresa oEmpresa = _repositoryEmpresa.SelecionarPK(Id);
            return View(oEmpresa);
        }

        [HttpPost]
        public IActionResult Edit(Empresa model)
        {
            Empresa oEmpresa = _repositoryEmpresa.Alterar(model);

            int Id = oEmpresa.Id;

            return RedirectToAction("Details", new { Id });
        }
        public IActionResult Delete(int Id)
        {
            ViewModel oEmpresaViewModel = new ViewModel();
            oEmpresaViewModel.oEmpresa = _repositoryEmpresa.SelecionarPK(Id);
            oEmpresaViewModel.oListFuncionario = _repositoryFuncionario.SelecionarByIdEmpresa
                (oEmpresaViewModel.oEmpresa.Id);

            for (int i = 0; i <= oEmpresaViewModel.oListFuncionario.Count - 1; i++)
            {
                _repositoryFuncionario.Excluir(oEmpresaViewModel.oListFuncionario[i].Id);
            }

            _repositoryEmpresa.Excluir(Id);
            return RedirectToAction("index");
        }
    }
}
