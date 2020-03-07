import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({providedIn: 'root'})
export class NameService {
    private nameSource = new BehaviorSubject<string>('name');

    productName = this.nameSource.asObservable();

    constructor() { }


    searchByName(name: string) {
        this.nameSource.next(name);
    }
}