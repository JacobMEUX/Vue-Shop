using DataLayer.Entities;
using DataLayer.Interfaces;
using ServiceLayer.DTOs;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class ClothingService : IClothingService
    {
        private readonly MappingService _mappingService;
        private readonly IClothingRepository _clothingRepository;
        public ClothingService(MappingService mappingService, IClothingRepository clothingRepository)
        {
            _mappingService = mappingService;
            _clothingRepository = clothingRepository;
        }
        public async Task<bool> Create(ClothingDTO clothingDTO)
        {
            return await _clothingRepository.Create(_mappingService._mapper.Map<Clothing>(clothingDTO));
        }

        public async Task<List<ClothingDTO>> GetAll()
        {
            return _mappingService._mapper.Map<List<ClothingDTO>>(await _clothingRepository.GetAll());
        }

        public async Task<ClothingDTO> GetByID(int id)
        {
            return _mappingService._mapper.Map<ClothingDTO>(await _clothingRepository.GetByID(id));
        }

        public async Task<List<ClothingDTO>> GetClothing(SortFilterSearchOptionsDTO options)
        {
            return _mappingService._mapper.Map<List<ClothingDTO>>(await _clothingRepository.GetClothing(_mappingService._mapper.Map<SortFilterSearchOptions>(options)));
        }

        public async Task<int> GetCount(SortFilterSearchOptionsDTO options)
        {
            return await _clothingRepository.GetCount(_mappingService._mapper.Map<SortFilterSearchOptions>(options));
        }

        public async Task<bool> Remove(ClothingDTO clothingDTO)
        {
            return await _clothingRepository.Remove(_mappingService._mapper.Map<Clothing>(clothingDTO));
        }

        public async Task<bool> Update(ClothingDTO clothingDTO)
        {
            return await _clothingRepository.Update(_mappingService._mapper.Map<Clothing>(clothingDTO));
        }
    }
}
