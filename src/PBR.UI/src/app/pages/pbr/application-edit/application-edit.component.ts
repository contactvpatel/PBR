import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-application-edit',
  templateUrl: './application-edit.component.html',
  styleUrls: ['./application-edit.component.scss']
})
export class ApplicationEditComponent implements OnInit {

  applicationForm = new FormGroup({
    applicationName: new FormControl(''),
    accountName: new FormControl(''),
    groupId: new FormControl(''),
    isActive: new FormControl(''),
  });

  constructor() { }

  ngOnInit() {
  }

}
