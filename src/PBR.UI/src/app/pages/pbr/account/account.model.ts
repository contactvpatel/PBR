import { DatePipe, formatDate } from '@angular/common';
import { Inject, LOCALE_ID } from '@angular/core';

export class Accounts {
  id: number;
  userName: string;
  password: string;
  clientId: string;
  clientSecret: string;
  accessToken: string;
  refreshToken: string;
  expiresIn: number;
  expiresOn: number;
  isActive: false;
  createdDate: string;
  lastUpdatedDate: string;
  accountName: string;
  accountList: any;

  /**
   *
   */
  constructor() {}

  fromJson(data: Accounts[]) {
    const accounts: any[] = [];

    data.forEach((acc) => {
      accounts.push({
        id: acc.id,
        userName: acc.userName,
        password: acc.password,
        clientId: acc.clientId,
        isActive: acc.isActive,
        clientSecret:acc.clientSecret,
        lastUpdatedDate: formatDate(
          acc.lastUpdatedDate,
          'dd/MM/yyyy HH:mm:ss',
          'en-US'
        ),
        accountName: acc.accountName,
      });
    });

    return accounts;
  }

  toJson() {}
}
