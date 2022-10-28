using AutoMapper;
using HomeInspector.Entities;
using HomeInspector.Services.Dtos.Device;
using HomeInspector.Services.Interfaces;
using Volo.Abp;
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

        /// <summary>
        /// register a new device into central database
        /// </summary>
        /// <param name="input">data for device</param>
        /// <returns>created device dto</returns>
        /// <exception cref="UserFriendlyException">when device mac already registered</exception>
        public async Task<DeviceDto> CreateAsync(CreateUpdateDeviceDto input)
        {
            var device = new Device(GuidGenerator.Create());
            device = Mapper.Map<CreateUpdateDeviceDto, Device>(input, device);

            var exists = await _deviceRepository.FindAsync(d => d.Mac == input.Mac);

            if (exists != null) 
            {
                throw new UserFriendlyException(string.Format("the device with mac {0} already exists", input.Mac));
            }

            device = await _deviceRepository.InsertAsync(device);
            var result = Mapper.Map<Device, DeviceDto>(device);
            return result;
            
        }

        /// <summary>
        /// search a device into database by mac
        /// </summary>
        /// <param name="mac">unique value by device</param>
        /// <returns><device founded instance/returns>
        public async Task<DeviceDto> GetDeviceByMac(string mac)
        {
            var device = await _deviceRepository.FindAsync(d => d.Mac == mac);
            var result = Mapper.Map<Device, DeviceDto>(device);
            return result;
        }

        /// <summary>
        /// update device
        /// </summary>
        /// <param name="id">unnique identifier</param>
        /// <param name="input">data to update</param>
        /// <returns>updated device instance dto</returns>
        /// <exception cref="UserFriendlyException"></exception>
        
        public async Task<DeviceDto> UpdateAsync(Guid id, CreateUpdateDeviceDto input)
        {
            var device = await _deviceRepository.FindAsync(d => d.Id == id);
            if (device == null) 
            {
                throw new UserFriendlyException(String.Format("the device id {0} not exists", id));
            }

            device = Mapper.Map<CreateUpdateDeviceDto, Device>(input, device);
            await _deviceRepository.UpdateAsync(device);

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
    }
}
