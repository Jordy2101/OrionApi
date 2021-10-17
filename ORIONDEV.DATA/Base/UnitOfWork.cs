using Microsoft.EntityFrameworkCore.Storage;
using ORIONDEV.DATA.Base.Interface;
using ORIONDEV.DATA.DBContexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ORIONDEV.DATA.Base
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly OrionDevDataContext _DataContext;

        public UnitOfWork(OrionDevDataContext dataContext)
        {
            _DataContext = dataContext;
        }

        public IDbContextTransaction CreateTransaction()
        {
            return this._DataContext.Database.BeginTransaction();
        }

        public void Dispose()
        {
            if (_DataContext != null)
            {
                _DataContext.Dispose();
            }
        }

        public int SaveChanges()
        {
            return _DataContext.SaveChanges();
        }
    }
}
