import { Component, OnInit } from '@angular/core';
import { ProductsCartService } from '../products-cart.service';
import { ProductCart } from '../productCart.model';

@Component({
  selector: 'app-checkout-page',
  templateUrl: './checkout-page.component.html',
  styleUrls: ['./checkout-page.component.css']
})
export class CheckoutPageComponent implements OnInit {

  public checkedProducts: ProductCart[];
  constructor(private checkedProduct: ProductsCartService) { }

  TotalCheckoutPrice(): number {
    let totalPrice = 0;
    this.checkedProducts.forEach(product => {
        totalPrice += product.price * product.quantity;
    });
    return totalPrice;
  }

  ngOnInit() {
    this.checkedProducts = this.checkedProduct.GetAllCheckedProducts();
    console.log(this.checkedProducts);
  }

}
