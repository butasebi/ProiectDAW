import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogAddEditServiceComponent } from './dialog-add-edit-service.component';

describe('DialogAddEditServiceComponent', () => {
  let component: DialogAddEditServiceComponent;
  let fixture: ComponentFixture<DialogAddEditServiceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DialogAddEditServiceComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogAddEditServiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
