import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DatatableComponent } from '@swimlane/ngx-datatable';

import { IResponse } from '../../../../data/schema/api.interface';
import { ToastService } from '../../../../shared/toaster/toaster.service';

import { Department } from '../department.model';
import { DepartmentService } from '../../../../data/service/department.service';

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

  applications: Department[];

  @ViewChild('buttonsTemplate', { static: false })
  buttonsTemplate: TemplateRef<any>;

  @ViewChild(DatatableComponent, { static: false })
  table: DatatableComponent;

  routedData: any = null;
  temp: Array<object> = [];

  constructor(
    private departmentService: DepartmentService,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private toast: ToastService
  ) {}

  ngOnInit() {
    this.routedData = this.activatedRoute.snapshot.data.department;
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

  onEditClick(row: Department) {
    this.router.navigate(['admin/department/edit', row.id]);
  }

  onCreateClick() {
    this.router.navigate(['admin/department/create']);
  }

  onDeleteClick(row: Department) {
    
    if (confirm('Are you sure you want to delete this account?')) {
     console.log(row.id)
      this.departmentService
        .DeleteApplicationDepartment(row.id)
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
    }) as Department[];

    // Whenever the filter changes, always go back to the first page
    this.table.offset = 0;
  }

  private setColumnsDef() {
    this.config.columnDefs = [
      {
        name: 'Application Account Name',
        prop: 'applicationAccountName'
      },
      { name: 'Department Name', prop: 'departmentName' },

      { name: 'Is Active', prop: 'isActive' },
      { name: 'Last Updated Date', prop: 'lastUpdatedDate' },
      { name: 'actions', prop: 'actions', sortable: false, width: '50' }
    ];
  }

  private setAllAccounts() {
    this.temp = this.routedData.response;
    this.applications = [...this.temp] as Department[];
  }

  // Use only for refresh
  private getAllAccounts() {
    this.departmentService
      .getAllDepartment()
      .subscribe((response: IResponse) => {
        if (!response.hasError) {
          this.applications = new Department().fromJson(response.data);
        }
      });
      }
}
