import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NavbarTopRightComponent } from './navbar-top-right.component';

describe('NavbarTopRightComponent', () => {
  let component: NavbarTopRightComponent;
  let fixture: ComponentFixture<NavbarTopRightComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NavbarTopRightComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NavbarTopRightComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
