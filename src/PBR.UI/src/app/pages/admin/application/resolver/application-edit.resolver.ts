import { Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  Resolve,
  RouterStateSnapshot
} from '@angular/router';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { Applications } from '../application.model';
import { ApplicationService } from '../../../../data/service/application.service';

@Injectable({
  providedIn: 'root'
})
export class ApplicationEditResolver implements Resolve<Applications> {
  constructor(private applicationService: ApplicationService) {}
  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    const id = Number(route.params.id);

    return this.applicationService.getApplicationById(id).pipe(
      map((response: any) => {
        const applications = new Applications();
        let app = [];
        try {
          app = applications.fromJsonForEditMode([response.data]);
        } catch (error) {
          console.log(error);
        }

        return {
          response: app.find((x) => x.id === id),
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
