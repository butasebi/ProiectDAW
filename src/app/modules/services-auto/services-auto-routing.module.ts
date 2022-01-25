import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppRoutingModule } from 'src/app/app-routing.module';
import { ClientsComponent } from '../clients/clients/clients.component';
import { EmployeesComponent } from '../employees/employees/employees.component';
import { ServiceautoComponent } from './serviceauto/serviceauto.component';
import { ServicesautoComponent } from './servicesauto/servicesauto.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'servicesauto'
  },
  {
    path: 'servicesauto',
    component: ServicesautoComponent
  },
  {
    path: 'service/:id',
    component: ServiceautoComponent
  },
  {
    path: 'employees/:id',
    component: EmployeesComponent
  },
  {
    path: 'clients/:id',
    component: ClientsComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ServicesAutoRoutingModule { }
