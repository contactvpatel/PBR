import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SummaryComponent } from './summary/summary.component';
import { DetailComponent } from './detail/detail.component';
import { DepartmentResolver } from './resolver/department.resolver';
import { DepartmentEditResolver } from './resolver/department-edit.resolver';

const routes: Routes = [
  { path: '', redirectTo: 'manage' },
  {
    path: 'manage',
    component: SummaryComponent,
    resolve: { department: DepartmentResolver },
    data: {
      breadcrumb: 'Power-Bi Department',
      icon: 'icofont-chart-bar-graph bg-c-blue',
      status: true
    }
  },
  {
    path: 'edit/:id',
    component: DetailComponent,
    resolve: { department: DepartmentEditResolver },
    data: {
      breadcrumb: 'Power-Bi Application',
      icon: 'icofont-chart-bar-graph bg-c-blue',
      status: true,
      isEdit: true
    }
  },
  {
    path: 'create',
    component: DetailComponent,
    data: {
      breadcrumb: 'Power-Bi Applications',
      icon: 'icofont-chart-bar-graph bg-c-blue',
      status: true,
      isEdit: false
    }
  }
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DepartmentRoutingModule {}
