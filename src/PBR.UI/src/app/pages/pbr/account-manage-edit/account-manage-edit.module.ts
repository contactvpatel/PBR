import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AccountManageEditRoutingModule } from './account-manage-edit-routing.module';
import { AccountManageEditComponent } from './account-manage-edit.component';
import {SharedModule} from '../../../shared/shared.module';

@NgModule({
  imports: [
    CommonModule,
    AccountManageEditRoutingModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule,
    ],
  declarations: [AccountManageEditComponent]
})
export class AccountManageEditModule { }
