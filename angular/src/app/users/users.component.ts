import { Component, Injector, ViewChild } from "@angular/core";
import { MatDialog } from "@angular/material";
import { finalize } from "rxjs/operators";
import { appModuleAnimation } from "@shared/animations/routerTransition";
import {
  UserServiceProxy,
  UserDto
} from "@shared/service-proxies/service-proxies";
import { ResetPasswordDialogComponent } from "./reset-password/reset-password.component";
import { LazyLoadEvent } from "primeng/components/common/lazyloadevent";
import { Paginator } from "primeng/components/paginator/paginator";
import { Table } from "primeng/components/table/table";
import { AppComponentBase } from "@shared/app-component-base";
import { Router } from "@angular/router";

@Component({
  templateUrl: "./users.component.html",
  animations: [appModuleAnimation()],
  styles: [
    `
      mat-form-field {
        padding: 10px;
      }
    `
  ]
})
export class UsersComponent extends AppComponentBase {
  @ViewChild("dataTable", { static: true }) dataTable: Table;
  @ViewChild("paginator", { static: true }) paginator: Paginator;

  keyword = "";
  isActive: boolean | null;
  selectedUsers: UserDto[] = [];
  
  constructor(
    injector: Injector,
    private _userService: UserServiceProxy,
    private _dialog: MatDialog,
    private _router:Router
  ) {
    super(injector);
  }

  getUsers(event?: LazyLoadEvent) {
    if (this.primengTableHelper.shouldResetPaging(event)) {
      this.paginator.changePage(0);

      return;
    }

    this.primengTableHelper.showLoadingIndicator();

    this._userService
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
  if(this.isGranted('User.Edit')){
    this._router.navigate(['/app/users/edit', rowData.id]);
  }
  else if (this.isGranted('User.View')){
    this._router.navigate(['/app/users/view', rowData.id]);
  }
  }

  public resetPassword(): void {
    this.showResetPasswordUserDialog(this.selectedUsers[0].id);
  }

  protected delete(): void {
    let ids =new Array<number>();
    this.selectedUsers.map(user=>{
      ids.push(user.id);
    });
    
    abp.message.confirm(
      this.l("UserDeleteWarningMessage","Seçili"),
      undefined,
      (result: boolean) => {
        if (result) {
          this._userService.bulkDelete(ids).subscribe(()=>{
            abp.notify.success(this.l("SuccessfullyDeleted"));
            this.reloadPage();
            this.selectedUsers = [];
          })
        }
      }
    );
  }

  private showResetPasswordUserDialog(userId?: number): void {
    this._dialog.open(ResetPasswordDialogComponent, {
      data: userId
    });
  }

}
