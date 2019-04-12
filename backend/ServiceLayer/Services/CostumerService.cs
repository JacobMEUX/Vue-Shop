using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;
using DataLayer.Interfaces;
using ServiceLayer.DTOs;
using ServiceLayer.Interfaces;

namespace ServiceLayer.Services
{
    public class CostumerService : ICostumerService
    {
        private readonly MappingService _mappingService;
        private readonly ICostumerRepository _costumerRepository;
        public CostumerService(MappingService mappingService, ICostumerRepository costumerRepository)
        {
            _mappingService = mappingService;
            _costumerRepository = costumerRepository;
        }
        public async Task<bool> Create(CostumerDTO costumerDTO)
        {
            return await _costumerRepository.Create(_mappingService._mapper.Map<Costumer>(costumerDTO));
        }

        public async Task<List<CostumerDTO>> GetAll()
        {
            return _mappingService._mapper.Map<List<CostumerDTO>>(await _costumerRepository.GetAll());
        }
        public async Task<CostumerDTO> GetByID(string id)
        {
            return _mappingService._mapper.Map<CostumerDTO>(await _costumerRepository.GetByID(id));
        }

        public async Task<CostumerDTO> GetByID(int id)
        {
            return _mappingService._mapper.Map<CostumerDTO>(await _costumerRepository.GetByID(id));
        }

        public async Task<bool> Remove(CostumerDTO costumerDTO)
        {
            return await _costumerRepository.Remove(_mappingService._mapper.Map<Costumer>(costumerDTO));
        }

        public async Task<bool> Update(CostumerDTO costumerDTO)
        {
            return await _costumerRepository.Update(_mappingService._mapper.Map<Costumer>(costumerDTO));
        }
    }
}
