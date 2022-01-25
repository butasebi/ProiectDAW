import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ServiceAuto } from 'src/app/interfaces/service-auto';
import { ServicesautoService } from 'src/app/services/servicesauto.service';

@Component({
  selector: 'app-serviceauto',
  templateUrl: './serviceauto.component.html',
  styleUrls: ['./serviceauto.component.css']
})
export class ServiceautoComponent implements OnInit, OnDestroy {

  public serviceauto: ServiceAuto;

  public id: string;
  private sub: any;
  constructor(
    private route: ActivatedRoute,
    private servicesautoService: ServicesautoService,
    private router: Router
  ) { }

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      this.id = params['id'];
      console.log(this.id);
      if (this.id){
        this.getService();
      }
    });
  }

  public getService(): void {
    this.servicesautoService.getServiceById(this.id).subscribe(result => {
      console.log(result[0]);
      this.serviceauto = result[0];
    });
  }
  public goToEmployees(): void{
    this.router.navigate(['/employees', this.id]);
  }

  public goToClients(): void{
    this.router.navigate(['/clients', this.id]);
  }

  ngOnDestroy(): void {
      this.sub.unsubscribe();
  }

}
