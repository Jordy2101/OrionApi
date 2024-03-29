﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ORIONDEV.SERVICES.Base.Interface
{
    public interface IServicesBase<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        bool Exist(Expression<Func<T, bool>> expression);
        T GetOne(int Id);
        int Create(T entity);
        T Update(T entity);
        void Delete(int Id);
    }
}
