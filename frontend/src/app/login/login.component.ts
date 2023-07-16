import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
    cellNo: string = '';
    password: string = '';
    incorrectPassword: boolean = false;
    

    private user = {'cellNo': '0712345678',
                    'password': 'password'};

    constructor(private router: Router, private cookieService: CookieService){}

    Login(){
      if(this.cellNo === this.user.cellNo && this.password === this.user.password){
        this.cookieService.set('sessionId', 'XXXXXXXXXXXXXXXX',(new Date()).setMinutes(10));
        this.router.navigate(['/appointments']);
      }else{
        this.incorrectPassword = true;

        // Remove the shake effect after the animation completes
        setTimeout(() => {
        this.incorrectPassword = false;
      }, 2000);
      }
    }
}
