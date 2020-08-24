import { Injectable } from '@angular/core';
import { of, Observable, throwError } from 'rxjs';

interface LoginContextInterface {
  username: string;
  password: string;
  token: string;
}

const defaultUser = {
  username: 'Mathis',
  password: '12345',
  token: '12345'
};

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  token: string;
  accessToken: string;

  login(loginContext: LoginContextInterface): Observable<any> {
    if (
      loginContext.username === defaultUser.username &&
      loginContext.password === defaultUser.password
    ) {
        return of(defaultUser);
    }

    return throwError('Invalid username or password');
  }

  logout(): Observable<boolean> {
    return of(false);
  }

  public setToken(token: string) {
    localStorage.setItem('token', token);
   // this.accessToken = token;
  }

  public getToken() {
    // return this.accessToken;

    return localStorage.getItem('token');
  }

}
