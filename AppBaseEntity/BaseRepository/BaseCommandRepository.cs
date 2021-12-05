using AppBaseEntity.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBaseEntity.BaseRepository
{
    public class BaseCommandRepository<T> where T:DbContext
    {
        public IMapper _mapper { get; }
        public T _dbContext { get; }

        public BaseCommandRepository(IMapper mapper , T dbContext) 
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<TDomainModel> Create<TDomainModel, TEntityModel>(TDomainModel domainModel) //where TEntityModel : BaseEntity 
        {
            var entity = _mapper.Map<TEntityModel>(domainModel);
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();
            domainModel = _mapper.Map<TDomainModel>(entity);
            return domainModel;
        }

        public async Task<TDomainModel> Update<TDomainModel, TEntityModel>(TDomainModel domainModel) 
        {
            var entity = _mapper.Map<TDomainModel, TEntityModel>(domainModel);
            _dbContext.Update(entity);
            return await _dbContext.SaveChangesAsync() > 0 ? domainModel : default(TDomainModel);
        }        
    }
}
