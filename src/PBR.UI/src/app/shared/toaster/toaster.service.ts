import { Injectable } from '@angular/core';
import { ToastyService } from 'ng2-toasty';

@Injectable({
  providedIn: 'root'
})
export class ToastService {
  /*********************Properties*********************/
  private TOASTR_TYPE = {
    SUCCESS: 'success',
    ERROR: 'error',
    WARNING: 'warning',
    INFO: 'info'
  };

  position = 'top-right';
  /*********************Properties*********************/

  /*********************Constructor*********************/
  constructor(private toastr: ToastyService) {}
  /*********************Constructor*********************/

  /*********************Service Methods*********************/

  success(options: any) {
    return this.showToastrMessage(this.TOASTR_TYPE.SUCCESS, options);
  }

  error(options: any) {
    return this.showToastrMessage(this.TOASTR_TYPE.ERROR, options);
  }

  warn(options: any) {
    return this.showToastrMessage(this.TOASTR_TYPE.WARNING, options);
  }

  info(options: any) {
    return this.showToastrMessage(this.TOASTR_TYPE.INFO, options);
  }

  /*********************Service Methods*********************/

  /*********************Private Methods*********************/

  private showToastrMessage(type: string, options: any) {
    this.position = options.position ? options.position : this.position;
    options = this.getToastrOptions(options);

    switch (type) {
      case this.TOASTR_TYPE.SUCCESS:
        this.toastr.success(options);
        break;

      case this.TOASTR_TYPE.ERROR:
        this.toastr.error(options);
        break;

      case this.TOASTR_TYPE.WARNING:
        this.toastr.warning(options);
        break;

      case this.TOASTR_TYPE.INFO:
        this.toastr.info(options);
        break;
    }
  }

  private getToastrOptions(options) {
    const defaultToastrOptions: any = {
      title: 'Toaster',
      msg: '',
      showClose: true,
      timeout: 5000,
      theme: 'bootstrap',
      closeOther: true
    };

    return Object.assign(defaultToastrOptions, options);
  }

  /*********************Private Methods*********************/
}
