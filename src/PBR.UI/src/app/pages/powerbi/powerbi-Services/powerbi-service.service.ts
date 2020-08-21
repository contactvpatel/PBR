import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {PowerbiInterface} from './powerbi-interface/powerbi-interface';
import { from, Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class PowerbiServiceService {

constructor(private Http: HttpClient) { }
GetAllPowerbiAccount(): Observable<PowerbiInterface[]> {
  return  this.Http.get<PowerbiInterface[]>('https://localhost:5001/PowerBiAccount/Index');
}
savePowerBiAccountData(PowerBiAccountdata) {
   return this.Http.post('https://localhost:5001/PowerBiAccount/Create' , PowerBiAccountdata);
}
}
