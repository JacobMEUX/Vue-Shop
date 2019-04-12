using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface ICrudRepository<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetByID(int id);
        Task<bool> Create(T input);
        Task<bool> Remove(T input);
        Task<bool> Update(T input);
    }
}
