import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { User } from './models/User.model';

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
