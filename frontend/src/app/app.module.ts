import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AppointmentsComponent } from './appointments/appointments.component';
import { FormsModule } from '@angular/forms';
import { DayPilotModule } from '@daypilot/daypilot-lite-angular';
import { AuthService } from './auth/services/auth.service';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { BookingsService } from './api/api/bookings.service';
import { AuthorizeInterceptor } from './auth/interceptors/authorize.interceptor';
import { AvailabilitySlotsService } from './api/api/availabilitySlots.service';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent,
    AppointmentsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    FormsModule,
    DayPilotModule,
    HttpClientModule
  ],
  providers: [
    AuthService, 
    BookingsService,
    AvailabilitySlotsService,
    {
      provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
