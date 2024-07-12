import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EventService } from '../../services/event.service';
import { EventLog } from '../../models/event-log.model';

@Component({
  selector: 'app-event-form',
  templateUrl: './event-form.component.html',
  styleUrls: ['./event-form.component.css']
})
export class EventFormComponent {
  eventForm: FormGroup;

  constructor(private fb: FormBuilder, private eventService: EventService) {
    this.eventForm = this.fb.group({
      description: ['', Validators.required],
      eventType: ['Manual', Validators.required]
    });
  }

  onSubmit() {
    if (this.eventForm.valid) {
      const newEvent: EventLog = this.eventForm.value;
      this.eventService.createEvent(newEvent).subscribe(response => {
        console.log('Event registered:', response);
        this.eventForm.reset();
      }, error => {
        console.error('Error registering event:', error);
      });
    }
  }
}
