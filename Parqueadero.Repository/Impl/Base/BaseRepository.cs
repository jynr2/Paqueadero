using Microsoft.EntityFrameworkCore;
using Parqueadero.Repository.Context;
using Parqueadero.Repository.Contratc.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parqueadero.Repository.Impl.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ParqueaderoDBContext _context;

        public BaseRepository(ParqueaderoDBContext context) => _context = context;

        public async Task<T> Add(T entity)
        {
            try
            {
                _context.Set<T>().Add(entity);
                var result = await _context.SaveChangesAsync();

                if (result > 0) return entity;
                else return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error");
            }
        }

        public async Task<List<T>> GetAll()
        {
            try
            {
                var entities = await _context.Set<T>().ToListAsync();

                if (entities.Count > 0 || entities != null) return entities;
                else return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error");
            }
        }

        public async Task<T> GetById(int id)
        {
            try
            {
                return await _context.Set<T>().FindAsync(id);
            }
            catch (Exception)
            {
                throw new Exception("Ha ocurrido un error");;
            }
        }
    }
}
