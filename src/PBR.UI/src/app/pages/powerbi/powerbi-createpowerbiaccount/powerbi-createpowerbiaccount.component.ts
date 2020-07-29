import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { PowerbiServiceService } from '../powerbi-Services/powerbi-service.service';

@Component({
  selector: 'app-powerbi-createpowerbiaccount',
  templateUrl: './powerbi-createpowerbiaccount.component.html',
  styleUrls: ['./powerbi-createpowerbiaccount.component.scss']
})
export class PowerbiCreatepowerbiaccountComponent implements OnInit {
  registrationform: FormGroup;
  UserSubmittted: boolean;
  constructor( private fb: FormBuilder, private Http: HttpClient, private ApiService: PowerbiServiceService ) { }
  ngOnInit() {this.registrationform = new FormGroup(
    {
    AccountName: new FormControl(null, [Validators.required]),
    UserName: new FormControl(null, [Validators.required]),
    Password : new FormControl(null, [Validators.required ]),
    ClientId : new FormControl(null , [Validators.required]),
    IsActive : new FormControl(null , [Validators.required]),
  });
  }
  get AccountName() {
  return this.registrationform.get('AccountName') as FormControl;
}
get UserName() {
  return this.registrationform.get('UserName') as FormControl;
}
get Password() {
  return this.registrationform.get('Password') as FormControl;
}
get ClientId()  {
  return this.registrationform.get('ClientId') as FormControl;
}

get IsActive() {
  return this.registrationform.get('IsActive') as FormControl;
}
onsubmit() {
   this.UserSubmittted = true;
  if (this.registrationform.valid) {
    console.log(this.registrationform.value);
    const cc = this.ApiService.savePowerBiAccountData(this.registrationform.value).subscribe(data => console.log(data));

    // this.user = Object.assign(this.user, this.registrationform.value);
     this.registrationform.reset();
     this.UserSubmittted = false;
  } else  {  }
}
}
