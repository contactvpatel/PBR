import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root',
})
export class AuthService extends BaseService {
  constructor(protected http: HttpClient) {
    super(http);
  }
  /*********************Utility Methods*********************/

  // isAuthenticated(): Promise<boolean> {
  //   const authToken = this.cacheService.get(
  //     CacheConstant.AuthToken
  //   ) as AuthToken;

  //   const hasToken = authToken && authToken.accessToken ? true : false;
  //   return Promise.resolve(hasToken);
  // }

  // clearSession() {
  //   this.clearSessionCache();
  // }

  // /*********************Utility Methods*********************/

  // signOut(reason: SignOutReason = SignOutReason.Default) {
  //   this.signOutUser();
  // }

  // /*********************Service Methods*********************/

  // /*********************Private Methods*********************/

  // private signOutUser() {
  //   this.clearSessionCache();
  // }

  // private clearSessionCache() {
  //   this.cacheService.remove(CacheConstant.AuthToken);
  // }

  /*********************Private Methods*********************/
}
