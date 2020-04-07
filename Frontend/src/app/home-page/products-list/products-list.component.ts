import { Component, OnInit } from '@angular/core';

import { Product } from '../../models/product.model';
import { DataService } from '../../data.service';
import { NameService } from '../../name.service';
import { ProductsService } from '../../products.service';

@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css']
})
export class ProductsListComponent implements OnInit {
  //public products: Product[];
  message: string;
  currentCategory = 'allCategories';
  nameProduct = '';
  constructor(private data: DataService, private name: NameService, private produki: ProductsService) { }

get products() {return this.produki.searchResults;}

  ngOnInit() {
    this.data.currentMessage.subscribe(kategorija =>  this.currentCategory = kategorija);
    this.name.productName.subscribe(ime =>  this.nameProduct = ime);
    this.currentCategory = 'allCategories';
   // this.products = this.produki.GetProducts();
    this.produki.GetItemsAPI();
   // console.log(this.products);
   // this.products = this.produki.GetAllProductsAPI();
  }

}
