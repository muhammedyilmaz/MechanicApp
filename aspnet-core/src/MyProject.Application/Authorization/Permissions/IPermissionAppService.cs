using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyProject.Authorization.Permissions.Dto;

namespace MyProject.Authorization.Permissions
{
    public interface IPermissionAppService : IApplicationService
    {
        ListResultDto<FlatPermissionWithLevelDto> GetAllPermissions();
    }
}
