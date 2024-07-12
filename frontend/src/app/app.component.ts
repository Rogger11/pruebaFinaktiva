import { Component, OnInit } from '@angular/core';
import { EventService } from './services/event.service';
import { EventLog } from './models/event-log.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'frontend';
  events: EventLog[] = [];
  errorMessage: string | null = null;

  constructor(private eventService: EventService) {}

  ngOnInit() {
    this.fetchAllEvents();
  }

  fetchAllEvents() {
    this.eventService.getAllEvents().subscribe(
      events => {
        this.events = events;
      },
      error => {
        this.errorMessage = error.message;
        console.error('Error fetching events:', error);
      }
    );
  }

  fetchEvents(filters?: any) {
    const eventType = filters?.eventType === 'All' ? '' : filters?.eventType || '';
    const startDate = filters?.startDate || '';
    const endDate = filters?.endDate || '';

    this.eventService.getEvents(eventType, startDate, endDate).subscribe(
      events => {
        this.events = events;
      },
      error => {
        this.errorMessage = error.message;
        console.error('Error fetching events:', error);
      }
    );
  }

  onFiltersApplied(filters: any) {
    this.errorMessage = null; 
    if (filters.eventType === 'All' && !filters.startDate && !filters.endDate) {
      this.fetchAllEvents();
    } else {
      this.fetchEvents(filters);
    }
  }
}