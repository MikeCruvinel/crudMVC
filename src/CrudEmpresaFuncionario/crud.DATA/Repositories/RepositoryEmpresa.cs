using crud.DATA.Interface;
using crud.DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud.DATA.Repositories
{
    public class RepositoryEmpresa : RepositoryBase<Empresa>, IRepositoryEmpresa
    {
        public RepositoryEmpresa(bool SaveChanges = true) : base(SaveChanges)
        {

        }
    }
}
