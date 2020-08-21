import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {FormsModule} from '@angular/forms';
import {DataTableModule} from 'angular2-datatable';
import {HttpClientModule} from '@angular/common/http';

import { PowerBiAccountRoutingModule } from './powerbi-account-routing.module';
import { PowerbiAccountComponent } from './powerbi-account.component';
import {SharedModule} from '../../../shared/shared.module';
import { PowerbiServiceService } from '../powerbi-Services/powerbi-service.service';

@NgModule({
  imports: [
    CommonModule,
    PowerBiAccountRoutingModule,
    SharedModule,
    FormsModule,
    HttpClientModule,
    DataTableModule
  ],
  declarations: [PowerbiAccountComponent],
  providers: [PowerbiServiceService]
})
export class PowerBiAccountModule { }




