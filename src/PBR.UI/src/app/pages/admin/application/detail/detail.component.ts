import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl,Validator, Validators } from '@angular/forms';

import { ActivatedRoute, Router } from '@angular/router';
import { AccountService } from '../../../../data/service/account.service';
import { Applications } from '../application.model';
import { AccountRequest } from '../../../../data/schema/account.interface';
import { IResponse } from '../../../../data/schema/api.interface';
import { ApplicationRequest } from '../../../../data/schema/application.interface';
import { ApplicationService } from '../../../../data/service/application.service';
import { ToastService } from '../../../../shared/toaster/toaster.service';
@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.scss']
})
export class DetailComponent implements OnInit {
  position = 'top-right';
  readonly config = {
    mode: {
      isEdit: false
    },
    application: {
      list: []
    },
    account: {
      list: []
    }
  };
  applications = null;
  routedData: any = null;
  submitted = false;

  applicationForm = new FormGroup({
    id: new FormControl(''),
    applicationId: new FormControl('',[Validators.required]),
    accountId: new FormControl('',[Validators.required]),
    groupId: new FormControl('',[Validators.required]),
    isActive: new FormControl(true)
  });

  constructor(
    private applicationService: ApplicationService,
    private activatedRoute: ActivatedRoute,
    private router: Router,

    private toast: ToastService
  ) {}

  ngOnInit() {
    this.applications =
      this.activatedRoute.snapshot.data.application &&
      this.activatedRoute.snapshot.data.application.response;
    this.routedData = this.activatedRoute.snapshot.data;
    this.setMode();
    this.getApplicationList();
    this.getAccountList();
  }

  onCancelClick() {
    this.router.navigate(['admin/application/manage']);
  }

  onFormSubmit() {
    this.submitted = true;
    if (this.applicationForm.valid) {
      
      const accountRequest: ApplicationRequest = this.applicationForm.value;
      if (this.config.mode.isEdit) {
        this.updateAccount(accountRequest);
      } else {
        accountRequest.id = undefined;
        this.createApplication(accountRequest);
      }
    } else {
      this.toast.error({
        msg: 'Please enter all mandatory fields',
        title: 'Error'
      });
    }
  }

  private updateAccount(accountRequest: AccountRequest) {
    this.applicationService
      .updateApplication(accountRequest)
      .subscribe((response: IResponse) => {
        if (!response.hasError) {
          this.toast.success({
            msg:
              'Data Saved Successfully. You will be redirected to Manage application',
            title: 'Success'
          });
          this.router.navigate(['admin/application/manage']);
        } else {
          this.toast.error({
            msg: response.error.error.title,
            title: 'Error'
          });        }
      });
  }

  private createApplication(applicationRequest: ApplicationRequest) {
    this.applicationService
      .createApplication(applicationRequest)
      .subscribe((response: IResponse) => {
        if (!response.hasError) {
          this.toast.success({
            msg:
              'Data Saved Successfully. You will be redirected to Manage application',
            title: 'Success'
          });
          this.router.navigate(['admin/application/manage']);
        } else {
          this.toast.error({
            msg: response.error.error.title,
            title: 'Error'
          });     
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
    this.applicationForm.setValue({
      id: this.applications.id,
      applicationId: this.applications.applicationId,
      accountId: this.applications.accountId,
      groupId: this.applications.groupId,
      isActive: this.applications.isActive
    });
  }

  private getApplicationList() {
    this.applicationService
      .getApplicationList()
      .subscribe((response: IResponse) => {
        this.config.application.list = response.data;
      });
  }

  private getAccountList() {
    this.applicationService
      .getAccountList()
      .subscribe((response: IResponse) => {
        this.config.account.list = response.data;
      });
  }
}
