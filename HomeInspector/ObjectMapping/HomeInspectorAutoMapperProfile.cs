using HomeInspector.Entities;
using HomeInspector.Services.Dtos.Device;
using HomeInspector.Services.Dtos.Profile;

namespace HomeInspector.ObjectMapping;

public class HomeInspectorAutoMapperProfile : AutoMapper.Profile
{
    public HomeInspectorAutoMapperProfile()
    {
        /* Create your AutoMapper object mappings here */
        CreateMap<CreateUpdateDeviceDto, Device>();
        CreateMap<Device, DeviceDto>();
        CreateMap<ProfileOwn, ProfileOwnDto>();
        CreateMap<CreateUpdateProfileOwnDto, ProfileOwn>();
    }
}
