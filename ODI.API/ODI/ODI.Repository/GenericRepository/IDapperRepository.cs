﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODI.Repository.GenericRepository
{
    public interface IDapperRepository<TEntity> : IDisposable
    {
        DbConnection GetDbconnection();
        T Get<T>(string sp, TEntity entity);
        List<T> GetAll<T>(string sp, TEntity entity);
        T Execute<T>(string sp, TEntity entity);

    }
}
