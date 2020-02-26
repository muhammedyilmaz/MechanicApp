import { Component, Injector,  OnInit } from '@angular/core';
import {
  MatCheckboxChange
} from '@angular/material';
import { finalize } from 'rxjs/operators';
import * as _ from 'lodash';
import { AppComponentBase } from '@shared/app-component-base';
import {Location} from '@angular/common';
import {
  UserServiceProxy,
  UserDto,
  RoleDto
} from '@shared/service-proxies/service-proxies';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  templateUrl: './edit-user-dialog.component.html',
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
export class EditUserDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  user: UserDto = new UserDto();
  roles: RoleDto[] = [];
  checkedRolesMap: { [key: string]: boolean } = {};
  id: number;
  editTitle : any;
  
  constructor(
    injector: Injector,
    public _userService: UserServiceProxy,
    private activeRoute:ActivatedRoute,
    private _location : Location,
    private _router:Router
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this.activeRoute.params.subscribe(routeParams => {
      this.id = routeParams.id;
      this.action = this.activeRoute.snapshot.url[1].path;
      this._userService.get(this.id).subscribe(result => {
        this.user = result;
        this.editTitle= this.user.fullName;
  
        this._userService.getRoles().subscribe(result2 => {
          this.roles = result2.items;
          this.setInitialRolesStatus();
        });
      });
    });
  }

  setInitialRolesStatus(): void {
    _.map(this.roles, item => {
      this.checkedRolesMap[item.normalizedName] = this.isRoleChecked(
        item.normalizedName
      );
    });
  }

  isRoleChecked(normalizedName: string): boolean {
    return _.includes(this.user.roleNames, normalizedName);
  }

  onRoleChange(role: RoleDto, $event: MatCheckboxChange) {
    this.checkedRolesMap[role.normalizedName] = $event.checked;
  }

  getCheckedRoles(): string[] {
    const roles: string[] = [];
    _.forEach(this.checkedRolesMap, function(value, key) {
      if (value) {
        roles.push(key);
      }
    });
    return roles;
  }

  save(event: string): void {
    this.saving = true;

    this.user.roleNames = this.getCheckedRoles();

    this._userService
      .update(this.user)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      )
      .subscribe(() => {
        this.notify.info(this.l('SavedSuccessfully'));
        if(event == "Save"){
          this.close();
        }
      });
  }
  protected delete(): void {

    abp.message.confirm(
      this.l("UserDeleteWarningMessage", this.editTitle),
      undefined,
      (result: boolean) => {
        if (result) {
          this._userService.delete(this.id).subscribe(()=>{
            abp.notify.success(this.l("SuccessfullyDeleted"));
            this.close();
          })
        }
      }
    );
  }

  close(): void {
    this._router.navigate(['/app/users']);
  }
}
