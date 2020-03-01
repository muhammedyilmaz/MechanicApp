import { Component, Injector, OnInit, Inject, Optional } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { finalize } from 'rxjs/operators';
import { AppComponentBase } from '@shared/app-component-base';
import { CarMakeDto, CarMakeServiceProxy } from '@shared/service-proxies/service-proxies';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  templateUrl: 'edit-car-make.component.html',
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
export class EditCarMakeComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  carMake: CarMakeDto = new CarMakeDto();
  id: number;
  editTitle: any;

  constructor(
    injector: Injector,
    public _carMakeService: CarMakeServiceProxy,
    private activeRoute:ActivatedRoute,
    private _router: Router
  ) {
    super(injector);
  }

  ngOnInit(): void {
   
    this.activeRoute.params.subscribe(routeParams => {
      this.id = routeParams.id;
      this.action = this.activeRoute.snapshot.url[1].path;
      this._carMakeService.get(this.id).subscribe((result: CarMakeDto) => {
        this.carMake = result;
        this.editTitle= this.carMake.name;
      });
    });

  }

  save(event: string): void {
    this.saving = true;

    this._carMakeService
      .update(this.carMake)
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
      this.l("CarMakeDeleteWarningMessage", this.editTitle),
      undefined,
      (result: boolean) => {
        if (result) {
          this._carMakeService.delete(this.id).subscribe(()=>{
            abp.notify.success(this.l("SuccessfullyDeleted"));
            this.close();
          })
        }
      }
    );
  }

  close(): void {
    this._router.navigate(['/app/car-makes']);
  }
}
