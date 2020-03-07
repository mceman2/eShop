import { Component, OnInit } from '@angular/core';
import { ProductCart } from '../productCart.model';
import { LoginRegistrationService } from '../login-registration.service';


import { ProductsCartService } from '../products-cart.service';


@Component({
  selector: 'app-cart-product-list',
  templateUrl: './cart-product-list.component.html',
  styleUrls: ['./cart-product-list.component.css']
})
export class CartProductListComponent implements OnInit {

  //public productsCart: ProductCart[];

  constructor(private productCart: ProductsCartService, private loginService: LoginRegistrationService) { }

  TotalPrice(): number {
    let totalPrice = 0;
    this.productsCart.forEach(product => {
      if (product.isChecked === true) {
        totalPrice += product.price * product.quantity;
      }
    });
    return totalPrice;
  }

  get productsCart() {return this.productCart.cartProducts;}

  ngOnInit() {
    this.productCart.GetItemsAPI();
  }

 deleteItemFromCart(name, quantity) {
   this.productCart.DeleteProductFromCart(name, quantity);
 }
}
