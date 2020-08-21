import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DashboardPowerbiRoutingModule } from './dashboard-powerbi-routing.module';
import { DashboardPowerbiComponent  } from './dashboard-powerbi.component';
import {ShadowCss} from '@angular/compiler/src/shadow_css';
import {SharedModule} from '../../../shared/shared.module';

@NgModule({
  imports: [
    CommonModule,
    DashboardPowerbiRoutingModule,
    SharedModule
  ],
  declarations: [DashboardPowerbiComponent]
})
export class DashboardPowerBiModule { }
