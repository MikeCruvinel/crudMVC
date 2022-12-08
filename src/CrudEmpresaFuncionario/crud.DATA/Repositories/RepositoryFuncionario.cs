using crud.DATA.Interface;
using crud.DATA.Models;
using System.Collections.Generic;
using System.Linq;

namespace crud.DATA.Repositories
{
    public class RepositoryFuncionario : RepositoryBase<Funcionario>, IRepositoryFuncionario
    {
        public RepositoryFuncionario(bool SaveChanges = true) : base(SaveChanges)
        {

        }

        public List<Funcionario> SelecionarByIdEmpresa(int id)
        {
            return _context.Funcionario.Where(x => x.IdEmpresa == id).ToList();
        }

        public Funcionario SelecionarById(int id)
        {
            return _context.Funcionario.Where(x => x.IdEmpresa == id).FirstOrDefault();
        }
    }
}
