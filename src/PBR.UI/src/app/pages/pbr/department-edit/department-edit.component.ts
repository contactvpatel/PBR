import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-department-edit',
  templateUrl: './department-edit.component.html',
  styleUrls: ['./department-edit.component.scss']
})
export class DepartmentEditComponent implements OnInit {
  departmentForm = new FormGroup({
    applicationName: new FormControl(''),
    departmentName: new FormControl(''),
    isActive: new FormControl(''),
  });
  constructor() { }

  ngOnInit() {
  }

}
