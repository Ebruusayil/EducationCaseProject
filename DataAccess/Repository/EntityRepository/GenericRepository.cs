using DataAccess.Abstract;
using DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public GenericRepository(EducationPortalDbContext context)
        {
        }

        public void Delete(T t)
        {
            using var context = new EducationPortalDbContext();
            context.Set<T>().Remove(t);
            context.SaveChanges();
        }

        public T GetByID(int id)
        {
            using var context = new EducationPortalDbContext();
            return context.Set<T>().Find(id);
        }

        public List<T> GetList()
        {
            using var context = new EducationPortalDbContext();
            return context.Set<T>().ToList();
        }

        public void Insert(T t)
        {
            using var context = new EducationPortalDbContext();
            context.Set<T>().Add(t);
            context.SaveChanges();
        }

        public void Update(T t)
        {
            using var context = new EducationPortalDbContext();
            context.Set<T>().Update(t);
            context.SaveChanges();
        }
    }
}
