import { AfterViewInit, Component, ViewChild } from '@angular/core';
import {
  DayPilot,
  DayPilotCalendarComponent
} from "@daypilot/daypilot-lite-angular";

@Component({
  selector: 'app-appointments',
  templateUrl: './appointments.component.html',
  styleUrls: ['./appointments.component.scss']
})
export class AppointmentsComponent implements AfterViewInit {

  @ViewChild("calendar") calendar!: DayPilotCalendarComponent;

  events: DayPilot.EventData[] = [
    {
      id: 1, 
      start: "2023-07-11T11:30:00", 
      end: "2023-07-11T12:00:00", 
      text: "Booked"
    },
    {
      id: 2, 
      start: "2023-07-13T10:30:00", 
      end: "2023-07-13T11:15:00", 
      text: "Booked"
    },
    {
      id: 3, 
      start: "2023-07-14T14:30:00", 
      end: "2023-07-14T16:00:00", 
      text: "Booked"
    }
  ];

  ngAfterViewInit(): void {
    this.calendar.events = this.events;
  }

  config: DayPilot.CalendarConfig = {
    viewType: "Week",
    timeRangeSelectedHandling: "Enabled",
    onTimeRangeSelected: async args => {
      const modal = await DayPilot.Modal.prompt("Create a new event:", "Hair Style");
      const calendar = args.control;
      calendar.clearSelection();
      if (modal.canceled) {
        return;
      }
      // user event data
      const data = {
        start: args.start,
        end: args.end,
        id: DayPilot.guid(),
        resource: args.resource,
        text: modal.result
      };
      // displays the event on calendar
      calendar.events.add(data);
    },

    onEventMoved: args => { },
    onEventResized: args => { },
    eventDeleteHandling: "Update",
    onEventDeleted: args => { }
  };

}
