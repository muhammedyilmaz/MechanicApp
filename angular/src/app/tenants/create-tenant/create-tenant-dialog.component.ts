import { Component, Injector, OnInit } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { AppComponentBase } from '@shared/app-component-base';
import {
  CreateTenantDto,
  TenantServiceProxy
} from '@shared/service-proxies/service-proxies';
import { Router } from '@angular/router';

@Component({
  templateUrl: 'create-tenant-dialog.component.html',
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
export class CreateTenantDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  tenant: CreateTenantDto = new CreateTenantDto();

  constructor(
    injector: Injector,
    public _tenantService: TenantServiceProxy,
    private _router:Router
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this.tenant.isActive = true;
  }

  save(event: string): void {

    this.saving = true;
    this._tenantService
      .create(this.tenant)
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
          this._router.navigate(['/app/tenants/edit', d.id]);
        }
        else if(event == "SaveAndNew"){

          this.tenant = new CreateTenantDto();
          this.tenant.isActive = true;
        }
      });
  }

  close(): void {
    this._router.navigate(['/app/tenants']);
  }
}
