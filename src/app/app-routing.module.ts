import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeesModule } from 'src/app/modules/employees/employees.module';
import { ClientsModule } from 'src/app/modules/clients/clients.module';
import { LoginComponent } from './modules/authentication/login/login.component';
import { RegisterComponent } from './modules/authentication/register/register.component';
import { AuthGuardGuard } from './auth-guard.guard';

const routes: Routes = [
  {
    path: '',
    loadChildren: () => import('src/app/modules/services-auto/services-auto.module').then(m => m.ServicesAutoModule),
    canActivate: [AuthGuardGuard]
  },
  {
    path: 'employees/:id',
    loadChildren: () => import('src/app/modules/employees/employees.module').then(m => EmployeesModule)
  },
  {
    path: 'clients/:id',
    loadChildren: () => import('src/app/modules/clients/clients.module').then(m => ClientsModule)
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'register',
    component: RegisterComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
