import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AccountManageEditComponent } from './account-manage-edit.component';

const routes: Routes = [
  {
    path: '',
    component: AccountManageEditComponent,
    data: {
      breadcrumb: 'Power-Bi Account Manage Edit',
      icon: 'icofont-chart-bar-graph bg-c-blue',
      breadcrumb_caption: 'Lorem Ipsum Dolor Sit Amet, Consectetur Adipisicing Elit - Account Manage Edit',
      status: true
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AccountManageEditRoutingModule { }