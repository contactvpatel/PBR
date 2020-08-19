import { Component, OnInit } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { RedirectService } from './data/service/redirect.service';
import { AuthService } from './core/service/auth.service';
import { environment } from '../environments/environment';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Welcome ! Power BI Reports';
  position = 'top-right';

  constructor(
    private router: Router,
    private authService: AuthService,
    private redirectService: RedirectService
    ) { }

  ngOnInit() {
  //   const urlParams = new URLSearchParams(window.location.search);
  //   const myParam = urlParams.get('auth');
  //   const currentuser = this.authService.getToken();
  //   // Check Expiration
  //   if (!myParam && !currentuser) {
  //     this.redirectService.post(environment.ssoClientId, environment.ssoClientSecret, environment.ssoLoginUrl);
  //   }
  //   /*
  //     else if(//check for Refreshtoken Expiration time or Session Time Out)
  //     {
  //         //If session time out then redirect to Session Timeout Page
  //         this.router.navigate(['/auth/session-timeout']);
  //     }
  //   */
  //   else {
  //     this.authService.setToken(myParam);
  //     this.router.navigate(['/basic']);
  //   }

  //   this.router.events.subscribe((evt) => {
  //     if (!(evt instanceof NavigationEnd)) {
  //       return;
  //     }
  //     window.scrollTo(0, 0);
  //   });
   }
}
