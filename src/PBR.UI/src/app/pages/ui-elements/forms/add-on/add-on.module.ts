import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AddOnRoutingModule } from './add-on-routing.module';
import { AddOnComponent } from './add-on.component';
import {SharedModule} from '../../../../shared/shared.module';

@NgModule({
  imports: [
    CommonModule,
    AddOnRoutingModule,
    SharedModule
  ],
  declarations: [AddOnComponent]
})
export class AddOnModule { }
