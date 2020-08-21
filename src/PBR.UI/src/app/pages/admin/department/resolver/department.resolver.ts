import { Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  Resolve,
  RouterStateSnapshot
} from '@angular/router';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';

import { DepartmentService } from '../../../../data/service/department.service';
import { Department } from '../department.model';

@Injectable({
  providedIn: 'root'
})
export class DepartmentResolver implements Resolve<Department[]> {
  constructor(private departmentService: DepartmentService) {}
  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    return this.departmentService.getAllDepartment().pipe(
      map((response: any) => {
        const departments = new Department();
        let dep = [];
        try {
          dep = departments.fromJson(response.data);
        } catch (error) {
          console.log(error);
        }

        return {
          response: dep,
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
