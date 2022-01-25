import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { ServiceAuto } from 'src/app/interfaces/service-auto';
import { ServicesautoService } from 'src/app/services/servicesauto.service';
import { DialogAddEditServiceComponent } from '../../shared/dialog-add-edit-service/dialog-add-edit-service.component';

@Component({
  selector: 'app-servicesauto',
  templateUrl: './servicesauto.component.html',
  styleUrls: ['./servicesauto.component.css']
})
export class ServicesautoComponent implements OnInit {

  public servicesauto: ServiceAuto [];
  public displayedColumns: string[] = ['id', 'name', 'profile', 'edit', 'delete'];
  constructor(
    private servicesautoService: ServicesautoService,
    private router: Router,
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.getServices();
  }

  public getServices(): void{
    this.servicesautoService.getServices().subscribe((result: ServiceAuto[]) => {
      //console.log(result);  
      this.servicesauto = result;
    });
  }
  public goToServiceProfile(id): void{
    this.router.navigate(['/service', id]);
  }

  public addData(serviceauto?): void{
    const data = {
      Service_Auto: serviceauto
    };
    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = '550px';
    dialogConfig.height = '700px';
    dialogConfig.data = data;
    const dialogRef = this.dialog.open(DialogAddEditServiceComponent, dialogConfig);
    dialogRef.afterClosed().subscribe((result) => {
      if(result){
        this.getServices();
      }
    })
  }
  public editServiceAuto(serviceauto): void{
    this.addData(serviceauto)
 }

 public deleteServiceAuto(serviceauto): void {
   console.log(serviceauto);
  this.servicesautoService.deleteServiceAuto(serviceauto).subscribe((result) => {
  })
  this.getServices();
}
}
