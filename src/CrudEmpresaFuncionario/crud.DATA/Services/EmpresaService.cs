using crud.DATA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud.DATA.Services
{
    public class EmpresaService
    {
        public RepositoryEmpresa oRepositoryEmpresa { get; set; }

        public EmpresaService()
        {
            oRepositoryEmpresa = new RepositoryEmpresa();
        }
    }
}
