import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PbrRoutingModule } from './pbr-routing.module';
import { PbrComponent } from './pbr.component';
import {SharedModule} from '../../shared/shared.module';

@NgModule({
  imports: [
    CommonModule,
    PbrRoutingModule,
    SharedModule
  ],
  declarations: [PbrComponent]
})
export class PbrModule { }
