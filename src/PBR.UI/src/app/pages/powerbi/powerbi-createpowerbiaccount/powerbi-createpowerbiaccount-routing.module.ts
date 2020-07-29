import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {PowerbiCreatepowerbiaccountComponent} from './powerbi-createpowerbiaccount.component';

const routes: Routes = [
  {
    path: '',
    component: PowerbiCreatepowerbiaccountComponent,
    data: {
      breadcrumb: 'CreatePowerBiAccount',
      icon: 'icofont-map bg-c-pink',
      breadcrumb_caption: 'CreatePowerBiAccount',
      status: true
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CreatePowerBiAccountRoutingModule { }
