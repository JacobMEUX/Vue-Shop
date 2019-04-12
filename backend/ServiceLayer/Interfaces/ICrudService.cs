using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface ICrudService<T>
    {
        /// <summary>
        /// Gets a list of the <seealso cref="<typeparamref name="T"/>"/>
        /// </summary>
        /// <returns></returns>
        Task<List<T>> GetAll();
        Task<T> GetByID(int id);
        Task<bool> Create(T input);
        Task<bool> Remove(T input);
        Task<bool> Update(T input);

    }
}
