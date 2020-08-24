import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DatatableComponent } from '@swimlane/ngx-datatable';

import { IResponse } from '../../../../data/schema/api.interface';
import { AccountService } from '../../../../data/service/account.service';
import { ToastService } from '../../../../shared/toaster/toaster.service';
import { Accounts } from '../account.model';
import conformationPopup from 'sweetalert2';
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

  accounts: Accounts[];

  @ViewChild('buttonsTemplate', { static: false })
  buttonsTemplate: TemplateRef<any>;

  @ViewChild(DatatableComponent, { static: false })
  table: DatatableComponent;

  routedData: any = null;
  temp: Array<object> = [];

  constructor(
    private accountService: AccountService,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private toast: ToastService
  ) {}

  ngOnInit() {
    this.routedData = this.activatedRoute.snapshot.data.accounts;
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

  onEditClick(row: Accounts) {
    this.router.navigate(['admin/account/edit', row.id]);
  }

  onCreateClick() {
    this.router.navigate(['admin/account/create']);
  }

  // onDeleteClick(row: Accounts) {
  //   if (confirm('Are you sure you want to delete this account?')) {
  //     this.accountService
  //       .deleteAccount(row.id)
  //       .subscribe((response: IResponse) => {
  //         if (!response.hasError) {
  //           this.toast.success({
  //             msg: 'Account with id: ' + row.id + ' deleted successfully',
  //             title: 'Success'
  //           });

  //           this.getAllAccounts();
  //         } else {
  //           console.log(response.error);
  //         }
  //       });
  //   }
  // }
  onDeleteClick(row: Accounts) {

    conformationPopup({
      title: 'Are you sure?',
      text: 'You wont be delete this account',
      type: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!',
      cancelButtonText: 'No, cancel!',
      confirmButtonClass: 'btn btn-success m-r-10',
      cancelButtonClass: 'btn btn-danger',
      buttonsStyling: false
    }).then((dismiss) => {
      if (dismiss.value === true) {

        this.accountService
        .deleteAccount(row.id)
        .subscribe((response: IResponse) => {
          if (!response.hasError) {
            console.log(row.id);
            console.log(response.error);
            this.getAllAccounts();
          } else {
            console.log(row.id);
            console.log(response.error);
          }
        });
        conformationPopup(
          'Deleted!',
        'Your account has been deleted.',
        'success'
        );

      } else{

        conformationPopup(
          'Cancelled',
          'Your account is safe :)',
          'error'
        );
      }

    }).catch(conformationPopup.noop);
  }
  updateFilter(event) {
    const value = event.target.value.toLowerCase().trim();
    // get the amount of columns in the table
    const count = this.config.columnDefs.length;
    // get the key names of each column in the dataset
    const keys = Object.keys(this.temp[0]);
    // assign filtered matches to the active datatable
    this.accounts = this.temp.filter((item) => {
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
    }) as Accounts[];

    // Whenever the filter changes, always go back to the first page
    this.table.offset = 0;
  }

  private setColumnsDef() {
    this.config.columnDefs = [
      {
        name: 'Account Name',
        prop: 'accountName'
      },
      { name: 'User Name', prop: 'userName' },
      { name: 'Client Id', prop: 'clientId' },
      { name: 'Is Active', prop: 'isActive' },
      { name: 'Last Updated Date', prop: 'lastUpdatedDate' },
      { name: 'actions', prop: 'actions', sortable: false, width: '50' }
    ];
  }

  private setAllAccounts() {
    this.temp = this.routedData.response;
    this.accounts = [...this.temp] as Accounts[];
  }

  // Use only for refresh
  private getAllAccounts() {
    this.accountService
      .getAllAccounts()
      .subscribe((response: IResponse) => {
        if (!response.hasError) {
          this.accounts = new  Accounts().fromJson(response.data);
        }
      });
  }
 }
