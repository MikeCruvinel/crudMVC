using crud.DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud.DATA.Interface
{
    public interface IRepositoryFuncionario : IRepositoryModel<Funcionario>
    {
        List<Funcionario> SelecionarByIdEmpresa(int id);

        Funcionario SelecionarById(int id);
    }
}
