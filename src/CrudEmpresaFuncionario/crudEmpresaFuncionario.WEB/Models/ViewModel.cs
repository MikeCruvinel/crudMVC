using crud.DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crudEmpresaFuncionario.WEB.Models
{
    public class ViewModel
    {
        public Empresa oEmpresa { get; set; }
        public List<Funcionario> oListFuncionario { get; set; }
    }
}
