import { Component } from '@angular/core';
import { Router } from '@angular/router';

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

    constructor(private router: Router){
      
    }

    Login(){
      if(this.cellNo === this.user.cellNo && this.password === this.user.password){
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
