using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Repository
{
    public class RepsitoryBase<TEntity> where TEntity:class
    {
        protected DbContext context { get; set; }
        protected DbSet<TEntity> _dbSet { get; set; }

        public RepsitoryBase(DbContext contex)
        {
            this.context = contex;
            _dbSet = contex.Set<TEntity>();
        }

        public TEntity Save(TEntity model)
        {
            _dbSet.Add(model);
            context.SaveChanges();
            return model;
        }

        public List<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public TEntity Get(long id)
        {
            return _dbSet.Find(id);
        }
        public void Update(TEntity item)
        {
            context.Entry(item).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Remove(int id)
        {
            Remove(Get(id));
        }

        public void Remove(TEntity item)
        {
            _dbSet.Remove(item);
            context.SaveChanges();
        }
    }
}
