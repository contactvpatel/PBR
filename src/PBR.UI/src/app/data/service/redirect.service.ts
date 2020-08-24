import { Injectable } from '@angular/core';
import { CanActivate, Router, NavigationEnd } from '@angular/router';
import { AuthService } from '../../core/service/auth.service';
import { environment } from '../../../environments/environment';

@Injectable()
export class RedirectService implements CanActivate {
  constructor(public authService: AuthService, public router: Router) {}

  canActivate(): boolean {
    const urlParams = new URLSearchParams(window.location.search);
    const myParam = urlParams.get('auth');
    const currentuser = this.authService.getToken();
    // Check Expiration
    if (!myParam && !currentuser) {
      this.post(
        environment.ssoClientId,
        environment.ssoClientSecret,
        environment.ssoLoginUrl
      );
    } else {
    /*
      else if(//check for Refreshtoken Expiration time or Session Time Out)
      {
          //If session time out then redirect to Session Timeout Page
          this.router.navigate(['/auth/session-timeout']);
      }
    */
      this.authService.setToken(myParam);
     // this.router.navigate(['/dashboard']);
      return true;
    }

    this.router.events.subscribe((evt) => {
      if (!(evt instanceof NavigationEnd)) {
        return;
      }
      window.scrollTo(0, 0);
    });

    return true;
  }

  post(clientId: string, clientSecret: string, url: string) {
    const mapForm = document.createElement('form');
    mapForm.method = 'POST';
    mapForm.action = url;

    const inputClientId = document.createElement('input');
    inputClientId.type = 'hidden';
    inputClientId.name = 'client_id';
    inputClientId.setAttribute('value', clientId);
    mapForm.appendChild(inputClientId);

    const inputClientSecret = document.createElement('input');
    inputClientSecret.type = 'hidden';
    inputClientSecret.name = 'client_key';
    inputClientSecret.setAttribute('value', clientSecret);
    mapForm.appendChild(inputClientSecret);

    document.body.appendChild(mapForm);
    mapForm.submit();
  }
}
