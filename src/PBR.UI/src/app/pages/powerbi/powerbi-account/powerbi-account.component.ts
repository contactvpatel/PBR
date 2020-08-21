import { Component, OnInit } from '@angular/core';
import {Observable} from 'rxjs/index';
import {HttpClient} from '@angular/common/http';
import { PowerbiServiceService } from '../powerbi-Services/powerbi-service.service';

 export class OtherData {
   userName: string;
   clientId: string;
   isActive: any;
   lastUpdatedDate: string;
 }
@Component({
  selector: 'app-powerbi-account',
  templateUrl: './powerbi-account.component.html',
  styleUrls: ['./powerbi-account.component.scss']
})
export class PowerbiAccountComponent implements OnInit {
  public data = [];
  public rowsOnPage = 10;
  public filterQuery = '';
  public sortBy = '';
  public sortOrder = 'desc';
  constructor(public httpClient: HttpClient,private ApiService : PowerbiServiceService) { }

  ngOnInit() {
   //this.data = this.httpClient.get<OtherData>(`https://localhost:5001/PowerBiAccount/Index`);
 this.ApiService.GetAllPowerbiAccount().subscribe(data => this.data = data );

 }

}
