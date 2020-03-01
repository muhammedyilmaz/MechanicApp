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
using MyProject.AutoService.Parts.Dto;

namespace MyProject.AutoService.Parts
{
    public class PartAppService : AsyncCrudAppService<Part, PartDto, int, PagedPartResultRequestDto, CreatePartDto, UpdatePartDto>, IPartAppService
    {
        private readonly IRepository<Part, int> _repository;
        public PartAppService(IRepository<Part, int> repository) : base(repository)
        {
            _repository = repository;
        }

        [AbpAuthorize(PermissionNames.Part_Edit)]
        public override Task<PartDto> UpdateAsync(UpdatePartDto input)
        {
            return base.UpdateAsync(input);
        }

        [AbpAuthorize(PermissionNames.Part_Create)]
        public override async Task<PartDto> CreateAsync(CreatePartDto input)
        {
            return await base.CreateAsync(input);
        }

        protected override IQueryable<Part> CreateFilteredQuery(PagedPartResultRequestDto input)
        {
            return Repository.GetAllIncluding()
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Keyword) || x.Sku.Contains(input.Keyword) || x.Barcode.Contains(input.Keyword))
                .WhereIf(!input.Name.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Name))
                .WhereIf(!input.Sku.IsNullOrWhiteSpace(), x => x.Sku.Contains(input.Sku))
                .WhereIf(!input.Barcode.IsNullOrWhiteSpace(), x => x.Barcode.Contains(input.Barcode))
                .WhereIf(!input.StockQuantity.Equals(0), x => x.StockQuantity == input.StockQuantity)
                .WhereIf(!input.CriticalStockLevel.Equals(0), x => x.CriticalStockLevel == input.CriticalStockLevel)
                .WhereIf(!input.InventoryTracking.Equals(0), x => x.InventoryTracking == input.InventoryTracking)
                .WhereIf(input.CriticalStock, x => x.CriticalStock == input.CriticalStock)
                .WhereIf(!input.PurchaseAmountExcludingTaxes.Equals(0), x => x.PurchaseAmountExcludingTaxes == input.PurchaseAmountExcludingTaxes)
                .WhereIf(!input.SalesAmountExcludingTaxes.Equals(0), x => x.SalesAmountExcludingTaxes == input.SalesAmountExcludingTaxes)
                .WhereIf(!input.Vat.Equals(0), x => x.Vat == input.Vat)
                .WhereIf(!input.PurchaseAmountIncludingTaxes.Equals(0), x => x.PurchaseAmountIncludingTaxes == input.PurchaseAmountIncludingTaxes)
                .WhereIf(!input.SalesAmountIncludingTaxes.Equals(0), x => x.SalesAmountIncludingTaxes == input.SalesAmountIncludingTaxes); ;
        }

        [AbpAuthorize(PermissionNames.Part_List)]
        public override Task<PagedResultDto<PartDto>> GetAllAsync(PagedPartResultRequestDto input)
        {
            return base.GetAllAsync(input);
        }

        [AbpAuthorize(PermissionNames.Part_Delete)]
        public override async Task DeleteAsync(EntityDto<int> input)
        {
            CheckDeletePermission();

            var part = await _repository.GetAsync(input.Id);
            await _repository.DeleteAsync(part);
        }

        [AbpAuthorize(PermissionNames.Part_Delete)]
        public async Task BulkDeleteAsync(List<int> ids)
        {
            foreach (var id in ids)
            {
                var part = await _repository.GetAsync(id);
                await _repository.DeleteAsync(part);
            }
        }
    }

}