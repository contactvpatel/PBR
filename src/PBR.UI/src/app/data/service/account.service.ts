import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { AccountAPI } from '../schema/api.constant';
import { AccountRequest } from '../schema/account.interface';

@Injectable({
  providedIn: 'root',
})
export class AccountService extends BaseService {
  url = environment.serverUrl;

  constructor(protected http: HttpClient) {
    super(http);
  }

  getAllAccounts() {
    const url = this.serviceUrl(this.url, AccountAPI.GetAllAccounts);
    return this.fetch(url);
  }

  getAccountById(id: number) {
    const url = this.serviceUrl(this.url, AccountAPI.GetAccountById, id);
    return this.fetch(url);
  }

  updateAccount(account: AccountRequest) {
    const url = this.serviceUrl(this.url, AccountAPI.UpdateAccount);
    return this.put(url, account);
  }

  createAccount(account: AccountRequest) {
    const url = this.serviceUrl(this.url, AccountAPI.CreateAccount);
    return this.post(url, account);
  }

  deleteAccount(id: number) {
    const url = this.serviceUrl(this.url, AccountAPI.DeleteAccount, id);
    return this.delete(url);
  }

  // Same like user service
}
