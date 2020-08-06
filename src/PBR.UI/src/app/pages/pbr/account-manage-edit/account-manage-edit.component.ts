import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-account-manage-edit',
  templateUrl: './account-manage-edit.component.html',
  styleUrls: ['./account-manage-edit.component.scss']
})
export class AccountManageEditComponent implements OnInit{

  accountForm = new FormGroup({
    accountName: new FormControl(''),
    userName: new FormControl(''),
    password: new FormControl(''),
    clientId: new FormControl(''),
    isActive: new FormControl(''),
  });

  constructor() { }

  ngOnInit() {
  }

}
