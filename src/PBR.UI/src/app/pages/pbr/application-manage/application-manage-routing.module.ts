import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ApplicationManageComponent } from './application-manage.component';

const routes: Routes = [
  {
    path: '',
    component: ApplicationManageComponent,
    data: {
      breadcrumb: 'Power-Bi Application Manage',
      icon: 'icofont-chart-bar-graph bg-c-blue',
      breadcrumb_caption: 'Lorem Ipsum Dolor Sit Amet, Consectetur Adipisicing Elit - Application Manage',
      status: true
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ApplicationManageRoutingModule { }