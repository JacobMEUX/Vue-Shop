using ServiceLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface ICostumerService : ICrudService<CostumerDTO>
    {
        Task<CostumerDTO> GetByID(string id);
    }
}
