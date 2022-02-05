using Parqueadero.Repository.Contratc.Base;
using Parqueadero.Service.Contrat.Base;
using Parqueadero.Service.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parqueadero.Service.Impl.Base
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly IBaseRepository<T> _baseRepository;
        private readonly BaseResponse _baseResponse = new BaseResponse();

        public BaseService(IBaseRepository<T> baseRepository) => _baseRepository = baseRepository;
        public async Task<BaseResponse> Add(T entity)
        {
            try
            {
                var response = await _baseRepository.Add(entity);

                if (response == null)
                {
                    _baseResponse.OperationStatus = 0;
                    _baseResponse.Message = "No fue posible agregar el registro";
                }
                else
                {
                    _baseResponse.OperationStatus = 1;
                    _baseResponse.Message = "Registro agregado con éxito";
                    _baseResponse.Entity = response;
                }
            }
            catch (Exception)
            {
                _baseResponse.OperationStatus = 99;
                _baseResponse.Message = "Ha ocurrido un error";
            }

            return _baseResponse;
        }

        public async Task<BaseResponse> GetAll()
        {
            try
            {
                var response = await _baseRepository.GetAll();

                if (response.Count == 0 || response == null)
                {
                    _baseResponse.OperationStatus = 0;
                    _baseResponse.Message = "No hay registros";
                }
                else
                {
                    _baseResponse.OperationStatus = 1;
                    _baseResponse.Message = "Consulta realizada con éxito";
                    _baseResponse.Entity = response;
                }
            }
            catch (Exception ex)
            {
                _baseResponse.OperationStatus = 99;
                _baseResponse.Message = "Ha ocurrido un error";
            }

            return _baseResponse;
        }

        public async Task<List<T>> GetAllEntities()
        {
            try
            {
                return await _baseRepository.GetAll();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<BaseResponse> GetById(int id)
        {
            try
            {
                var response = await _baseRepository.GetById(id);

                if (response == null)
                {
                    _baseResponse.OperationStatus = 0;
                    _baseResponse.Message = $"El registro con id {id}";
                }
                else
                {
                    _baseResponse.OperationStatus = 1;
                    _baseResponse.Message = "Registro localizado exitosamente";
                    _baseResponse.Entity = response;
                }
            }
            catch (Exception)
            {
                _baseResponse.OperationStatus = 99;
                _baseResponse.Message = "Ha ocurrido un error";
            }

            return _baseResponse;
        }

        public async Task<T> GetEntityById(int id)
        {
            try
            {
                return await _baseRepository.GetById(id);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
