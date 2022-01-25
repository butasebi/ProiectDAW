import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { Employee } from 'src/app/interfaces/employee';
import { EmployeesService } from 'src/app/services/employees.service';
import { DialogAddEditEmployeeComponent } from '../../shared/dialog-add-edit-employee/dialog-add-edit-employee.component';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css']
})
export class EmployeesComponent implements OnInit {

  public employees: Employee [];
  public displayedColumns: string[] = ['id', 'firstname', 'lastname', 'position', 'edit', 'delete'];

  public id: string;
  private sub: any;
  
  public blank: Employee = {
    id: "",
    firstName: "",
    lastName: "",
    position: "",
    Service_AutoId: ""
  };

  constructor(
    private route: ActivatedRoute,
    private employeesService: EmployeesService,
    private router: Router,
    private dialog: MatDialog
  ) { }
  ngOnInit(): void {
    this.sub = this.route.params.subscribe(params => {
      this.id = params['id'];
      console.log(this.id);
      if (this.id){
        this.getEmployees(this.id);
      }
      this.blank.Service_AutoId = this.id;
  });
}

  public getEmployees(id): void{
    this.employeesService.getEmployees(id).subscribe((result: Employee[]) => {
      console.log(result);  
      this.employees = result;
      this.employees.forEach(elem => {
        elem.Service_AutoId = id;
      })
    });
  }

  public addData(employee): void{
    const data = {
      Employee: employee
    };
    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = '550px';
    dialogConfig.height = '700px';
    dialogConfig.data = data;
    const dialogRef = this.dialog.open(DialogAddEditEmployeeComponent, dialogConfig);
    dialogRef.afterClosed().subscribe((result) => {
      if(result){
        this.getEmployees(this.id);
      }
    })
  }
  public editEmployee(employee): void{
    this.addData(employee)
 }

 public deleteEmployee(employee): void {
   console.log(employee);
  this.employeesService.deleteEmployee(employee).subscribe((result) => {
  })
  this.getEmployees(this.id);
}
}
