﻿using Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Interfaces
{
    public interface IUnitWork
    {
        IGenericRepository<TEntity,Tkey> Repository<TEntity, Tkey>() where TEntity : BaseEntity<Tkey>;
        Task<int> CompleteAsync();
    }
}
