using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext context;
        private bool disposed = false;
        public IDesignStudioRepository studioRepository { get; private set; }

        public UnitOfWork()
        {
            context = new DataContext();
            studioRepository = new DesignStudioRepository(context);
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
