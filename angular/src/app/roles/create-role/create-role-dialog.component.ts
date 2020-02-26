import { Component, Injector, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { finalize } from 'rxjs/operators';
import * as _ from 'lodash';
import {
  RoleServiceProxy,
  RoleDto,
  CreateRoleDto,
  GetRoleForEditOutput
} from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/app-component-base';
import { PermissionTreeComponent } from '@shared/components/permission-tree.component';

@Component({
  templateUrl: 'create-role-dialog.component.html',
  styles: [
    `
      mat-form-field {
        width: 100%;
      }
      mat-checkbox {
        padding-bottom: 5px;
      }
    `
  ]
})
export class CreateRoleDialogComponent extends AppComponentBase
  implements OnInit {
  @ViewChild('permissionTree', { static: false })
  permissionTree: PermissionTreeComponent;

  saving = false;
  role: RoleDto = new RoleDto();

  constructor(
    injector: Injector,
    private _roleService: RoleServiceProxy,
    private _router: Router
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._roleService
      .getRoleForEdit(undefined)
      .subscribe((result: GetRoleForEditOutput) => {
        this.permissionTree.editData = result;
      });
  }

  save(event: string): void {
    this.saving = true;
    this.role.grantedPermissions = this.permissionTree.getGrantedPermissionNames();

    const role_ = new CreateRoleDto();
    role_.init(this.role);

    this._roleService
      .create(role_)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      )
      .subscribe(d => {
        this.notify.info(this.l('SavedSuccessfully'));
        if (event == 'Save') {
          this.close();
        } else if (event == 'SaveAndContunie') {
          this._router.navigate(['/app/roles/edit', d.id]);
        } else if (event == 'SaveAndNew') {
          this.role = new RoleDto();
        }
      });
  }

  close(): void {
    this._router.navigate(['/app/roles']);
  }
}
