import { NgModule } from '@angular/core';

import { AuthService } from './auth.service';
import { HttpService } from './http.service';
import { UserService } from './user.service';
import { AccountService } from './account.service';

@NgModule({
  providers: [HttpService, AuthService, UserService, AccountService],
})
export class ServicesModule {}
