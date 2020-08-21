// import { NgModule } from '@angular/core';
// import { Routes, RouterModule } from '@angular/router';
// import {PowerbiComponent} from './powerbi.component';

// const routes: Routes = [
//   {
//     path: '',
//     component: PowerbiComponent,
//     data: {
//       breadcrumb: 'Change Log',
//       icon: 'icofont-social-blogger bg-c-green',
//       breadcrumb_caption: 'Lorem Ipsum Dolor Sit Amet, Consectetur Adipisicing Elit - Change Log',
//       status: true
//     }
//   }
// ];

// @NgModule({
//   imports: [RouterModule.forChild(routes)],
//   exports: [RouterModule]
// })
// export class PowerBiRoutingModule { }
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {PowerbiComponent} from './powerbi.component';

const routes: Routes = [
  {
    path: '',
    component: PowerbiComponent,
    children: [
      {
        path: 'powerbiaccount',
        loadChildren: () => import('./powerbi-account/powerbi-account.module').then(m => m.PowerBiAccountModule)
      },
      {
        path: 'Create',
        loadChildren: () => import('./powerbi-createpowerbiaccount/powerbi-createpowerbiaccount.module').then(m => m.CreatePowerBiAccountModule)
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PowerBiRoutingModule { }
