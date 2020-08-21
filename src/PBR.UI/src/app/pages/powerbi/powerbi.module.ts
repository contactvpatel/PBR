// import { NgModule } from '@angular/core';
// import { CommonModule } from '@angular/common';

// import { PowerBiRoutingModule } from './powerbi-routing.module';
// import { PowerbiComponent } from './powerbi.component';
// import {SharedModule} from '../../shared/shared.module';
// import {ScrollToModule} from '@nicky-lenaers/ngx-scroll-to';

// @NgModule({
//   imports: [
//     CommonModule,
//     PowerBiRoutingModule,
//     SharedModule,
//     ScrollToModule.forRoot()
//   ],
//   declarations: [PowerbiComponent]
// })
// export class PowerBiModule { }
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PowerBiRoutingModule } from './powerbi-routing.module';
import { PowerbiComponent } from './powerbi.component';
import {SharedModule} from '../../shared/shared.module';

@NgModule({
  imports: [
    CommonModule,
    PowerBiRoutingModule,
    SharedModule
  ],
  declarations: [PowerbiComponent]
})
export class PowerBiModule { }
