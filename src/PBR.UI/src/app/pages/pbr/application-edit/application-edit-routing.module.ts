import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ApplicationEditComponent } from './application-edit.component';

const routes: Routes = [
  {
    path: '',
    component: ApplicationEditComponent,
    data: {
      breadcrumb: 'Power-Bi Application Manage Edit',
      icon: 'icofont-chart-bar-graph bg-c-blue',
      breadcrumb_caption: 'Lorem Ipsum Dolor Sit Amet, Consectetur Adipisicing Elit - Application Manage Edit',
      status: true
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ApplicationEditRoutingModule { }