using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using MyProject.Authorization;
using MyProject.Authorization.Users;
using MyProject.AutoService.CarMakes.Dto;

namespace MyProject.AutoService.CarMakes
{
    public class CarMakeAppService : AsyncCrudAppService<CarMake, CarMakeDto, int, PagedCarMakeResultRequestDto, CreateCarMakeDto, UpdateCarMakeDto>, ICarMakeAppService
    {
        private readonly IRepository<CarMake, int> _repository;
        private readonly IRepository<User, long> _userRepository;
        public CarMakeAppService(IRepository<CarMake, int> repository,
             IRepository<User, long> userRepository) : base(repository)
        {
            _repository = repository;
            _userRepository = userRepository;
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
            var query = base.CreateFilteredQuery(input);

            query = query.WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Keyword))
                .WhereIf(!input.CreatorUserId.Equals(0), x => x.CreatorUserId == input.CreatorUserId)
                .WhereIf(!input.LastModifierUserId.Equals(0), x => x.LastModifierUserId == input.LastModifierUserId);

            return query;

        }


        private IQueryable<CarMakeDto> Query(IQueryable<CarMake> queryCarMakes)
        {
            var query = from carMake in queryCarMakes
                         join creatorUser in _userRepository.GetAll() on carMake.CreatorUserId equals creatorUser.Id into creatorUserId
                         from creatorUser in creatorUserId.DefaultIfEmpty()
                         join lastModifierUser in _userRepository.GetAll() on carMake.LastModifierUserId equals lastModifierUser.Id into lastModifierUserId
                         from lastModifierUser in lastModifierUserId.DefaultIfEmpty()
                         select new CarMakeDto
                         {
                             Id = carMake.Id,
                             CreationTime = carMake.CreationTime,
                             CreatorUserFullName = creatorUser.Name + " " + creatorUser.Surname,
                             LastModificationTime = carMake.LastModificationTime,
                             LastModifierUserFullName = lastModifierUser.Name + " " + lastModifierUser.Surname,
                             Name = carMake.Name
                         };

            return query;
        }

        [AbpAuthorize(PermissionNames.CarMake_List)]
        public override async Task<PagedResultDto<CarMakeDto>> GetAllAsync(PagedCarMakeResultRequestDto input)
        {
            CheckGetAllPermission();

            var query = CreateFilteredQuery(input);
            var totalCount = await AsyncQueryableExecuter.CountAsync(query);

            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);

            var entities = Query(query);
            
            return new PagedResultDto<CarMakeDto>(
                totalCount,
                entities.ToList()
            );
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