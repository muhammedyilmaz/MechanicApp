using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using MyProject.Authorization;
using MyProject.AutoService.CarMakes.Dto;

namespace MyProject.AutoService.CarMakes
{
    public class CarMakeAppService : AsyncCrudAppService<CarMake, CarMakeDto, int, PagedCarMakeResultRequestDto, CreateCarMakeDto, UpdateCarMakeDto>, ICarMakeAppService
    {
        private readonly IRepository<CarMake, int> _repository;
        public CarMakeAppService(IRepository<CarMake, int> repository) : base(repository)
        {
            _repository = repository;
        }
      
        [AbpAuthorize(PermissionNames.CarMake_Edit)]
        public override Task<CarMakeDto> UpdateAsync(UpdateCarMakeDto input)
        {
            return base.UpdateAsync(input);
        }

        [AbpAuthorize(PermissionNames.CarMake_Create)]
        public override async Task<CarMakeDto> CreateAsync(CreateCarMakeDto input)
        {
            return await base.CreateAsync(input);
        }

        protected override IQueryable<CarMake> CreateFilteredQuery(PagedCarMakeResultRequestDto input)
        {
            return Repository.GetAllIncluding()
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Keyword));
        }

        [AbpAuthorize(PermissionNames.CarMake_List)]
        public override Task<PagedResultDto<CarMakeDto>> GetAllAsync(PagedCarMakeResultRequestDto input)
        {
            return base.GetAllAsync(input);
        }

        [AbpAuthorize(PermissionNames.CarMake_Delete)]
        public override async Task DeleteAsync(EntityDto<int> input)
        {
            CheckDeletePermission();

            var carMake = await _repository.GetAsync(input.Id);
            await _repository.DeleteAsync(carMake);
        }

        [AbpAuthorize(PermissionNames.CarMake_Delete)]
        public async Task BulkDeleteAsync(List<int> ids)
        {
            foreach (var id in ids)
            {
                var carMake = await _repository.GetAsync(id);
                await _repository.DeleteAsync(carMake);
            }
        }
    }
}