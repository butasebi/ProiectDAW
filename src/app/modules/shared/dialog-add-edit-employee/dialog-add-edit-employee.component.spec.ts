import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogAddEditEmployeeComponent } from './dialog-add-edit-employee.component';

describe('DialogAddEditEmployeeComponent', () => {
  let component: DialogAddEditEmployeeComponent;
  let fixture: ComponentFixture<DialogAddEditEmployeeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DialogAddEditEmployeeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogAddEditEmployeeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
