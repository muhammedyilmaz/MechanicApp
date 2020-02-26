import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NavbarLanguagesComponent } from './navbar-languages.component';

describe('NavbarLanguagesComponent', () => {
  let component: NavbarLanguagesComponent;
  let fixture: ComponentFixture<NavbarLanguagesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NavbarLanguagesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NavbarLanguagesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
