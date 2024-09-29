﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Specification
{
    public interface ISpecification<T>
    {
        // Criteria .Where(x => x.id == id ) expression of fun c delegate 
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T,object>>> Includes { get; }
        Expression<Func<T, object>> OrderBy { get; }
        Expression<Func <T,object>> OrderByDescending { get; }
        int Take { get; }
        int Skip { get; }
        bool IsPaginated { get; }

    }
}
