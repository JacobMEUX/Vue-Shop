using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface ICostumerRepository : ICrudRepository<Costumer>
    {
        Task<Costumer> GetByID(string id);
    }
}
