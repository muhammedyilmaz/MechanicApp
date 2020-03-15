import { Component, Injector, OnInit, Inject, Optional } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { finalize } from 'rxjs/operators';
import { AppComponentBase } from '@shared/app-component-base';
import { CarModelDto, CarModelServiceProxy } from '@shared/service-proxies/service-proxies';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  templateUrl: 'edit-car-model.component.html',
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
export class EditCarModelComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  carModel: CarModelDto = new CarModelDto();
  id: number;
  editTitle: any;

  constructor(
    injector: Injector,
    public _carModelService: CarModelServiceProxy,
    private activeRoute:ActivatedRoute,
    private _router: Router
  ) {
    super(injector);
  }

  ngOnInit(): void {
   
    this.activeRoute.params.subscribe(routeParams => {
      this.id = routeParams.id;
      this.action = this.activeRoute.snapshot.url[1].path;
      this._carModelService.get(this.id).subscribe((result: CarModelDto) => {
        this.carModel = result;
        this.editTitle= this.carModel.name;
      });
    });

  }

  save(event: string): void {
    this.saving = true;

    this._carModelService
      .update(this.carModel)
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
      this.l("CarModelDeleteWarningMessage", this.editTitle),
      undefined,
      (result: boolean) => {
        if (result) {
          this._carModelService.delete(this.id).subscribe(()=>{
            abp.notify.success(this.l("SuccessfullyDeleted"));
            this.close();
          })
        }
      }
    );
  }

  close(): void {
    this._router.navigate(['/app/car-models']);
  }
}
