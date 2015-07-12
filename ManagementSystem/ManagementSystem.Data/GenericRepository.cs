using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;

namespace ManagementSystem.Data
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
       public GenericRepository()
            : this(new ApplicationDbContext())
        {
        }

       public GenericRepository(ApplicationDbContext context)
       {
           if (context == null)
           {
               throw new ArgumentException("An instance of DbContext is required to use this repository.", "context");
           }

           this.Context = context;
           this.DbSet = this.Context.Set<T>();
           
       }

       protected ApplicationDbContext Context { get; set; }

       protected IDbSet<T> DbSet { get; set; }


       public IQueryable<T> All()
       {
           return this.DbSet.AsQueryable();
       }

       public T GetById(int id)
       {
           return this.DbSet.Find(id);
       }

       public void Add(T entity)
       {
           DbEntityEntry entry = this.Context.Entry(entity);
           if (entry.State != EntityState.Detached)
           {
               entry.State = EntityState.Added;
           }
           else
           {
               this.DbSet.Add(entity);
           }
       }

       public void Update(T entity)
       {
           DbEntityEntry entry = this.Context.Entry(entity);
           if (entry.State == EntityState.Detached)
           {
               this.DbSet.Attach(entity);
           }

           entry.State = EntityState.Modified;
       }

       public void Delete(T entity)
       {
           DbEntityEntry entry = this.Context.Entry(entity);
           if (entry.State != EntityState.Deleted)
           {
               entry.State = EntityState.Deleted;
           }
           else
           {
               this.DbSet.Attach(entity);
               this.DbSet.Remove(entity);
           }
       }

       public virtual void Delete(int id)
       {
           var entity = this.GetById(id);

           if (entity != null)
           {
               this.Delete(entity);
           }
       }

       public virtual void Detach(T entity)
       {
           DbEntityEntry entry = this.Context.Entry(entity);

           entry.State = EntityState.Detached;
       }
    }
}
