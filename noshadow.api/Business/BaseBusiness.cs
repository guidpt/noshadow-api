using System;
using System.Threading.Tasks;
using noshadow.api.Utils;

namespace noshadow.api.Business
{
    public class BaseBusiness<T> where T : class 
    {
        private readonly IDataRepository<T> _baseRepository;
        
        public BaseBusiness(IDataRepository<T>  baseRepository)
        {
            _baseRepository = baseRepository;
        }
        
        public BaseBusiness()
        {
        }

        public Task Create(T item)
        {
            return _baseRepository.Create(item);
        }
        
   
        public async Task<int> Update(T item)
        {
            return await _baseRepository.UpdateAndSaveAsync(item);
        }

        public void Delete(T item)
        {
            _baseRepository.Remove(item);
        }
    }
}