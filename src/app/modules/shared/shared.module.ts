import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DialogAddEditServiceComponent } from './dialog-add-edit-service/dialog-add-edit-service.component';
import { ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import { DialogAddEditEmployeeComponent } from './dialog-add-edit-employee/dialog-add-edit-employee.component';


@NgModule({
  declarations: [
    DialogAddEditServiceComponent,
    DialogAddEditEmployeeComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule
  ],
  entryComponents:[
    DialogAddEditServiceComponent,
    DialogAddEditEmployeeComponent
  ],
  exports: [
    
  ]
})
export class SharedModule { }
