using AutoMapper;
using HomeInspector.Entities;
using HomeInspector.Services.Dtos.Device;

namespace HomeInspector.ObjectMapping;

public class HomeInspectorAutoMapperProfile : Profile
{
    public HomeInspectorAutoMapperProfile()
    {
        /* Create your AutoMapper object mappings here */
        CreateMap<CreateUpdateDeviceDto, Device>();
        CreateMap<Device, DeviceDto>();
    }
}
