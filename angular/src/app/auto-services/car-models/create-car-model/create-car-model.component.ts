import { Component, Injector, OnInit, Input } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { AppComponentBase } from '@shared/app-component-base';
import { CreateCarModelDto, CarModelServiceProxy } from '@shared/service-proxies/service-proxies';
import { Router } from '@angular/router';

@Component({
  selector:"app-create-car-model",
  templateUrl: 'create-car-model.component.html',
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
export class CreateCarModelComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  carModel: CreateCarModelDto = new CreateCarModelDto();
  @Input() carMakeId: number = 0;
  
  constructor(
    injector: Injector,
    public _carModelService: CarModelServiceProxy,
    private _router:Router
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this.carModel.carMakeId =this.carMakeId; 
  }

  save(event: string): void {

    this.saving = true;
    this._carModelService
      .create(this.carModel)
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
          this._router.navigate(['/app/car-models/edit', d.id]);
        }
        else if(event == "SaveAndNew"){

          this.carModel = new CreateCarModelDto();
        }
      });
  }

  close(): void {
    this._router.navigate(['/app/car-models']);
  }
}
