import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DepartmentEditComponent } from './department-edit.component';

const routes: Routes = [
  {
    path: '',
    component: DepartmentEditComponent,
    data: {
      breadcrumb: 'Power-Bi Department Manage Edit',
      icon: 'icofont-chart-bar-graph bg-c-blue',
      breadcrumb_caption: 'Lorem Ipsum Dolor Sit Amet, Consectetur Adipisicing Elit - Department Manage Edit',
      status: true
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DepartmentEditRoutingModule { }