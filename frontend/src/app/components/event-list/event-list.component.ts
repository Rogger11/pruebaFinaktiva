import { Component, Input, OnChanges } from '@angular/core';
import { EventLog } from '../../models/event-log.model';

@Component({
  selector: 'app-event-list',
  templateUrl: './event-list.component.html',
  styleUrls: ['./event-list.component.css']
})
export class EventListComponent implements OnChanges {
  @Input() events: EventLog[] = [];

  ngOnChanges() {
  }
}