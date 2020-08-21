import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SessionTimeoutComponent } from './session-timeout.component';

const routes: Routes = [
  {
    path: '',
    component: SessionTimeoutComponent,
    data: {
      title: 'Session Timeout'
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SessionTimeoutRoutingModule { }
