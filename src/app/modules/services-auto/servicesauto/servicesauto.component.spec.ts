import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ServicesautoComponent } from './servicesauto.component';

describe('ServicesautoComponent', () => {
  let component: ServicesautoComponent;
  let fixture: ComponentFixture<ServicesautoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ServicesautoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ServicesautoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
