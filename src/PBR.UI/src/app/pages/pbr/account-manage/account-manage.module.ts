import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { AccountManageRoutingModule } from './account-manage-routing.module';
import { AccountManageComponent } from './account-manage.component';
import { SharedModule } from '../../../shared/shared.module';

@NgModule({
  imports: [
    CommonModule,
    AccountManageRoutingModule,
    SharedModule,
    FormsModule,
  ],
  declarations: [AccountManageComponent]
})
export class AccountManageModule { }
