import { AfterViewInit, Component, ViewChild } from '@angular/core';
import {
  DayPilot,
  DayPilotCalendarComponent
} from "@daypilot/daypilot-lite-angular";
import {HomeService} from '../services/home.service'
import { CookieService } from 'ngx-cookie-service';
import { Route, Router } from '@angular/router';

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

  constructor(private homeService: HomeService, private cookieService: CookieService, private router: Router){}

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
    this.calendar.events = this.events;

    if(this.cookieService.get('sessionId') === ""){
      this.router.navigate(['/login']);
    }
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
      // displays the event on calendar
      calendar.events.add(data);
    },

    onEventClick: args => {DayPilot.Modal.form(this.form)},
    onEventMoved: args => { },
    onEventResized: args => { },
    eventDeleteHandling: "Update",
    onEventDeleted: args => { }
  };

}
