import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

import { ActivatedRoute, Router } from '@angular/router';
import { AccountService } from '../../../../data/service/account.service';
import { Accounts } from '../account.model';
import { AccountRequest } from '../../../../data/schema/account.interface';
import { IResponse } from '../../../../data/schema/api.interface';
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
    }
  };
  accounts: Accounts = null;
  routedData: any = null;

  accountForm = new FormGroup({
    id: new FormControl(''),
    accountName: new FormControl(''),
    userName: new FormControl(''),
    password: new FormControl(''),
    clientId: new FormControl(''),
    isActive: new FormControl(true),
    clientSecret:new FormControl('')
  });

  constructor(
    private accountService: AccountService,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private toast: ToastService
  ) {}

  ngOnInit() {
    this.accounts =
      this.activatedRoute.snapshot.data.account &&
      this.activatedRoute.snapshot.data.account.response;
    this.routedData = this.activatedRoute.snapshot.data;
    
    this.setMode();
  }

  onCancelClick() {
    this.router.navigate(['pbr/account/manage']);
  }

  onFormSubmit() {
    if (this.accountForm.valid) {
      const accountRequest: AccountRequest = this.accountForm.value;
      if (this.config.mode.isEdit) {
        this.updateAccount(accountRequest);
      } else {
        accountRequest.id = undefined;
        this.createAccount(accountRequest);
      }
    } else {
      this.toast.error({
        msg: 'Please enter all mandatory fields',
        title: 'Error'
      });
    }
  }

  private updateAccount(accountRequest: AccountRequest) {
    this.accountService
      .updateAccount(accountRequest)
      .subscribe((response: IResponse) => {
        if (!response.hasError) {
          this.toast.success({
            msg:
              'Data Saved Successfully. You will be redirected to Manage account',
            title: 'Success'
          });
          this.router.navigate(['pbr/account/manage']);
        } else {
          this.toast.error({
            msg: response.error.error.title,
            title: 'Error'
          });
        }
      });
  }

  private createAccount(accountRequest: AccountRequest) {
    this.accountService
      .createAccount(accountRequest)
      .subscribe((response: IResponse) => {
        if (!response.hasError) {
          this.toast.success({
            msg:
              'Data Saved Successfully. You will be redirected to Manage account',
            title: 'Success'
          });
          this.router.navigate(['pbr/account/manage']);
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
    this.accountForm.setValue({
      id: this.accounts.id,
      accountName: this.accounts.accountName,
      userName: this.accounts.userName,
      password: this.accounts.password,
      clientId: this.accounts.clientId,
      isActive: this.accounts.isActive,
      clientSecret:this.accounts.clientSecret
    });
  }
}
