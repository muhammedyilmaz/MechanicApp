import { Component, Injector, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material';
import { finalize } from 'rxjs/operators';
import { appModuleAnimation } from '@shared/animations/routerTransition';

import {
    RoleServiceProxy,
    RoleDto
} from '@shared/service-proxies/service-proxies';
import { LazyLoadEvent } from "primeng/components/common/lazyloadevent";
import { Paginator } from "primeng/components/paginator/paginator";
import { Table } from "primeng/components/table/table";
import { AppComponentBase } from "@shared/app-component-base";
import { Router } from "@angular/router";



@Component({
    templateUrl: './roles.component.html',
    animations: [appModuleAnimation()],
    styles: [
        `
          mat-form-field {
            padding: 10px;
          }
        `
    ]
})
export class RolesComponent extends AppComponentBase {
    @ViewChild("dataTable", { static: true }) dataTable: Table;
    @ViewChild("paginator", { static: true }) paginator: Paginator;


    keyword = "";
    isActive: boolean | null;
    roles: RoleDto[] = [];

    constructor(
        injector: Injector,
        private _rolesService: RoleServiceProxy,
        private _router:Router
    ) {
        super(injector);
    }
    
    getRoleList(event?: LazyLoadEvent) {
        if (this.primengTableHelper.shouldResetPaging(event)) {
          this.paginator.changePage(0);
    
          return;
        }
    
        this.primengTableHelper.showLoadingIndicator();
    
        this._rolesService
          .getAll(
            this.keyword,
            this.isActive,
            this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getSkipCount(this.paginator, event),
            this.primengTableHelper.getMaxResultCount(this.paginator, event)
          )
          .pipe(
            finalize(() => {
              this.primengTableHelper.hideLoadingIndicator();
              // this.selectedUsers = [];
            })
          )
          .subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
          });
      }

      reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
      }

      onRowDblClick(rowData) {
        if(this.isGranted('Role.Edit')){
          this._router.navigate(['/app/roles/edit', rowData.id]);
        }
        else if (this.isGranted('Role.View')){
          this._router.navigate(['/app/roles/view', rowData.id]);
        }
        }
    
        protected delete(): void {
          let ids =new Array<number>();
          this.roles.map(role=>{
            ids.push(role.id);
          });
          
          abp.message.confirm(
            this.l("RoleDeleteWarningMessage","Seçili"),
            undefined,
            (result: boolean) => {
              if (result) {
                this._rolesService.bulkDelete(ids).subscribe(()=>{
                  abp.notify.success(this.l("SuccessfullyDeleted"));
                  this.reloadPage();
                  this.roles = [];
                })
              }
            }
          );
        }

   
}
