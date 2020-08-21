import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { ApplicationManageRoutingModule } from './application-manage-routing.module';
import { ApplicationManageComponent } from './application-manage.component';
import {SharedModule} from '../../../shared/shared.module';
import {DataTableModule} from 'angular2-datatable';
import {HttpClientModule} from '@angular/common/http';

@NgModule({
  imports: [
    CommonModule,
    ApplicationManageRoutingModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule,
    DataTableModule,
    HttpClientModule
    ],
  declarations: [ApplicationManageComponent]
})
export class ApplicationManageModule { }
