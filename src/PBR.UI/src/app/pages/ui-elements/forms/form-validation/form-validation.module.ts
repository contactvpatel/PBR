import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FormValidationRoutingModule } from './form-validation-routing.module';
import { FormValidationComponent } from './form-validation.component';
import {SharedModule} from '../../../../shared/shared.module';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    FormValidationRoutingModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule
  ],
  declarations: [FormValidationComponent]
})
export class FormValidationModule { }
