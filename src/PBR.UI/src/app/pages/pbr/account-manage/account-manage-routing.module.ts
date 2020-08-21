import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AccountManageComponent } from './account-manage.component';

const routes: Routes = [
  {
    path: '',
    component: AccountManageComponent,
    data: {
      breadcrumb: 'Power-Bi Account Manage',
      icon: 'icofont-chart-bar-graph bg-c-blue',
      breadcrumb_caption: 'Lorem Ipsum Dolor Sit Amet, Consectetur Adipisicing Elit - Account Manage',
      status: true
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AccountManageRoutingModule { }