using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface ICRUDService
    {
        Task<List<TDto>> GetAsync<TEntity, TDto>(bool include = false) where TEntity : class where TDto : class; // Returns a list of Dtos //GetAsync - Get all the DTOs
        Task<TDto> SingleAsync<TEntity, TDto>(Expression<Func<TEntity, bool>> expression, bool include = false) where TEntity : class where TDto : class; //Returns an Dto  //Expression corresponds to Lambda expression in the Get Single Async method finding with the Id - s => s.Id.Equals(id)                                                                                                                                                     //include corresponds the including navigation properties same for the method //TEntity and TDto should be classes and not anything else (int or string etc) //Task<TDto> is the return object 
        Task<bool> AnyAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class; //Returns true or false- item was found or not
        Task<int> CreateAsync<TDto, TEntity>(TDto item) where TDto : class where TEntity : class; //Returns an int - Id that was created
        Task<bool> UpdateAsync<TDto, TEntity>(TDto item) where TDto : class where TEntity : class;
        Task<bool> DeleteAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class;

    }
}
