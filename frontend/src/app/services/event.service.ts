import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpParams } from '@angular/common/http';
import { Observable, throwError  } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { EventLog } from '../models/event-log.model'; 

@Injectable({
  providedIn: 'root'
})
export class EventService {
  private apiUrl = 'https://localhost:412/api/eventlogs';

  constructor(private http: HttpClient) { }

  createEvent(event: EventLog): Observable<EventLog> {
    return this.http.post<EventLog>(this.apiUrl, event)
      .pipe(
        catchError(this.handleError)
      );
  }

  getEvents(eventType?: string, startDate?: string, endDate?: string): Observable<EventLog[]> {
    let params = new HttpParams();
    if (eventType && eventType !== 'All') params = params.append('eventType', eventType);
    if (startDate) params = params.append('startDate', startDate);
    if (endDate) params = params.append('endDate', endDate);

    return this.http.get<EventLog[]>(this.apiUrl, { params })
      .pipe(
        catchError(this.handleError)
      );
  }

  getAllEvents(): Observable<EventLog[]> {
    return this.http.get<EventLog[]>(`${this.apiUrl}/all`)
      .pipe(
        catchError(this.handleError)
      );
  }

  private handleError(error: HttpErrorResponse) {
    console.error(`Server error: ${error.message}`);
    return throwError(() => new Error('A server error occurred. Please try again later.'));
  }
}
