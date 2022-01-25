import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ServiceautoComponent } from './serviceauto.component';

describe('ServiceautoComponent', () => {
  let component: ServiceautoComponent;
  let fixture: ComponentFixture<ServiceautoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ServiceautoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ServiceautoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
