using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IClothingRepository : ICrudRepository<Clothing>
    {
        Task<List<Clothing>> GetClothing(SortFilterSearchOptions options);
        Task<int> GetCount(SortFilterSearchOptions options);
    }
}
