import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { DepartmentEditRoutingModule } from './department-edit-routing.module';
import { DepartmentEditComponent } from './department-edit.component';
import {SharedModule} from '../../../shared/shared.module';

@NgModule({
  imports: [
    CommonModule,
    DepartmentEditRoutingModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule,
    ],
  declarations: [DepartmentEditComponent]
})
export class DepartmentEditModule { }
