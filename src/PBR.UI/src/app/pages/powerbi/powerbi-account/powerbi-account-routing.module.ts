import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {PowerbiAccountComponent} from './powerbi-account.component';

const routes: Routes = [
  {
    path: '',
    component: PowerbiAccountComponent,
    data: {
      breadcrumb: 'PowerBiAccountManage',
      icon: 'icofont-map bg-c-pink',
      breadcrumb_caption: 'PowerBiAccountManage',
      status: true
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PowerBiAccountRoutingModule { }
