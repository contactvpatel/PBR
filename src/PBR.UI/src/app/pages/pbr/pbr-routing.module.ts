import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {PbrComponent} from './pbr.component';

const routes: Routes = [
  {
    path: '',
    component: PbrComponent,
    children: [
      {
        path: 'manage-account',
        loadChildren: () => import('./account-manage/account-manage.module').then(m => m.AccountManageModule)
      },
      {
        path: 'edit-account',
        loadChildren: () => import('./account-manage-edit/account-manage-edit.module').then(m => m.AccountManageEditModule)
      },
      {
        path: 'manage-application',
        loadChildren: () => import('./application-manage/application-manage.module').then(m => m.ApplicationManageModule)
      },
      {
        path: 'edit-application',
        loadChildren: () => import('./application-edit/application-edit.module').then(m => m.ApplicationEditModule)
      },
      {
        path: 'manage-department',
        loadChildren: () => import('./department-manage/department-manage.module').then(m => m.DepartmentManageModule)
      },
      {
        path: 'edit-department',
        loadChildren: () => import('./department-edit/department-edit.module').then(m => m.DepartmentEditModule)
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PbrRoutingModule { }
