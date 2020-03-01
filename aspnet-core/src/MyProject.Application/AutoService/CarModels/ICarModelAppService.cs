using Abp.Application.Services;
using MyProject.AutoService.CarModels.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyProject.AutoService.CarModels
{
    public interface ICarModelAppService : IAsyncCrudAppService<CarModelDto, int, PagedCarModelResultRequestDto, CreateCarModelDto, UpdateCarModelDto>
    {
        Task BulkDeleteAsync(List<int> ids);
    }
}
