import { AfterViewInit, Component, ViewChild } from '@angular/core';
import {
  DayPilot,
  DayPilotCalendarComponent
} from "@daypilot/daypilot-lite-angular";
import {HomeService} from '../services/home.service'
import { CookieService } from 'ngx-cookie-service';
import { Route, Router } from '@angular/router';
import { BookingsService } from '../api/api/bookings.service';
import { BookingDTO } from '../api/model/bookingDTO';
import { BookingStatus } from '../api/model/bookingStatus';
import { AvailabilitySlotsService } from '../api/api/availabilitySlots.service'

@Component({
  selector: 'app-appointments',
  templateUrl: './appointments.component.html',
  styleUrls: ['./appointments.component.scss']
})
export class AppointmentsComponent implements AfterViewInit {

  @ViewChild("calendar") calendar!: DayPilotCalendarComponent;

  events: DayPilot.EventData[] = []

  private requestedService: any;
  private svcETA: number = 0;
  private selection: string = "";
  private form: any;
  showLoader: boolean = false;

  constructor(
    private homeService: HomeService, 
    private cookieService: CookieService, 
    private router: Router, 
    private bookings: BookingsService,
    private availability: AvailabilitySlotsService
  ){}

  ngOnInit(){
    this.requestedService = this.homeService.getServiceById(parseInt(this.cookieService.get('svcId')));
    this.svcETA = this.requestedService === undefined ? 0 : parseInt(this.requestedService?.svcETA.split(" ")[0]);

    this.selection = "Style: " + this.requestedService?.svcName + 
                        "\nDescription: " + this.requestedService?.svcDescription +
                        "\nPrice: R " + this.requestedService?.svcPrice +
                        "\nDuration: " + this.requestedService?.svcETA;

    this.form = [
        {text: this.selection },
        {name: "Name", id: "name", type: "html"},
      ];
  }

  ngAfterViewInit(): void {
    this
    if(this.cookieService.get('sessionId') === ''){
      this.router.navigate(['/login']);
    }
    var bookings: DayPilot.EventData[] = [];
    //this.calendar.events = this.events;
    this.showLoader = true;
    this.availability.apiAvailabilitySlotsGet().subscribe(
      resp => {
        resp.forEach(function(slot){
        var booking: DayPilot.EventData = {
          id: DayPilot.guid(),
          start: slot.startTime?.toString() ?? '',
          end: slot.endTime?.toString() ?? '',
          text:  'Booking'
        }
        bookings.push(booking); 
        });
      },
      error => {
        this.showLoader = false;
        if(error.status == 401){
          this.router.navigate(['/login']);
        }
      },
      () => {
        this.showLoader = false;
      }
      
    );

    this.calendar.events = bookings;
  }

  config: DayPilot.CalendarConfig = {
    viewType: "Week",
    timeRangeSelectedHandling: "Enabled",
    onTimeRangeSelected: async args => {
      const modal = await DayPilot.Modal.form(this.form);
      const calendar = args.control;
      calendar.clearSelection();
      if (modal.canceled) {
        return;
      }
      // user event data
      const data = {
        start: args.start,
        end: args.start.addMinutes(this.svcETA),
        id: DayPilot.guid(),
        resource: args.resource,
        text: this.requestedService?.svcName === undefined ? "Booked!" : this.requestedService?.svcName
      };

      const booking : BookingDTO = {
        id : DayPilot.guid(),
        userId: 0,
        serviceId: 0,
        date: data.start.toDate(),
        startTime: data.start.toDate(),
        endTime: data.end.toDate(),
        status: 0,
        comments: 'Mock data added via website'
      }
      this.showLoader = true;

      this.bookings.apiBookingsPost(booking).subscribe(resp => {
        console.log('Booking created!')
        // displays the event on calendar
        calendar.events.add(data);
      },
    error => {
      this.showLoader = false;
      if(error.status = 401){
        this.router.navigate(['/login']);
      }
      console.log('Booking failed!')
    },
    () => {
      this.showLoader = false;
    }
  )

    },

    onEventClick: args => {DayPilot.Modal.form(this.form)},
    onEventMoved: args => { },
    onEventResized: args => { },
    eventDeleteHandling: "Update",
    onEventDeleted: args => { }
  };

}
