import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { DepartmentAPI } from '../schema/api.constant';
import { AccountRequest } from '../schema/account.interface';
import { DepartmentRequest } from '../schema/department.interface';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService extends BaseService {
  url = environment.Url;

  constructor(protected http: HttpClient) {
    super(http);
  }

  getAllDepartment() {
    const url = this.serviceUrl(
      this.url,
      DepartmentAPI.GetAllApplicationDepartments
    );
    return this.fetch(url);
  }
  getDepartmentById(id: number) {
    const url = this.serviceUrl(
      this.url,
      DepartmentAPI.GetApplicationDepartmentById,
      id
    );
    return this.fetch(url);
  }
  GetAllDepartmentList() {
    const url = this.serviceUrl(this.url, DepartmentAPI.GetAllDepartments);
    return this.fetch(url);
  }
  createDepartment(departmentRequest: DepartmentRequest) {
    const url = this.serviceUrl(
      this.url,
      DepartmentAPI.CreateApplicationDepartment
    );
    return this.post(url, departmentRequest);
  }
  GetApplicationAndDepartmentName() {
    const url = this.serviceUrl(
      this.url,
      DepartmentAPI.GetApplicationNameAndAccountName
    );
    return this.fetch(url);
  }

  UpdateApplicationDepartment(departmentRequest: any) {
    const url = this.serviceUrl(
      this.url,
      DepartmentAPI.UpdateApplicationDepartment
    );
    return this.put(url, departmentRequest);
  }

  DeleteApplicationDepartment(id: number) {
    const url = this.serviceUrl(this.url, DepartmentAPI.DeleteApplicationDepartment, id);
    return this.delete(url);
  }
  // Same like user service
}
