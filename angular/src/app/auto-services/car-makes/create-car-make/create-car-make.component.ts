import { Component, Injector, OnInit } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { AppComponentBase } from '@shared/app-component-base';
import { CreateCarMakeDto, CarMakeServiceProxy } from '@shared/service-proxies/service-proxies';
import { Router } from '@angular/router';

@Component({
  templateUrl: 'create-car-make.component.html',
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
export class CreateCarMakeComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  carMake: CreateCarMakeDto = new CreateCarMakeDto();

  constructor(
    injector: Injector,
    public _carMakeService: CarMakeServiceProxy,
    private _router:Router
  ) {
    super(injector);
  }

  ngOnInit(): void {
  }

  save(event: string): void {

    this.saving = true;
    this._carMakeService
      .create(this.carMake)
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
          this._router.navigate(['/app/car-makes/edit', d.id]);
        }
        else if(event == "SaveAndNew"){

          this.carMake = new CreateCarMakeDto();
        }
      });
  }

  close(): void {
    this._router.navigate(['/app/car-makes']);
  }
}
