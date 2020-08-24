import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SummaryComponent } from './summary/summary.component';
import { DetailComponent } from './detail/detail.component';
import { AccountsResolver } from './resolver/accounts.resolver';
import { AccountEditResolver } from './resolver/account-edit.resolver';

const routes: Routes = [
  { path: '', redirectTo: 'manage' },
  {
    path: 'manage',
    component: SummaryComponent,
    resolve: { accounts: AccountsResolver },
    data: {
      breadcrumb: 'Power-Bi Account',
      icon: 'icofont-chart-bar-graph bg-c-blue',
       status: true,
    },
  },

  {
    path: 'edit/:id',
    component: DetailComponent,
    resolve: { account: AccountEditResolver },
    data: {
      breadcrumb: 'Power-Bi Account',
      icon: 'icofont-chart-bar-graph bg-c-blue',
      
      status: true,
      isEdit: true
    },
  },

  {
    path: 'create',
    component: DetailComponent,
    data: {
      breadcrumb: 'Power-Bi Account',
      icon: 'icofont-chart-bar-graph bg-c-blue',
      
      status: true,
      isEdit: false
    },
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AccountRoutingModule {}
