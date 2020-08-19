import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PbrComponent } from './pbr.component';

const routes: Routes = [
  {
    path: '',
    component: PbrComponent,
    children: [
      {
        path: 'account',
        loadChildren: () =>
          import('./account/account.module').then((m) => m.AccountModule)
      },
      {
        path: 'application',
        loadChildren: () =>
          import('./application/application.module').then(
            (m) => m.ApplicationModule
          )
      },
      {
        path: 'department',
        loadChildren: () =>
          import('./department/department.module').then(
            (m) => m.DepartmentModule
          )
      },
      // {
      //   path: 'edit-application',
      //   loadChildren: () =>
      //     import('./application-edit/application-edit.module').then(
      //       (m) => m.ApplicationEditModule
      //     )
      // },
      {
        path: 'manage-department',
        loadChildren: () =>
          import('./department-manage/department-manage.module').then(
            (m) => m.DepartmentManageModule
          )
      },
      {
        path: 'edit-department',
        loadChildren: () =>
          import('./department-edit/department-edit.module').then(
            (m) => m.DepartmentEditModule
          )
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PbrRoutingModule {}
