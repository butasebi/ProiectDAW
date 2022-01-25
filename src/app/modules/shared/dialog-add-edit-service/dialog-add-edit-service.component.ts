import { Component, Inject, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ServicesautoService } from 'src/app/services/servicesauto.service';

@Component({
  selector: 'app-dialog-add-edit-service',
  templateUrl: './dialog-add-edit-service.component.html',
  styleUrls: ['./dialog-add-edit-service.component.css']
})
export class DialogAddEditServiceComponent implements OnInit {

  public doweadd: boolean
  public title: string
  public servicesForm: FormGroup = new FormGroup({
    id: new FormControl(0),
    name: new FormControl('')
  });
  constructor(
    @Inject(MAT_DIALOG_DATA) public data,
    public dialogRef: MatDialogRef<DialogAddEditServiceComponent>,
    private servicesautoService: ServicesautoService
  ) { 
    console.log(this.data);
    if(this.data.Service_Auto){
      this.title = 'Edit service'
      this.servicesForm.patchValue(this.data.Service_Auto);
      this.doweadd = false
    }
    else {
      this.title = 'Add service'
      this.doweadd = true
    }
  }
  get id(): AbstractControl {
    return this.servicesForm.get('id');
}
get name(): AbstractControl {
  return this.servicesForm.get('name');
}

public closeDialog(): void{
  this.dialogRef.close();
}

public saveDialog(): void{
    
  if(this.doweadd){
    this.servicesautoService.createServiceAuto(this.servicesForm.value).subscribe(() => {
      this.dialogRef.close(this.servicesForm.value);
    })
  }
  else {
    this.servicesautoService.updateServiceAuto(this.servicesForm.value).subscribe(() => {
      this.dialogRef.close(this.servicesForm.value);
    })
  }
}

ngOnInit(): void {
}

}