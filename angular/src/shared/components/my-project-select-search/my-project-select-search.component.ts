import {
  Component,
  OnInit,
  Input,
  EventEmitter,
  Output,
  Injector,
  forwardRef
} from '@angular/core';
import {
  FormControl,
  NG_VALUE_ACCESSOR,
  ControlValueAccessor
} from '@angular/forms';
 

import * as _ from 'lodash';
import { AppComponentBase } from '@shared/app-component-base';

export const APP_SELECT_SEARCH_VALUE_ACCESSOR: any = {
  provide: NG_VALUE_ACCESSOR,
  useExisting: forwardRef(() => MyProjectSelectSearchComponent),
  multi: true
};

@Component({
  selector: 'app-my-project-select-search',
  templateUrl: './my-project-select-search.component.html' ,
  providers: [APP_SELECT_SEARCH_VALUE_ACCESSOR]
})
export class MyProjectSelectSearchComponent extends AppComponentBase 
  implements OnInit, ControlValueAccessor {
  data: any;
  onChange: (value: any) => void;
  filterCtrl: FormControl = new FormControl();
  filteredOptions: any[];

  @Input()
  placeholder: string;

  @Input()
  showAllOption: boolean = false;

  @Input()
  required: boolean = false;

  @Input()
  disabled: boolean = false;

  @Input()
  multiSelect: boolean = false;

  @Input()
  addAllOption: boolean = false;

  @Input()
  cName: any;

  @Input()
  emptyItem: boolean = true;

  @Input()
  emptyItemText: string = "Choose";

  @Input()
  allOptionText: string = 'All';

  private _options: any[];
  @Input() set options(options: any[]) {
    this._options = options == undefined || options === null ? [] : options;

    _.remove(this._options, function (currentObject) {
      return currentObject.value === 0;
    });

    if (this.showAllOption) {
      this._options.unshift({ value: 0, text: this.l(this.allOptionText) });
    }

    this.filterOptions();
  }
  get options(): any[] {
    return this._options;
  }

  @Output() onSelectionChange: EventEmitter<any> = new EventEmitter<any>();

  constructor(injector: Injector) {
    super(injector);
  }

  ngOnInit() {
    this.filterCtrl.valueChanges.subscribe(() => {
      this.filterOptions();
    });
  }

  onChangeSelection($event: any) {
    this.onSelectionChange.emit($event);
    this.onChange(this.data);
  }

  openedChange($event: any) {
    if ($event == false) {
      if (this.data == undefined) {
        this.onChange(undefined);
      }
    }
  }

  private filterOptions() { 
    if (!this.options) {
      return;
    }
    let search = this.filterCtrl.value;
    if (!search) {
      this.filteredOptions = this.options;
      return;
    } else {
      search = search.toLowerCase();
    } 
    // filter the options
    this.filteredOptions = this.options.filter(
      option => 
        option.text.toLowerCase().indexOf(search) > -1 ||
        StringHelper.turkishToLower(option.text).indexOf(search) > -1
    );
  }

  // Begin - ControlValueAccessor implementation
  writeValue(obj: any): void {
    this.data = obj;
  }
  registerOnChange(fn: any): void {
    this.onChange = fn;
  }
  registerOnTouched(fn: any): void {
    // todo;
  }
  setDisabledState?(isDisabled: boolean): void {
    // todo;
  }
  // End - ControlValueAccessor implementation

  // todo : delete these
  // @Input() ngModelData: any;
  // @Output() ngModelDataChange: EventEmitter<any> = new EventEmitter<any>();
}

export class StringHelper {
  static turkishToUpper(str: string): string {
    var letters = { "i": "İ", "ş": "Ş", "ğ": "Ğ", "ü": "Ü", "ö": "Ö", "ç": "Ç", "ı": "I" };
    str = str.replace(/(([iışğüçö]))+/g, function (letter) { return letters[letter]; })
    return str.toUpperCase();
  }

  static turkishToLower(str: string): string {
    var letters = { "İ": "i", "I": "ı", "Ş": "ş", "Ğ": "ğ", "Ü": "ü", "Ö": "ö", "Ç": "ç" };
    str = str.replace(/(([İIŞĞÜÇÖ]))+/g, function (letter) { return letters[letter]; })
    return str.toLowerCase();
  }
}

