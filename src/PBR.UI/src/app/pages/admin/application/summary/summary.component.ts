import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DatatableComponent } from '@swimlane/ngx-datatable';

import { IResponse } from '../../../../data/schema/api.interface';
import { AccountService } from '../../../../data/service/account.service';
import { ToastService } from '../../../../shared/toaster/toaster.service';

import { Applications } from '../application.model';
import { ApplicationService } from '../../../../data/service/application.service';

@Component({
  selector: 'app-summary',
  templateUrl: './summary.component.html',
  styleUrls: ['./summary.component.scss']
})
export class SummaryComponent implements OnInit {
  position = 'top-right';
  readonly config = {
    columnDefs: [],
    pageLimitOptions: [
      { value: 10 },
      { value: 25 },
      { value: 50 },
      { value: 100 }
    ],
    currentPageLimit: 0
  };

  applications: Applications[];

  @ViewChild('buttonsTemplate', { static: false })
  buttonsTemplate: TemplateRef<any>;

  @ViewChild(DatatableComponent, { static: false })
  table: DatatableComponent;

  routedData: any = null;
  temp: Array<object> = [];

  constructor(
    private applicationsService: ApplicationService,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private toast: ToastService
  ) {}

  ngOnInit() {
    this.routedData = this.activatedRoute.snapshot.data.application;
    this.setColumnsDef();
    this.setAllAccounts();
  }

  onLimitChange(limit: any): void {
    this.changePageLimit(limit);
    this.table.limit = this.config.currentPageLimit;
    this.table.recalculate();
    setTimeout(() => {
      if (this.table.bodyComponent.temp.length <= 0) {
        // TODO[Dmitry Teplov] test with server-side paging.
        this.table.offset = Math.floor(
          (this.table.rowCount - 1) / this.table.limit
        );
      }
    });
  }

  private changePageLimit(limit: any): void {
    this.config.currentPageLimit = parseInt(limit, 10);
  }

  getRowClass(row) {
    return row.isActive ? '' : 'text-danger';
  }

  onEditClick(row: Applications) {
    this.router.navigate(['admin/application/edit', row.id]);
  }

  onCreateClick() {
    this.router.navigate(['admin/application/create']);
  }

  onDeleteClick(row: Applications) {
    
    if (confirm('Are you sure you want to delete this account?')) {
      this.applicationsService
        .deleteApplication(row.id)
        .subscribe((response: IResponse) => {
          if (!response.hasError) {
             this.toast.success({
              msg: 'Account with id: ' + row.id + ' deleted successfully',
              title: 'Success'
            });
            this.getAllAccounts();
          } else {
            console.log(response.error);
          }
        });
    }
  }

  updateFilter(event) {
    const value = event.target.value.toLowerCase().trim();
    // get the amount of columns in the table
    const count = this.config.columnDefs.length;
    // get the key names of each column in the dataset
    const keys = Object.keys(this.temp[0]);
    // assign filtered matches to the active datatable
    this.applications = this.temp.filter((item) => {
      // iterate through each row's column data
      for (let i = 0; i <= count; i++) {
        // check for a match
        if (
          (item[keys[i]] &&
            item[keys[i]].toString().toLowerCase().indexOf(value) !== -1) ||
          !value
        ) {
          // found match, return true to add to result set
          return true;
        }
      }
    }) as Applications[];

    // Whenever the filter changes, always go back to the first page
    this.table.offset = 0;
  }

  private setColumnsDef() {
    this.config.columnDefs = [
      {
        name: 'Application Name',
        prop: 'applicationName'
      },
      { name: 'Account Name', prop: 'accountName' },
      { name: 'Group Id', prop: 'groupId' },
      { name: 'Is Active', prop: 'isActive' },
      { name: 'Last Updated Date', prop: 'lastUpdatedDate' },
      { name: 'actions', prop: 'actions', sortable: false, width: '50' }
    ];
  }

  private setAllAccounts() {
    this.temp = this.routedData.response;
    this.applications = [...this.temp] as Applications[];
  }

  // Use only for refresh
  private getAllAccounts() {
    this.applicationsService
      .getAllApplications()
      .subscribe((response: IResponse) => {
        if (!response.hasError) {
          this.applications = new Applications().fromJson(response.data);
        }
      });
  }
}
