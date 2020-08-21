import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { adminComponent } from './admin.component';

const routes: Routes = [
  {
    path: '',
    component: adminComponent,
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
      
      // {
      //   path: 'edit-department',
      //   loadChildren: () =>
      //     import('./department-edit/department-edit.module').then(
      //       (m) => m.DepartmentEditModule
      //     )
      // }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule {}
