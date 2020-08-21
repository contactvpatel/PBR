import { Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  Resolve,
  RouterStateSnapshot
} from '@angular/router';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';

import { ApplicationService } from '../../../../data/service/application.service';
import { Applications } from '../application.model';

@Injectable({
  providedIn: 'root'
})
export class ApplicationsResolver implements Resolve<Applications[]> {
  constructor(private applicationService: ApplicationService) {}
  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    return this.applicationService.getAllApplications().pipe(
      map((response: any) => {
        const accounts = new Applications();
        let acc = [];
        try {
          acc = accounts.fromJson(response.data);
        } catch (error) {
          console.log(error);
        }

        return {
          response: acc,
          data: route.data,
          param: route.params
        };
      }),
      catchError((error) => {
        return of(error);
      })
    );
  }
}
