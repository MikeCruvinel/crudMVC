using crud.DATA.Interface;
using crud.DATA.Models;

namespace crud.DATA.Repositories
{
    public class RepositoryEmpresa : RepositoryBase<Empresa>, IRepositoryEmpresa
    {
        public RepositoryEmpresa(bool SaveChanges = true) : base(SaveChanges)
        {
        }
    }
}
