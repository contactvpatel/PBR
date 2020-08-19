import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

import { ActivatedRoute, Router } from '@angular/router';
import { AccountService } from '../../../../data/service/account.service';
import { Applications } from '../application.model';
import { AccountRequest } from '../../../../data/schema/account.interface';
import { IResponse } from '../../../../data/schema/api.interface';
import { ApplicationRequest } from '../../../../data/schema/application.interface';
import { ApplicationService } from '../../../../data/service/application.service';

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
    application: {
      list: []
    },
    account: {
      list: []
    }
  };
  applications = null;
  routedData: any = null;

  applicationForm = new FormGroup({
    id: new FormControl(''),
    applicationId: new FormControl(''),
    accountId: new FormControl(''),
    groupId: new FormControl(''),
    isActive: new FormControl(true)
  });

  constructor(
    private applicationService: ApplicationService,
    private activatedRoute: ActivatedRoute,
    private router: Router
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
    this.router.navigate(['pbr/application/manage']);
  }

  onFormSubmit() {
    if (this.applicationForm.valid) {
      const accountRequest: ApplicationRequest = this.applicationForm.value;
      if (this.config.mode.isEdit) {
        this.updateAccount(accountRequest);
      } else {
        accountRequest.id = undefined;
        this.createApplication(accountRequest);
      }
    } else {
      alert('Please enter all mandatory fields');
    }
  }

  private updateAccount(accountRequest: AccountRequest) {
    this.applicationService
      .updateApplication(accountRequest)
      .subscribe((response: IResponse) => {
        if (!response.hasError) {
          alert(
            'Data Saved Successfully. You will be redirected to Manage account'
          );
          this.router.navigate(['pbr/application/manage']);
        } else {
          alert(response.error.error.title);
        }
      });
  }

  private createApplication(applicationRequest: ApplicationRequest) {
    this.applicationService
      .createApplication(applicationRequest)
      .subscribe((response: IResponse) => {
        if (!response.hasError) {
          alert(
            'Data Saved Successfully. You will be redirected to Manage account'
          );
          this.router.navigate(['pbr/application/manage']);
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
