using EticaretV1.Core.Entity;
using EticaretV1.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using EticaretV1.DAL.Context;
using System.Data.Entity.Infrastructure;

namespace EticaretV1.Service.BaseService
{
    public class ServiceBase<T> : ICoreService<T> where T : CoreEntity
    {

        private ProjectContext _context;

        public ServiceBase()
        {
            _context = new ProjectContext();
        }


        public void Add(List<T> items)
        {
            _context.Set<T>().AddRange(items);
            Save();
        }

        public void Add(T item)
        {
            _context.Set<T>().Add(item);
            Save();
        }

        public bool Any(Expression<Func<T, bool>> exp) => _context.Set<T>().Any(exp);
       

        public List<T> GetActive()
        {
            return _context.Set<T>().Where(X => X.Status == Core.Enum.Status.Active).ToList();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetByDefault(Expression<Func<T, bool>> exp)
        {
            return _context.Set<T>().Where(exp).FirstOrDefault();
        }

        public T GetById(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> GetDefault(Expression<Func<T, bool>> exp)
        {
            return _context.Set<T>().Where(exp).ToList();
        }

        public void Remove(Guid id)
        {
            T item = GetById(id);
            item.Status = Core.Enum.Status.Deleted;
            Update(item);
        }

        public void Remove(T item)
        {
            item.Status = Core.Enum.Status.Deleted;
            Update(item);
        }

        public void RemoveAll(Expression<Func<T, bool>> exp)
        {
            foreach (var item in GetDefault(exp))
            {
                item.Status = Core.Enum.Status.Deleted;
                Update(item);
            }
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Update(T İtem)
        {
            T updated = GetById(İtem.Id);
            DbEntityEntry entry = _context.Entry(updated);
            entry.CurrentValues.SetValues(İtem);
            Save();
        }
    }
}
