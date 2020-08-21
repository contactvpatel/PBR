import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { HttpService } from './http.service';


@Injectable({
  providedIn: 'root'
})
export class BaseService extends HttpService {
  /*********************Properties*********************/

  /*********************Constructor*********************/
  constructor(protected http: HttpClient) {
    super(http);
  }
  /*********************Constructor*********************/

  /*********************Service Methods*********************/

  protected serviceUrl(...suffix) {
    return suffix.join('');
  }

  protected getRequestParams(params: any[]): string {
    let queryString = '';

    params.forEach(param => {
      queryString += queryString ? '&' : '?';
      queryString += param.key + '=' + param.value;
    });

    return queryString;
  }

  /*********************Service Methods*********************/
}
