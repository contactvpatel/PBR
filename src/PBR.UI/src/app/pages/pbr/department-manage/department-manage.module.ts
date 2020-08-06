import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { DepartmentManageRoutingModule } from './department-manage-routing.module';
import { DepartmentManageComponent } from './department-manage.component';
import {SharedModule} from '../../../shared/shared.module';
import {DataTableModule} from 'angular2-datatable';
import {HttpClientModule} from '@angular/common/http';


@NgModule({
  imports: [
    CommonModule,
    DepartmentManageRoutingModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule,
    DataTableModule,
    HttpClientModule
    ],
  declarations: [DepartmentManageComponent]
})
export class DepartmentManageModule { }
