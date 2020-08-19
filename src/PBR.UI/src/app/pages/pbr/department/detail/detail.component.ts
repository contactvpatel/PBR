import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

import { ActivatedRoute, Router } from '@angular/router';
import { Department } from '../department.model';
import { AccountRequest } from '../../../../data/schema/account.interface';
import { IResponse } from '../../../../data/schema/api.interface';
import { ApplicationRequest } from '../../../../data/schema/application.interface';
import { DepartmentService } from '../../../../data/service/department.service';
import { DepartmentRequest } from '../../../../data/schema/department.interface';

@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.scss']
})
export class DetailComponent implements OnInit {
  readonly config = {
    mode: {
      isEdit: false
    },
    department: {
      list: []
    },
    applicationAccount: {
      list: []
    }
  };
  department = null;
  routedData: any = null;

  departmentForm = new FormGroup({
    id: new FormControl(''),
    departmentId: new FormControl(''),
    applicationAccountId: new FormControl(''),

    isActive: new FormControl(true)
  });

  constructor(
    private departmentService: DepartmentService,
    private activatedRoute: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit() {
    this.department =
      this.activatedRoute.snapshot.data.department &&
      this.activatedRoute.snapshot.data.department.response;
    this.routedData = this.activatedRoute.snapshot.data;

    this.setMode();
    this.getApplicationList();
    this.getAccountList();
  }

  onCancelClick() {
    this.router.navigate(['pbr/department/manage']);
  }

  onFormSubmit() {
    if (this.departmentForm.valid) {
      const departmentRequest: DepartmentRequest = this.departmentForm.value;
      if (this.config.mode.isEdit) {
        this.updateAccount(departmentRequest);
      } else {
        departmentRequest.id = undefined;
        this.createApplication(departmentRequest);
      }
    } else {
      alert('Please enter all mandatory fields');
    }
  }

  private updateAccount(departmentRequest: DepartmentRequest) {
    this.departmentService
      .UpdateApplicationDepartment(departmentRequest)
      .subscribe((response: IResponse) => {
        if (!response.hasError) {
          alert(
            'Data Saved Successfully. You will be redirected to Manage account'
          );
          this.router.navigate(['pbr/department/manage']);
        } else {
          alert(response.error.error.title);
        }
      });
  }

  private createApplication(departmentRequest: DepartmentRequest) {
    this.departmentService
      .createDepartment(departmentRequest)
      .subscribe((response: IResponse) => {
        if (!response.hasError) {
          alert(
            'Data Saved Successfully. You will be redirected to Manage account'
          );
          this.router.navigate(['pbr/department/manage']);
        } else {
          alert(response.error.error.title);
        }
      });
  }

  private setMode() {
    if (this.routedData.isEdit) {
      this.config.mode.isEdit = true;
      this.setEditFormData();
    } else {
      this.config.mode.isEdit = false;
    }
  }
  private setEditFormData() {
    this.departmentForm.setValue({
      id: this.department.id,
      departmentId: this.department.departmentId,
      applicationAccountId: this.department.applicationAccountId,
      isActive: this.department.isActive
    });
  }

  private getApplicationList() {
    this.departmentService
      .GetAllDepartmentList()
      .subscribe((response: IResponse) => {
        this.config.department.list = response.data;
        console.log(response.data);
      });
  }

  private getAccountList() {
    this.departmentService
      .GetApplicationAndDepartmentName()
      .subscribe((response: IResponse) => {
        this.config.applicationAccount.list = response.data;
        console.log(response.data);
      });
  }
}
