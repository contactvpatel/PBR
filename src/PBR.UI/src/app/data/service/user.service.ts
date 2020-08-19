import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { HttpClient } from '@angular/common/http';

import { UserAPI } from '../schema/api.constant';
import { User } from '../schema/user';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class UserService extends BaseService {
  constructor(protected http: HttpClient) {
    super(http);
  }

  getUser() {
    const url = this.serviceUrl(environment.apiUrl, UserAPI.GetUser);
    return this.fetch(url);
  }

  saveUser(user: User) {
    const url = this.serviceUrl(environment.apiUrl, UserAPI.GetUser);
    return this.post(url, user);
  }
}
