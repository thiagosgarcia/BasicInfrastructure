﻿using System.Collections.Generic;
using System.Linq;
using BasicInfrastructure.Persistence;

namespace BasicInfrastructure.ParameterHelpers
{
    public interface IRequestParameters<T> 
    {
        int? PageId { get; set; }
        int? PerPage { get; set; }
        int? ItemCount { get; set; }
        int? PageCount { get; set; }
        bool? CountItems { get; set; }
        //TODO Colocar link de next e previous pages

        List<SortItem<T>> SortItems { get; set; }
        List<Filter<T>> Filters { get; set; }

        IQueryable<T> GetQuery(IQueryable<T> query, bool countItems = false);
    }
}
