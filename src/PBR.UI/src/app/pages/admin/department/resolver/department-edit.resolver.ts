import { Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  Resolve,
  RouterStateSnapshot
} from '@angular/router';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { Department } from '../department.model';
import { DepartmentService } from '../../../../data/service/department.service';

@Injectable({
  providedIn: 'root'
})
export class DepartmentEditResolver implements Resolve<Department> {
  constructor(private departmentService: DepartmentService) {}
  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    const id = Number(route.params.id);

    return this.departmentService.getDepartmentById(id).pipe(
      map((response: any) => {
        const department = new Department();
        let dep = [];
        try {
          dep = department.fromJsonForEditMode([response.data]);
          
        } catch (error) {
          console.log(error);
        }

        return {
          response: dep.find((x) => x.id === id),
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
