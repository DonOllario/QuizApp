using AutoMapper;
using Data.Contexts;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class CRUDService : ICRUDService
    {
        private readonly IDbReadService _dbReadService;
        private readonly QuizAppContext _context;
        private readonly IMapper _mapper;

        public CRUDService(IDbReadService dbReadService, QuizAppContext context, IMapper mapper)
        {
            _dbReadService = dbReadService; 
            _context = context; 
            _mapper = mapper; 

        }
        public async Task<List<TDto>> GetAsync<TEntity, TDto>(bool include = false)
            where TEntity : class
            where TDto : class
        {
            if (include) _dbReadService.Include<TEntity>(); 
            var entities = await _dbReadService.GetAsync<TEntity>(); 
            return _mapper.Map<List<TDto>>(entities); 
        }

        public async Task<TDto> SingleAsync<TEntity, TDto>(Expression<Func<TEntity, bool>> expression, bool include = false)
            where TEntity : class
            where TDto : class
        {
            if (include) _dbReadService.Include<TEntity>(); 
            var entity = await _dbReadService.SingleAsync(expression);
            return _mapper.Map<TDto>(entity); 
        }                                      


        public async Task<bool> AnyAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class
        {
            return await _dbReadService.AnyAsync(expression);
        }

        public async Task<int> CreateAsync<TDto, TEntity>(TDto item) where TDto : class where TEntity : class
      
        {
            try
            {
                var entity = _mapper.Map<TEntity>(item); 
                _context.Add(entity);                  
                var succeeded = await _context.SaveChangesAsync() >= 0; 
               
            }

            catch (Exception ex)
            {

            }

            return -1;
        }

        public async Task<bool> UpdateAsync<TDto, TEntity>(TDto item)
            where TDto : class
            where TEntity : class
        {
            try
            {
                var entity = _mapper.Map<TEntity>(item); 
                _context.Update(entity); 
                return await _context.SaveChangesAsync() >= 0;
            }

            catch
            {

            }

            return false;
        }

        public async Task<bool> DeleteAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class
        {
            try
            {
                var entity = await _dbReadService.SingleAsync(expression); 
                _context.Remove(entity);
                return await _context.SaveChangesAsync() >= 0;
            }

            catch
            {
                return false;
            }


        }

    }
}
