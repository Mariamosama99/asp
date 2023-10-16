using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Repository
{
    public class Manager <T> where T : class
    {
        private readonly MyDBContext _DbContext;
        public readonly DbSet<T> Set;
        public Manager(MyDBContext _MyDBContext)
        {
            _DbContext = _MyDBContext;
            Set = _DbContext.Set<T>();
        }

        public IQueryable<T> GetList()
        {
            return Set.AsQueryable();
        }
        public EntityEntry<T> Add(T Entry) =>
            Set.Add(Entry);

        public EntityEntry<T> Update(T Entry) =>
             Set.Update(Entry);

    }
}