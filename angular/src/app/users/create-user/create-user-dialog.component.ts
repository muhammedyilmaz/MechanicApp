import { Component, Injector, OnInit } from '@angular/core';
import { MatDialogRef, MatCheckboxChange } from '@angular/material';
import { finalize } from 'rxjs/operators';
import * as _ from 'lodash';
import { AppComponentBase } from '@shared/app-component-base';
import {Location} from '@angular/common';
import {
  UserServiceProxy,
  CreateUserDto,
  RoleDto
} from '@shared/service-proxies/service-proxies';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  templateUrl: './create-user-dialog.component.html',
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
export class CreateUserDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  user: CreateUserDto = new CreateUserDto();
  roles: RoleDto[] = [];
  checkedRolesMap: { [key: string]: boolean } = {};
  defaultRoleCheckedStatus = false;
  
  constructor(
    injector: Injector,
    public _userService: UserServiceProxy,
    private activeRoute : ActivatedRoute,
    private _location : Location,
    private _router:Router
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this.user.isActive = true;
    this._userService.getRoles().subscribe(result => {
      this.roles = result.items;
      this.setInitialRolesStatus();
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
    // just return default role checked status
    // it's better to use a setting
    return this.defaultRoleCheckedStatus;
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
      .create(this.user)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      ) 
      .subscribe(d => {
        this.notify.info(this.l('SavedSuccessfully'));
        if(event == "Save"){
          this.close();
        }
        else if(event == "SaveAndContunie"){
          this._router.navigate(['/app/users/edit', d.id]);
        }
        else if(event == "SaveAndNew"){

          this.user = new CreateUserDto();
          this.user.isActive = true;
        }
      });
  }

  close(): void {
    this._router.navigate(['/app/users']);
  }

}
