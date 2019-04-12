using ServiceLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IClothingService : ICrudService<ClothingDTO>
    {
        Task<List<ClothingDTO>> GetClothing(SortFilterSearchOptionsDTO options);
        Task<int> GetCount(SortFilterSearchOptionsDTO options);
    }
}
