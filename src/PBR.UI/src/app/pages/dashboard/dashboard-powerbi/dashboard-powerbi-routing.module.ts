import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {DashboardPowerbiComponent} from './dashboard-powerbi.component';

const routes: Routes = [
  {
    path: '',
    component: DashboardPowerbiComponent,
    data: {
      breadcrumb: 'Ecommerce',
      icon: 'icofont-home bg-c-blue',
      status: false
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DashboardPowerbiRoutingModule { }
