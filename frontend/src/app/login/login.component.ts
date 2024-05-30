import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { AuthService } from '../auth/services/auth.service'
import { AuthResponse } from '../auth/models/authResponse';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  userId: string = '';
  cellNo: string = '';
  password: string = '';
  email: string = '';
  incorrectPassword: boolean = false;
  showLoader: boolean = false;

  constructor(private router: Router, private cookieService: CookieService, private authService: AuthService){}

  Login() {
    

    if(this.validateUserId(this.userId))
    {
      this.showLoader = true;
      this.authService.loginPost(this.cellNo, this.email, this.password).subscribe(resp => {
        this.cookieService.set('sessionId', resp.token ?? '' ,(new Date()).setMinutes(10));
        this.cookieService.set('username', resp.userName ?? '');
        this.cookieService.set('fullname', resp.fullName ?? '');
        this.cookieService.set('contactNo', resp.contactNo ?? '');
        },
        (error) => {
          this.showLoader = false;
          this.incorrectPassword = true;
        },
        () => {
          this.showLoader = false;
          if(this.incorrectPassword){
              // Remove the shake effect after the animation completes
                setTimeout(() => {
                  this.incorrectPassword = false;
                  }, 2000);
          } else {
            this.router.navigate(['/appointments']);
          }
        })
    }
 }

  validateUserId(userId: string){
    if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(userId))
    {
      this.email = userId;
      return true;
    }
    else if(/\d{10}/.test(userId)) {
      this.cellNo = userId;
      return true;
    }   
    else{
      alert('Please enter a valid email address or a 10-digit South African cell number!')
      return false;
    }
      
  }
}
