import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {DataTableModule} from 'angular2-datatable';
import {HttpClientModule} from '@angular/common/http';
import { CreatePowerBiAccountRoutingModule } from './powerbi-createpowerbiaccount-routing.module';
import { PowerbiCreatepowerbiaccountComponent } from './powerbi-createpowerbiaccount.component';
import {SharedModule} from '../../../shared/shared.module';
import { PowerbiServiceService } from '../powerbi-Services/powerbi-service.service';

@NgModule({
  imports: [
    CommonModule,
    CreatePowerBiAccountRoutingModule,
    SharedModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    DataTableModule
  ],
  declarations: [PowerbiCreatepowerbiaccountComponent],
  providers: [PowerbiServiceService]

})
export class CreatePowerBiAccountModule { }




