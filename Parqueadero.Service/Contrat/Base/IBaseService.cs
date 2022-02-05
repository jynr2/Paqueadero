using Parqueadero.Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parqueadero.Service.Contrat.Base
{
    public interface IBaseService<T> where T : class
    {
        Task<BaseResponse> Add(T entity);
        Task<BaseResponse> GetById(int id);
        Task<T> GetEntityById(int id);
        Task<BaseResponse> GetAll();
        Task<List<T>> GetAllEntities();
    }
}
