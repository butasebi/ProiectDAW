import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Client } from 'src/app/interfaces/client';
import { ClientsService } from 'src/app/services/clients.service';

@Component({
  selector: 'app-clients',
  templateUrl: './clients.component.html',
  styleUrls: ['./clients.component.css']
})
export class ClientsComponent implements OnInit {

  public clients: Client[];
  public displayedColumns: string[] = ['id', 'firstname', 'lastname', 'registerday'];

  public id: string;
  private sub: any;

  constructor(
    private route: ActivatedRoute,
    private clientsService: ClientsService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.sub = this.route.params.subscribe(params => {
      this.id = params['id'];
      console.log(this.id);
      if (this.id){
        this.getClients(this.id);
      }
  });
}

  public getClients(id): void{
    this.clientsService.getClients(id).subscribe((result: Client[]) => {
      console.log(result);  
      this.clients = result;
    });
  }

}
