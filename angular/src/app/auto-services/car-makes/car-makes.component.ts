import { Component, Injector, ViewChild } from "@angular/core";
import { finalize } from "rxjs/operators";
import { appModuleAnimation } from "@shared/animations/routerTransition";
import { CarMakeDto, CarMakeServiceProxy } from "@shared/service-proxies/service-proxies";
import { LazyLoadEvent } from "primeng/components/common/lazyloadevent";
import { Paginator } from "primeng/components/paginator/paginator";
import { Table } from "primeng/components/table/table";
import { AppComponentBase } from "@shared/app-component-base";
import { Router } from "@angular/router";

@Component({
  templateUrl: "./car-makes.component.html",
  animations: [appModuleAnimation()],
  styles: [
    `
      mat-form-field {
        padding: 10px;
      }
    `
  ]
})
export class CarMakesComponent extends AppComponentBase {
  @ViewChild("dataTable", { static: true }) dataTable: Table;
  @ViewChild("paginator", { static: true }) paginator: Paginator;

  keyword = "";
  isActive: boolean | null;
  selectedCarMakes: CarMakeDto[] = [];
  
  constructor(
    injector: Injector,
    private _carMakeService: CarMakeServiceProxy,
    private _router:Router
  ) {
    super(injector);
  }

  getCarMakes(event?: LazyLoadEvent) {
    if (this.primengTableHelper.shouldResetPaging(event)) {
      this.paginator.changePage(0);

      return;
    }

    this.primengTableHelper.showLoadingIndicator();

    this._carMakeService
      .getAll(
        this.keyword,
        // this.isActive,
        this.primengTableHelper.getSorting(this.dataTable),
        this.primengTableHelper.getSkipCount(this.paginator, event),
        this.primengTableHelper.getMaxResultCount(this.paginator, event)
      )
      .pipe(
        finalize(() => {
          this.primengTableHelper.hideLoadingIndicator();
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
  if(this.isGranted('CarMake.Edit')){
    this._router.navigate(['/app/car-makes/edit', rowData.id]);
  }
  else if (this.isGranted('CarMake.View')){
    this._router.navigate(['/app/car-makes/view', rowData.id]);
  }
  }

  protected delete(): void {
    let ids =new Array<number>();
    
    this.selectedCarMakes.map(carMake=>{
      ids.push(carMake.id);
    });
    abp.message.confirm(
      this.l("CarMakeDeleteWarningMessage","Seçili"),
      undefined,
      (result: boolean) => {
        if (result) {
          this._carMakeService.bulkDelete(ids).subscribe(()=>{
            abp.notify.success(this.l("SuccessfullyDeleted"));
            this.reloadPage();
            this.selectedCarMakes = [];
          })
        }
      }
    );
  }
}
