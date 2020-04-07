import { Component, OnInit } from '@angular/core';

import { DataService } from '../data.service';
import { ProductsService } from '../products.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {

  constructor(public data: DataService, private serviceProducts: ProductsService) { }

  ngOnInit() {

  }


}
