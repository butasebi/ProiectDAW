import { Component, Inject, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { EmployeesService } from 'src/app/services/employees.service';

@Component({
  selector: 'app-dialog-add-edit-employee',
  templateUrl: './dialog-add-edit-employee.component.html',
  styleUrls: ['./dialog-add-edit-employee.component.css']
})
export class DialogAddEditEmployeeComponent implements OnInit {

  public doweadd: boolean
  public title: string
  public employeesForm: FormGroup = new FormGroup({
    id: new FormControl(''),
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    position: new FormControl(''),
    Service_AutoId: new FormControl('')
  });
  constructor(
    @Inject(MAT_DIALOG_DATA) public data,
    public dialogRef: MatDialogRef<DialogAddEditEmployeeComponent>,
    private employeesService: EmployeesService
  ) { 
    if(this.data.Employee.id != ""){
      console.log(this.data.Employee);
      this.title = 'Edit employee'
      this.employeesForm.patchValue(this.data.Employee);
      this.doweadd = false
    }
    else {
      this.title = 'Add employee'
      this.doweadd = true
    }
  }
  get id(): AbstractControl {
    return this.employeesForm.get('id');
}
get firstname(): AbstractControl {
  return this.employeesForm.get('firstname');
}
get lastname(): AbstractControl {
  return this.employeesForm.get('lastname');
}
get position(): AbstractControl {
  return this.employeesForm.get('position');
}
get serviceid(): AbstractControl {
  return this.employeesForm.get('Service_AutoId');
}
public closeDialog(): void{
  this.dialogRef.close();
}

public saveDialog(): void{
    
  if(this.doweadd){
    this.employeesService.createEmployee(this.employeesForm.value).subscribe(() => {
      this.dialogRef.close(this.employeesForm.value);
    })
  }
  else {
    this.employeesService.updateEmployee(this.employeesForm.value).subscribe(() => {
      this.dialogRef.close(this.employeesForm.value);
    })
  }
}

ngOnInit(): void {
}

}