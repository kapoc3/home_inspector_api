using AutoMapper;
using HomeInspector.Entities;
using HomeInspector.Services.Dtos.Device;
using HomeInspector.Services.Interfaces;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.AutoMapper;
using Volo.Abp.Domain.Repositories;

namespace HomeInspector.Services
{
    public class DeviceAppService : ApplicationService, IDeviceAppService
    {
        private readonly IRepository<Device, Guid> _deviceRepository;
        private readonly IMapperAccessor _mapperAccessor;
        private IMapper Mapper => _mapperAccessor.Mapper;

        public DeviceAppService(IRepository<Device, Guid> deviceRepository, IMapperAccessor mapperAccessor)
        {
            _deviceRepository = deviceRepository;
            _mapperAccessor = mapperAccessor;
        }
        
        public async Task<DeviceDto> CreateAsync(CreateUpdateDeviceDto input)
        {
            var device = new Device(GuidGenerator.Create());
            device = Mapper.Map<CreateUpdateDeviceDto, Device>(input, device);

            var exists = await _deviceRepository.FindAsync(d => d.Mac == input.Mac);

            if (exists != null) 
            {
                throw new Exception("the device with mac {0} already exists");
            }

            device = await _deviceRepository.InsertAsync(device);
            var result = Mapper.Map<Device, DeviceDto>(device);
            return result;
            
        }

        public async Task<DeviceDto> GetDeviceByMac(string mac)
        {
            var device = await _deviceRepository.FindAsync(d => d.Mac == mac);
            var result = Mapper.Map<Device, DeviceDto>(device);
            return result;
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<DeviceDto> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<DeviceDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        public Task<DeviceDto> UpdateAsync(Guid id, CreateUpdateDeviceDto input)
        {
            throw new NotImplementedException();
        }
    }
}
