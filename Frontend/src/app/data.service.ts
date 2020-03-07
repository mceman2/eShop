import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, catchError, tap } from 'rxjs/operators';
import { User } from './User.model';

@Injectable({providedIn: 'root'})
export class DataService {
    private messageSource = new BehaviorSubject<string>('poruka');
    public results: User = new User();
    currentMessage = this.messageSource.asObservable();

    constructor(private http: HttpClient) { }


    changeMessage(message: string) {
        this.messageSource.next(message);
    }

}