using HomeInspector.Services.Dtos;
using HomeInspector.Services.Dtos.Device;
using HomeInspector.Services.Dtos.Profile;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace HomeInspector.Services.Interfaces
{
    public interface IProfileOwnAppService: ICrudAppService<ProfileOwnDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateProfileOwnDto, CreateUpdateProfileOwnDto>
    {
        Task<ResultOperationDto<bool>> CreateBulkAsync(BulkCreateUpdateProfileDto input);
    }
}
