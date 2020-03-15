import { Component, Injector, ViewChild, OnInit, Input } from "@angular/core";
import { finalize } from "rxjs/operators";
import { appModuleAnimation } from "@shared/animations/routerTransition";
import { CarModelDto, CarModelServiceProxy, UserServiceProxy } from "@shared/service-proxies/service-proxies";
import { LazyLoadEvent } from "primeng/components/common/lazyloadevent";
import { Paginator } from "primeng/components/paginator/paginator";
import { Table } from "primeng/components/table/table";
import { AppComponentBase } from "@shared/app-component-base";
import { Router } from "@angular/router";

@Component({
  selector:"app-car-models",
  templateUrl: "./car-models.component.html",
  animations: [appModuleAnimation()],
  styles: [
    `
      mat-form-field {
        padding: 10px;
      }
    `
  ]
})
export class CarModelsComponent extends AppComponentBase
implements OnInit {
  @ViewChild("dataTable", { static: true }) dataTable: Table;
  @ViewChild("paginator", { static: true }) paginator: Paginator;

  keyword = "";
  isActive: boolean | null;
  selectedCarModels: CarModelDto[] = [];
  users : any;
  creatorUserIds: number[] = [];
  lastModifierUserIds: number[] = [];
  tableHeight = "calc(100vh - 282px)";
  @Input() childView: boolean = false;
  @Input() carMakeId: number = 0;
  
  constructor(
    injector: Injector,
    private _carModelService: CarModelServiceProxy,
    private _router:Router,
    public _userService: UserServiceProxy
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._userService.getSelectListItemUsers().subscribe(result => {
      this.users = result.items;
    });

    if (this.childView) {
      this.tableHeight = "calc(100vh - 438px)";
    }
  }

  getCarModels(event?: LazyLoadEvent) {
    if (this.primengTableHelper.shouldResetPaging(event)) {
      this.paginator.changePage(0);

      return;
    }

    this.primengTableHelper.showLoadingIndicator();
    console.log("creatorUserId",this.creatorUserIds);
    this._carModelService
      .getAll(
        this.keyword,
        this.carMakeId,
        this.creatorUserIds,
        this.lastModifierUserIds,
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
  if(this.isGranted('CarModel.Edit')){
    this._router.navigate(['/app/car-models/edit', rowData.id]);
  }
  else if (this.isGranted('CarModel.View')){
    this._router.navigate(['/app/car-models/view', rowData.id]);
  }
  }

  protected delete(): void {
    let ids =new Array<number>();
    
    this.selectedCarModels.map(carModel=>{
      ids.push(carModel.id);
    });
    abp.message.confirm(
      this.l("CarModelDeleteWarningMessage","Seçili"),
      undefined,
      (result: boolean) => {
        if (result) {
          this._carModelService.bulkDelete(ids).subscribe(()=>{
            abp.notify.success(this.l("SuccessfullyDeleted"));
            this.reloadPage();
            this.selectedCarModels = [];
          })
        }
      }
    );
  }
}
