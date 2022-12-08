using crud.DATA.Models;
using System.Collections.Generic;

namespace crudEmpresaFuncionario.WEB.Models
{
    public class ViewModel
    {
        public Empresa oEmpresa { get; set; }
        public List<Funcionario> oListFuncionario { get; set; }
    }
}
