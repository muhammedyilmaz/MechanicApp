import { Component, Injector, OnInit, ViewChild } from '@angular/core';
import { finalize } from 'rxjs/operators';
import * as _ from 'lodash';
import { AppComponentBase } from '@shared/app-component-base';
import {
  RoleServiceProxy,
  GetRoleForEditOutput,
  RoleDto
} from '@shared/service-proxies/service-proxies';
import { ActivatedRoute, Router } from '@angular/router';
import { PermissionTreeComponent } from '@shared/components/permission-tree.component';

@Component({
  templateUrl: 'edit-role-dialog.component.html',
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
export class EditRoleDialogComponent extends AppComponentBase
  implements OnInit {
  @ViewChild('permissionTree', { static: false })
  permissionTree: PermissionTreeComponent;

  saving = false;
  role: RoleDto = new RoleDto();
  id: number;
  editTitle: any;

  constructor(
    injector: Injector,
    private _roleService: RoleServiceProxy,
    private activeRoute: ActivatedRoute,
    private _router: Router
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this.activeRoute.params.subscribe(routeParams => {
      this.id = routeParams.id;
      this.action = this.activeRoute.snapshot.url[1].path;
        this._roleService
        .getRoleForEdit(this.id)
        .subscribe((result: GetRoleForEditOutput) => {
          this.role.init(result.role);
          this.editTitle = this.role.name;
          this.permissionTree.editData = result;
        }); 
    });
  }

  save(event: string): void {
    this.saving = true;
    this.role.grantedPermissions = this.permissionTree.getGrantedPermissionNames();

    this._roleService
      .update(this.role)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      )
      .subscribe(() => {
        this.notify.info(this.l('SavedSuccessfully'));
        if (event == 'Save') {
          this.close();
        }
      });
  }

  delete(): void {
    abp.message.confirm(
      this.l('RoleDeleteWarningMessage', this.editTitle),
      undefined,
      (result: boolean) => {
        if (result) {
          this._roleService.delete(this.id).subscribe(() => {
            abp.notify.success(this.l('SuccessfullyDeleted'));
            this.close();
          });
        }
      }
    );
  }

  close(): void {
    this._router.navigate(['/app/roles']);
  }
}
