import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { ApplicationAPI } from '../schema/api.constant';

@Injectable({
  providedIn: 'root'
})
export class ApplicationService extends BaseService {
  url = environment.serverUrl;

  constructor(protected http: HttpClient) {
    super(http);
  }

  getAllApplications() {
    const url = this.serviceUrl(this.url, ApplicationAPI.GetAllApplications);
    return this.fetch(url);
  }

  getApplicationById(id: number) {
    const url = this.serviceUrl(
      this.url,
      ApplicationAPI.GetApplicationById,
      id
    );
    return this.fetch(url);
  }

  updateApplication(account: any) {
    const url = this.serviceUrl(this.url, ApplicationAPI.UpdateApplication);
    return this.put(url, account);
  }

  createApplication(account: any) {
    const url = this.serviceUrl(this.url, ApplicationAPI.CreateApplication);
    return this.post(url, account);
  }

  deleteApplication(id: number) {
    const url = this.serviceUrl(this.url, ApplicationAPI.DeleteApplication, id);
    return this.delete(url);
  }

  getAccountList() {
    const url = this.serviceUrl(this.url, ApplicationAPI.GetAccountList);
    return this.fetch(url);
  }

  getApplicationList() {
    const url = this.serviceUrl(this.url, ApplicationAPI.GetApplicationList);
    return this.fetch(url);
  }

  // Same like user service
}
