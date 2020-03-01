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
using MyProject.AutoService.CarModels.Dto;
using MyProject.Editions;

namespace MyProject.AutoService.CarModels
{
    public class CarModelAppService : AsyncCrudAppService<CarModel, CarModelDto, int, PagedCarModelResultRequestDto, CreateCarModelDto, UpdateCarModelDto>, ICarModelAppService
    {
        private readonly IRepository<CarModel, int> _repository;
        public CarModelAppService(IRepository<CarModel, int> repository) : base(repository)
        {
            _repository = repository;
        }

        [AbpAuthorize(PermissionNames.CarModel_Edit)]
        public override Task<CarModelDto> UpdateAsync(UpdateCarModelDto input)
        {
            return base.UpdateAsync(input);
        }

        [AbpAuthorize(PermissionNames.CarModel_Create)]
        public override async Task<CarModelDto> CreateAsync(CreateCarModelDto input)
        {
            return await base.CreateAsync(input);
        }

        protected override IQueryable<CarModel> CreateFilteredQuery(PagedCarModelResultRequestDto input)
        {
            return Repository.GetAllIncluding()
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Keyword))
                .WhereIf(!input.CarMakeId.Equals(0), x => x.CarMakeId == input.CarMakeId);
        }

        [AbpAuthorize(PermissionNames.CarModel_List)]
        public override Task<PagedResultDto<CarModelDto>> GetAllAsync(PagedCarModelResultRequestDto input)
        {
            return base.GetAllAsync(input);
        }

        [AbpAuthorize(PermissionNames.CarModel_Delete)]
        public override async Task DeleteAsync(EntityDto<int> input)
        {
            CheckDeletePermission();

            var carModel = await _repository.GetAsync(input.Id);
            await _repository.DeleteAsync(carModel);
        }

        [AbpAuthorize(PermissionNames.CarModel_Delete)]
        public async Task BulkDeleteAsync(List<int> ids)
        {
            foreach (var id in ids)
            {
                var carModel = await _repository.GetAsync(id);
                await _repository.DeleteAsync(carModel);
            }
        }
    }
}