using Resume.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Resume.MVC.Repositories
{
    public class GenericRepository<T> where T : class, new()
    {
        MyAcademyDbEntities db = new MyAcademyDbEntities();

        public List<T> GetList() 
        {
            return db.Set<T>().ToList();
        }

        public void TAdd(T entity) 
        {
            db.Set<T>().Add(entity);
            db.SaveChanges();
        }

        public void TDelete(T entity) 
        {
            db.Set<T>().Remove(entity);
            db.SaveChanges();
        }
        public T TGetById(int id) 
        {
            return db.Set<T>().Find(id);
        }
        public void TUpdate(T entity) 
        {
            db.SaveChanges();
        }
        public T Find(Expression<Func<T, bool>> where) 
        {
            return db.Set<T>().FirstOrDefault(where);
        }
    }
}