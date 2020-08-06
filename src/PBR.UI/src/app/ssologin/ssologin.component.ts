import { Component, OnInit } from '@angular/core';
import { environment } from '../../environments/environment';
import { FormBuilder, FormGroup } from "@angular/forms";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-ssologin',
  templateUrl: './ssologin.component.html',
  styleUrls: ['./ssologin.component.scss']
})
export class SsologinComponent implements OnInit {
  form: FormGroup;
 

  constructor( public fb: FormBuilder,
    private http: HttpClient,
    private router: Router)
    {
      this.form = this.fb.group({
        client_id: environment.SSOClientId,
        client_key: environment.SSOClientSecret,
        redirect_uri: environment.SSORedirectApplicationUrl
     })
    }

    submitForm() {
      let header = new HttpHeaders();
      header= header.append('content-type', 'application/x-www-form-urlencoded');
      //header= header.append('accept', 'text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9');

      var formData: any = new FormData();
      formData.append("client_id", this.form.get('client_id').value);
      formData.append("client_key", this.form.get('client_key').value);
      formData.append("redirect_uri", this.form.get('redirect_uri').value);
  
      this.http.post(environment.SSOUrl, formData).subscribe(   //, { 'headers': header }
        (response) => console.log(response),
        (error) => console.log(error)

        //if API succeeds and recieves token , redirect to default dashboard page.
         //this.router.navigate(['/']);
        
      )
    }

  ngOnInit() {
    this.submitForm();
  }

}
