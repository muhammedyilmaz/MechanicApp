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
using MyProject.Authorization.Users;
using MyProject.AutoService.CarModels.Dto;

namespace MyProject.AutoService.CarModels
{
    public class CarModelAppService : AsyncCrudAppService<CarModel, CarModelDto, int, PagedCarModelResultRequestDto, CreateCarModelDto, UpdateCarModelDto>, ICarModelAppService
    {
        private readonly IRepository<CarModel, int> _repository;
        private readonly IRepository<User, long> _userRepository;
        public CarModelAppService(IRepository<CarModel, int> repository,
             IRepository<User, long> userRepository) : base(repository)
        {
            _repository = repository;
            _userRepository = userRepository;
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
            var query = base.CreateFilteredQuery(input);

            query = query.WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Keyword))
                .WhereIf(!input.CarMakeId.Equals(0), x => x.CarMakeId == input.CarMakeId)
                .WhereIf(input.CreatorUserIds != null, x => input.CreatorUserIds.Contains(x.CreatorUserId))
                .WhereIf(input.LastModifierUserIds != null, x => input.LastModifierUserIds.Contains(x.LastModifierUserId));

            return query;

        }


        private IQueryable<CarModelDto> Query(IQueryable<CarModel> queryCarModels)
        {
            var query = from carModel in queryCarModels
                        join creatorUser in _userRepository.GetAll() on carModel.CreatorUserId equals creatorUser.Id into creatorUserId
                        from creatorUser in creatorUserId.DefaultIfEmpty()
                        join lastModifierUser in _userRepository.GetAll() on carModel.LastModifierUserId equals lastModifierUser.Id into lastModifierUserId
                        from lastModifierUser in lastModifierUserId.DefaultIfEmpty()
                        select new CarModelDto
                        {
                            Id = carModel.Id,
                            CreationTime = carModel.CreationTime,
                            CreatorUserFullName = creatorUser.Name + " " + creatorUser.Surname,
                            LastModificationTime = carModel.LastModificationTime,
                            LastModifierUserFullName = lastModifierUser.Name + " " + lastModifierUser.Surname,
                            Name = carModel.Name
                        };

            return query;
        }

        [AbpAuthorize(PermissionNames.CarModel_List)]
        public override async Task<PagedResultDto<CarModelDto>> GetAllAsync(PagedCarModelResultRequestDto input)
        {
            CheckGetAllPermission();

            var query = CreateFilteredQuery(input);
            var totalCount = await AsyncQueryableExecuter.CountAsync(query);

            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);

            var entities = Query(query);

            return new PagedResultDto<CarModelDto>(
                totalCount,
                entities.ToList()
            );
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