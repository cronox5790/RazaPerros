using RazasPerros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazasPerros.Repositories
{
    public class Repository<R> where R : class
    {
        public perrosContext Context { get; set; }


        public Repository(perrosContext context)
        {
            Context = context;
        }

        public virtual IEnumerable<R> GetAll()
        {
            return Context.Set<R>();
        }

        public virtual R GetById(object id)
        {
            return Context.Find<R>(id);
        }

        public virtual void Insert(R entidad)
        {
            if (Validate(entidad))
            {
                Context.Add(entidad);
                Save();
            }
        }

        public virtual void Update(R entidad)
        {
            if (Validate(entidad))
            {
                Context.Update(entidad);
                Save();
            }
        }

        public virtual bool Validate(R entidad)
        {
            return true;
        }
        public virtual void Save()
        {
            Context.SaveChanges();
        }

        public virtual void Delete(R entidad)
        {
            Context.Remove(entidad);
            Save();
        }
    }
}
