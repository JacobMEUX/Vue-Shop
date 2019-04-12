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
    public class CategoryService : ICategoryService
    {
        private readonly MappingService _mappingService;
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(MappingService mappingService, ICategoryRepository categoryRepository)
        {
            _mappingService = mappingService;
            _categoryRepository = categoryRepository;
        }
        public async Task<bool> Create(CategoryDTO categoryDTO)
        {
            return await _categoryRepository.Create(_mappingService._mapper.Map<Category>(categoryDTO));
        }

        public async Task<List<CategoryDTO>> GetAll()
        {
            return _mappingService._mapper.Map<List<CategoryDTO>>(await _categoryRepository.GetAll());
        }

        public async Task<CategoryDTO> GetByID(int id)
        {
            return _mappingService._mapper.Map<CategoryDTO>(await _categoryRepository.GetByID(id));
        }

        public async Task<bool> Remove(CategoryDTO categoryDTO)
        {
            return await _categoryRepository.Remove(_mappingService._mapper.Map<Category>(categoryDTO));
        }

        public async Task<bool> Update(CategoryDTO categoryDTO)
        {
            return await _categoryRepository.Update(_mappingService._mapper.Map<Category>(categoryDTO));
        }
    }
}
