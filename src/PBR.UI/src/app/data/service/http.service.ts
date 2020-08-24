import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Observable, of } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { environment } from '../../../environments/environment';
import { IResponse } from '../schema/api.interface';

@Injectable({
  providedIn: 'root',
})
export class HttpService {
  /*********************Properties*********************/
  protected get options() {
    const headers = {};
    const token = environment.ssoRequestTokenAPI;
    headers['Accept'] = 'application/json';
    headers['Access-Control-Allow-Methods'] = 'GET,PUT,POST,PATCH,DELETE';
    headers['Allow'] = 'GET,PUT,POST,PATCH,DELETE';
    headers['Cache-Control'] = 'no-cache, no-store';
    headers['Pragma'] = 'no-cache';
    // headers['Expires'] = new Date().toUTCString();
    headers['Content-Type'] = 'application/json';

    if (token) {
      headers['Authorization'] = token;
    }

    return {
      headers: headers,
    };
  }

  private readonly httpMethod = {
    GET: 'get',
    POST: 'post',
    PUT: 'put',
    DELETE: 'delete',
  };
  /*********************Properties*********************/

  /*********************Constructor*********************/
  constructor(protected http: HttpClient) {}
  /*********************Constructor*********************/

  /*********************Service Methods*********************/

  protected fetch<T>(url: string, options?: any | {}): Observable<T> {
    return this.invokeService<T>(this.httpMethod.GET, url, null, options);
  }

  protected post<T>(
    url: string,
    body: Object,
    options?: any | {}
  ): Observable<T> {
    return this.invokeService<T>(this.httpMethod.POST, url, body, options);
  }

  protected put<T>(
    url: string,
    body: Object,
    options?: any | {}
  ): Observable<T> {
    return this.invokeService<T>(this.httpMethod.PUT, url, body, options);
  }

  protected delete<T>(
    url: string,
    body?: Object,
    options?: any | {}
  ): Observable<T> {
    return this.invokeService<T>(this.httpMethod.DELETE, url, body, options);
  }

  /*********************Service Methods*********************/

  /*********************Private Methods*********************/

  private invokeService<T>(
    method: string,
    url: string,
    body?: Object | null,
    options?: any | {}
  ): Observable<T> {
    let reqOptions = Object.assign(this.options);
    reqOptions = Object.assign(reqOptions, options);

    if (body) {
      reqOptions.body = body;

      if (body instanceof FormData) {
        delete reqOptions.headers['Content-Type'];
      }
    }

    return this.http.request<T>(method, url, reqOptions).pipe(
      map((response) => this.onHttpResponse(response)),
      catchError(this.onHttpError())
    );
  }

  private onHttpResponse(response): IResponse {
    const res = {
      data: response,
      error: null,
      hasError: false,
    };

    return res;
  }

  private onHttpError() {
    return (error: any): Observable<any> => {
      console.log(error);

      const res = {
        data: null,
        error: error,
        hasError: true,
      };

      return of(res);
    };
  }

  /*********************Private Methods*********************/
}
