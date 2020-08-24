import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SessionTimeoutComponent } from './session-timeout.component';
import { SessionTimeoutRoutingModule } from './session-timeout-routing.module';
import { SharedModule } from '../../../shared/shared.module';

@NgModule({
  imports: [
    CommonModule,
    SessionTimeoutRoutingModule,
    SharedModule
  ],
  declarations: [SessionTimeoutComponent]
})
export class SessionTimeoutModule { }
