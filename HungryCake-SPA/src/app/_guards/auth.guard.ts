import { Injectable } from '@angular/core';
import { CanActivate, Router, ActivatedRouteSnapshot } from '@angular/router';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private authService: AuthService, private router: Router, private alertify: AlertifyService) {}

  canActivate(next: ActivatedRouteSnapshot): boolean {
    const level = next.firstChild.data.level as number;
    if (level) {
      const match = this.authService.levelMatch(level);
      if (match) {
        return true;
      } else {
        this.router.navigate(['grid']);
        this.alertify.success('You are not authorised to access this area');
      }
    }

    if (this.authService.loggedIn()) {
      return true;
    }

    this.alertify.error('You shall not pass!!!');
    this.router.navigate(['/home']);
    return false;
  }
}
