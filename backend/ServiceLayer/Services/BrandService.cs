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
    public class BrandService : IBrandService
    {
        private readonly MappingService _mappingService;
        private readonly IBrandRepository _brandRepository;
        public BrandService(MappingService mappingService, IBrandRepository brandRepository)
        {
            _mappingService = mappingService;
            _brandRepository = brandRepository;
        }
        public async Task<bool> Create(BrandDTO brandDTO)
        {
            return await _brandRepository.Create(_mappingService._mapper.Map<Brand>(brandDTO));
        }

        public async Task<List<BrandDTO>> GetAll()
        {
            return _mappingService._mapper.Map<List<BrandDTO>>(await _brandRepository.GetAll());
        }

        public async Task<BrandDTO> GetByID(int id)
        {
            return _mappingService._mapper.Map<BrandDTO>(await _brandRepository.GetByID(id));
        }

        public async Task<bool> Remove(BrandDTO brandDTO)
        {
            return await _brandRepository.Remove(_mappingService._mapper.Map<Brand>(brandDTO));
        }

        public async Task<bool> Update(BrandDTO brandDTO)
        {
            return await _brandRepository.Update(_mappingService._mapper.Map<Brand>(brandDTO));
        }
    }
}
