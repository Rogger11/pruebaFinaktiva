import { Component, EventEmitter, Output } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-event-filters',
  templateUrl: './event-filters.component.html',
  styleUrls: ['./event-filters.component.css']
})
export class EventFiltersComponent {
  @Output() filtersApplied = new EventEmitter<any>();
  filterForm: FormGroup;

  constructor(private fb: FormBuilder) {
    this.filterForm = this.fb.group({
      eventType: ['All'],
      startDate: [''],
      endDate: ['']
    });
  }

  onApplyFilters() {
    this.filtersApplied.emit(this.filterForm.value);
  }
}