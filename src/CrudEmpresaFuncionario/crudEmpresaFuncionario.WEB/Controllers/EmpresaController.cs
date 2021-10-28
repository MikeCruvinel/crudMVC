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
    public class EmpresaController : Controller
    {
        private EmpresaService oEmpresaService = new EmpresaService();
        private FuncionarioService oFuncionarioService = new FuncionarioService();

        public IActionResult Index()
        {
            List<Empresa> lst_Empresa = oEmpresaService.oRepositoryEmpresa.SelecionarTodos();
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

            oEmpresaService.oRepositoryEmpresa.Incluir(model);

            return RedirectToAction("Index");
        }

        public IActionResult Details(int Id)
        {
            ViewModel oEmpresaViewModel = new ViewModel();
            oEmpresaViewModel.oEmpresa = oEmpresaService.oRepositoryEmpresa.SelecionarPK(Id); 
            oEmpresaViewModel.oListFuncionario = oFuncionarioService.oRepositoryFuncionario.SelecionarByIdEmpresa(oEmpresaViewModel.oEmpresa.Id);
            
            return View(oEmpresaViewModel);
        }

        public IActionResult Edit(int Id)
        {
            Empresa oEmpresa = oEmpresaService.oRepositoryEmpresa.SelecionarPK(Id);
            return View(oEmpresa);
        }

        [HttpPost]
        public IActionResult Edit(Empresa model)
        {
            Empresa oEmpresa = oEmpresaService.oRepositoryEmpresa.Alterar(model);

            int Id = oEmpresa.Id;

            return RedirectToAction("Details", new { Id });
        }
        public IActionResult Delete(int Id)
        {
            ViewModel oEmpresaViewModel = new ViewModel();
            oEmpresaViewModel.oEmpresa = oEmpresaService.oRepositoryEmpresa.SelecionarPK(Id);
            oEmpresaViewModel.oListFuncionario = oFuncionarioService.oRepositoryFuncionario.SelecionarByIdEmpresa(oEmpresaViewModel.oEmpresa.Id);

            for (int i = 0; i <= oEmpresaViewModel.oListFuncionario.Count - 1; i++)
            {
                oFuncionarioService.oRepositoryFuncionario.Excluir(oEmpresaViewModel.oListFuncionario[i].Id);
            }

            oEmpresaService.oRepositoryEmpresa.Excluir(Id);
            return RedirectToAction("index");
        }
    }
}
