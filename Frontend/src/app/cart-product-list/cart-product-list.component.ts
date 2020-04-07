import { Component, OnInit } from '@angular/core';

import { ProductsCartService } from '../products-cart.service';
import { LoginRegistrationService } from '../login-registration.service';
import { ProductCart } from '../models/productCart.model';

@Component({
  selector: 'app-cart-product-list',
  templateUrl: './cart-product-list.component.html',
  styleUrls: ['./cart-product-list.component.css']
})
export class CartProductListComponent implements OnInit {

  //public productsCart: ProductCart[];

  constructor(private productCartService: ProductsCartService) { }

  TotalPrice(): number {
    let totalPrice = 0;
    if (!this.productsCart) {
      return 0;
    }
    this.productsCart.forEach(product => {
      if (product.isChecked === true) {
        totalPrice += product.price * product.quantity;
      }
    });
    return totalPrice;
  }

  get productsCart() {
    return this.productCartService.cartProducts;
  }

  ngOnInit() {
    this.productCartService.GetItemsAPI();
  }

 deleteItemFromCart(name, quantity) {
   this.productCartService.DeleteProductFromCart(name, quantity);
 }
}
