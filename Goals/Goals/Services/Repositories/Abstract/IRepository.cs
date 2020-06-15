using System.Collections.Generic;
using System.Threading.Tasks;

namespace Messenger.Repositories.Abstract
{
    interface IRepository<T> where T : class
    {
        Task Add(T item);

        Task Update(T item);

        Task Delete(int id);

        Task<T> Find(int id);

        Task<List<T>> GetAll();

        Task<List<T>> FindAll(int id);  
    }
}
