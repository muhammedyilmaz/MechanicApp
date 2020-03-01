using Abp.Application.Services;
using MyProject.AutoService.CarMakes.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyProject.AutoService.CarMakes
{
    public interface ICarMakeAppService : IAsyncCrudAppService<CarMakeDto, int, PagedCarMakeResultRequestDto, CreateCarMakeDto, UpdateCarMakeDto>
    {
        Task BulkDeleteAsync(List<int> ids);
    }
}