import { DatePipe, formatDate } from '@angular/common';
import { Inject, LOCALE_ID } from '@angular/core';

export class Department {
  applicationAccountName: string;
  departmentName: string;
  lastUpdatedDate: string;
  isActive: boolean;
  id: number;


  constructor() {}

  fromJson(data: Department[]) {
    const applications: any[] = [];

    data.forEach((dep) => {
      applications.push({
        id: dep.id,
        applicationAccountName: dep.applicationAccountName,
        departmentName: dep.departmentName,
        isActive: dep.isActive,
        lastUpdatedDate: formatDate(
          dep.lastUpdatedDate,
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
        applicationAccountId: acc.applicationAccountId,
        departmentId: acc.departmentId,
        isActive: acc.isActive,
        id: acc.id
      });
    });
    return applications;
  }

  toJson() {}
}
