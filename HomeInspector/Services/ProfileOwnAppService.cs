using AutoMapper;
using HomeInspector.Entities;
using HomeInspector.Services.Dtos;
using HomeInspector.Services.Dtos.Profile;
using HomeInspector.Services.Interfaces;
using System.Net;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.AutoMapper;
using Volo.Abp.Domain.Repositories;

namespace HomeInspector.Services
{
    public class ProfileOwnAppService : ApplicationService, IProfileOwnAppService
    {
        private readonly IRepository<ProfileOwn, Guid> _profileRepository;
        private readonly IMapperAccessor _mapperAccessor;
        private IMapper Mapper => _mapperAccessor.Mapper;
        
        public ProfileOwnAppService(IRepository<ProfileOwn, Guid> profileRepository, IMapperAccessor mapperAccessor)
        {
            _profileRepository = profileRepository;
            _mapperAccessor = mapperAccessor;
        }

        public async Task<ResultOperationDto<bool>> CreateBulkAsync(BulkCreateUpdateProfileDto input)
        {
            var result = new ResultOperationDto<bool>();
            List<ProfileOwn> profiles = new List<ProfileOwn>();

            foreach (var data in input.Profiles) 
            {
                var temp = Mapper.Map<CreateUpdateProfileOwnDto, ProfileOwn>(data);
                profiles.Add(temp);
            }

            await _profileRepository.InsertManyAsync(profiles);
            result.Data = true;
            result.Code = HttpStatusCode.Created;
            return result;
        }

        public Task<ProfileOwnDto> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<ProfileOwnDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        public Task<ProfileOwnDto> CreateAsync(CreateUpdateProfileOwnDto input)
        {
            throw new NotImplementedException();
        }

        public Task<ProfileOwnDto> UpdateAsync(Guid id, CreateUpdateProfileOwnDto input)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
