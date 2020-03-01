using Abp.Application.Services;
using MyProject.AutoService.Parts.Dto;

namespace MyProject.AutoService.Parts
{
    public interface IPartAppService : IAsyncCrudAppService<PartDto, int, PagedPartResultRequestDto, CreatePartDto, UpdatePartDto>
    {
    }
}
