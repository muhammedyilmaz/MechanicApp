import { AppComponentBase } from 'shared/app-component-base';
import { Injector, OnInit } from '@angular/core';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';

export class PagedResultDto {
    items: any[];
    totalCount: number;
}

export class EntityDto {
    id: number;
}

export class PagedRequestDto {
    skipCount: number;
    maxResultCount: number;
}

export abstract class PagedListingComponentBase<TEntityDto> extends AppComponentBase implements OnInit {

    public pageSize = 10;
    public pageNumber = 0;
    public totalPages = 1;
    public totalItems: number;
    public isTableLoading :boolean;
    
    public datasource: TEntityDto[];
    public cols: any[];

    constructor(injector: Injector) {
        super(injector);
    }

    ngOnInit(): void {
        //this.refresh();
    }

    refresh(): void {
        this.getDataPage(this.pageNumber);     
    }

    public showPaging(result: PagedResultDto, pageNumber: number): void {
        this.totalPages = ((result.totalCount - (result.totalCount % this.pageSize)) / this.pageSize) + 1;

        this.totalItems = result.totalCount;
        this.pageNumber = pageNumber;
    }

    public getDataPage(page: number): void {
        debugger;
        const req = new PagedRequestDto();
        req.maxResultCount = this.pageSize;
        //req.skipCount = page * this.pageSize;
        req.skipCount = page;
        setTimeout(() => {
            this.isTableLoading = true;
            this.list(req, page, () => {
                this.isTableLoading = false;
            });

        }, 0);
        
        
    }

    public loadLazyTable(event: LazyLoadEvent): void {
        this.getDataPage(event.first);
    }

    protected abstract list(request: PagedRequestDto, pageNumber: number, finishedCallback: Function): void;
    protected abstract delete(entity: TEntityDto): void;
}
