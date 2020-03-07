import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { DataService } from '../../data.service';
import { NameService } from '../../name.service';

@Component({
  selector: 'app-products-search',
  templateUrl: './products-search.component.html',
  styleUrls: ['./products-search.component.css']
})
export class ProductsSearchComponent implements OnInit {

  message = 'cars';
  productName = '';

  @Output() messageEvent = new EventEmitter<string>();

  constructor(private data: DataService, private name: NameService) { }

  sendMessage(value: string) {
    this.messageEvent.emit(value);
  }
  sendCategories(value: string) {
    this.data.changeMessage(value);
  }

  ngOnInit() {
    this.data.currentMessage.subscribe(message =>  this.message = message);
  }
  newMessage() {
    this.data.changeMessage('Hello iz searcha');
  }
  searchProductByName(event: any) {
    this.productName = event.target.value;
  }
  sendName() {
    this.name.searchByName(this.productName);
  }
}
