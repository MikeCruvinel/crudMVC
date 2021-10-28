using crud.DATA.Interface;
using crud.DATA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud.DATA.Repositories
{
    public class RepositoryBase<T> : IRepositoryModel<T>, IDisposable where T : class
    {
        protected CrudmvcContext _context;
        public bool _SaveChances = true;

        public RepositoryBase(bool saveChanges = true)
        {
            _SaveChances = saveChanges;
            _context = new CrudmvcContext();
        }
        
        public T Alterar(T objeto)
        {
            _context.Entry(objeto).State = EntityState.Modified;

            if (_SaveChances)
            {
                _context.SaveChanges();
            }

            return objeto;
        }

        public List<T> SelecionarTodosEmpresa(params object[] variavel)
        {
            return _context.Set<T>().ToList<T>();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Excluir(T objeto)
        {
            _context.Set<T>().Remove(objeto);
            
            if (_SaveChances)
            {
                _context.SaveChanges();
            }
        }

        public void Excluir(params object[] variavel)
        {
            var obj = SelecionarPK(variavel);
            Excluir(obj);
        }

        public T Incluir(T objeto)
        {
            _context.Set<T>().Add(objeto);

            if (_SaveChances)
            {
                _context.SaveChanges();
            }

            return objeto;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public T SelecionarPK(params object[] variavel)
        {
            return _context.Set<T>().Find(variavel);
        }

        public List<T> SelecionarTodos()
        {
            return _context.Set<T>().ToList<T>();
        }
    }
}
