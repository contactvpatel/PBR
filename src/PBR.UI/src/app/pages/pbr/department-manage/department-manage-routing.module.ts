import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DepartmentManageComponent } from './department-manage.component';

const routes: Routes = [
  {
    path: '',
    component: DepartmentManageComponent,
    data: {
      breadcrumb: 'Power-Bi Department Manage',
      icon: 'icofont-chart-bar-graph bg-c-blue',
      breadcrumb_caption: 'Lorem Ipsum Dolor Sit Amet, Consectetur Adipisicing Elit - Department Manage',
      status: true
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DepartmentManageRoutingModule { }