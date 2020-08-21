import { Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  Resolve,
  RouterStateSnapshot,
} from '@angular/router';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { Accounts } from '../account.model';
import { AccountService } from '../../../../data/service/account.service';

@Injectable({
  providedIn: 'root',
})
export class AccountEditResolver implements Resolve<Accounts> {
  constructor(private accountService: AccountService) {}
  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    const id = Number(route.params.id);

    return this.accountService.getAccountById(id).pipe(
      map((response: any) => {
        const accounts = new Accounts();
        let acc = [];
        try {
          acc = accounts.fromJson([response.data]);
        } catch (error) {
          console.log(error);
        }

        return {
          response: acc.find((x) => x.id === id),
          data: route.data,
          param: route.params,
        };
      }),
      catchError((error) => {
        return of(error);
      })
    );
  }
}
