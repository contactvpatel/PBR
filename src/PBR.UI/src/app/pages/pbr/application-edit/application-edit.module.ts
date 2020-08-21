import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { ApplicationEditRoutingModule } from './application-edit-routing.module';
import { ApplicationEditComponent } from './application-edit.component';
import {SharedModule} from '../../../shared/shared.module';

@NgModule({
  imports: [
    CommonModule,
    ApplicationEditRoutingModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule,
    ],
  declarations: [ApplicationEditComponent]
})
export class ApplicationEditModule { }
