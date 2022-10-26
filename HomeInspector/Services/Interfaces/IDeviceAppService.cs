using HomeInspector.Services.Dtos.Device;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace HomeInspector.Services.Interfaces
{
    public interface IDeviceAppService : ICrudAppService<DeviceDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateDeviceDto, CreateUpdateDeviceDto>
    {
    }
}
