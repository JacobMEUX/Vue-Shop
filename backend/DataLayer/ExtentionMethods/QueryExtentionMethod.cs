using DataLayer.Entities;
using DataLayer.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.ExtentionMethods
{
    public static class QueryExtentionMethod
    {
        public static IQueryable<Clothing> GenerateQuery(this IQueryable<Clothing> query, SortFilterSearchOptions options)
        {
            query = (options.BrandId != null) ? query.Where(o => o.FKBrandId == options.BrandId) : query;

            query = (options.CategoryId != null) ? query.Where(o => o.FKCategoryId == options.CategoryId) : query;

            query = (options.Color != null) ? query.Where(o => o.Color == options.Color) : query;

            query = (options.Size != null) ? query.Where(o => o.Size == options.Size) : query;

            query = !string.IsNullOrWhiteSpace(options.Search) ? query.Where(o => o.Title.ToLower().Contains(options.Search.ToLower())) : query;

            if (options.SortOrder != null)
            {
                switch (options.SortOrder)
                {
                    case SortOrder.PriceASC:
                        query = query.OrderBy(o => o.Price);
                        break;
                    case SortOrder.PriceDSC:
                        query = query.OrderByDescending(o => o.Price);
                        break;
                    case SortOrder.ColorASC:
                        query = query.OrderBy(o => o.Color);
                        break;
                    case SortOrder.ColorDSC:
                        query = query.OrderByDescending(o => o.Color);
                        break;
                    case SortOrder.BrandASC:
                        query = query.OrderBy(o => o.FKBrandId);
                        break;
                    case SortOrder.BrandDSC:
                        query = query.OrderByDescending(o => o.FKBrandId);
                        break;
                    case SortOrder.CategoryASC:
                        query = query.OrderBy(o => o.FKCategoryId);
                        break;
                    case SortOrder.CategoryDSC:
                        query = query.OrderByDescending(o => o.FKCategoryId);
                        break;
                    case SortOrder.SizeASC:
                        query = query.OrderBy(o => o.Size);
                        break;
                    case SortOrder.SizeDSC:
                        query = query.OrderByDescending(o => o.Size);
                        break;
                    default:
                        break;
                }
            }
            return query;
        }

    }
}
