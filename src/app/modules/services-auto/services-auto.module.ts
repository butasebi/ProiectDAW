import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ServicesAutoRoutingModule } from './services-auto-routing.module';
import { ServicesautoComponent } from './servicesauto/servicesauto.component';
import {MatTableModule} from '@angular/material/table';
import {MatIconModule} from '@angular/material/icon';
import {MatCardModule} from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import { ReactiveFormsModule } from '@angular/forms';
import { ServiceautoComponent } from './serviceauto/serviceauto.component';
import { ProfilePipe } from 'src/app/profile.pipe';
import { LineHoverDirective } from 'src/app/line-hover.directive';

@NgModule({
  declarations: [
    ServicesautoComponent,
    ServiceautoComponent,
    ProfilePipe,
    LineHoverDirective
  ],
  imports: [
    CommonModule,
    ServicesAutoRoutingModule,
    MatTableModule,
    MatIconModule,
    MatCardModule,
    MatButtonModule,
    MatDialogModule,
    ReactiveFormsModule
  ],
  exports: [
    ProfilePipe,
    LineHoverDirective
  ]
})
export class ServicesAutoModule { }
