import { DatePipe, formatDate } from '@angular/common';
import { Inject, LOCALE_ID } from '@angular/core';

export class Applications {
  applicationId: number;
  accountId: number;
  groupId: string;
  isActive: false;
  isActiveOptionList: any;
  createdDate: string;
  lastUpdatedDate: string;
  id: number;
  application: Application;
  account: Account;

  /**
   *
   */
  constructor() {}

  fromJson(data: Applications[]) {
    const applications: any[] = [];

    data.forEach((acc) => {
      applications.push({
        id: acc.id,
        applicationName: acc.application.applicationName,
        accountName: acc.account.accountName,
        groupId: acc.groupId,
        isActive: acc.isActive,

        lastUpdatedDate: formatDate(
          acc.lastUpdatedDate,
          'dd/MM/yyyy HH:mm:ss',
          'en-US'
        )
      });
    });

    return applications;
  }

  fromJsonForEditMode(data: any[]) {
    const applications: any[] = [];

    data.forEach((acc) => {
      applications.push({
        applicationId: acc.applicationId,
        accountId: acc.accountId,
        groupId: acc.groupId,
        isActive: acc.isActive,
        id: acc.id
      });
    });
    return applications;
  }

  toJson() {}
}

interface Application {
  pplicationId: number;
  applicationName: string;
  modifiedDate: string;
  modifiedBy: number;
  applicationList: any;
}

interface Account {
  id: number;
  userName: string;
  password: string;
  clientId: string;
  clientSecret: string;
  accessToken: string;
  refreshToken: string;
  expiresIn: number;
  expiresOn: number;
  isActive: boolean;
  createdDate: string;
  lastUpdatedDate: string;
  accountName: string;
  accountList: any;
}
