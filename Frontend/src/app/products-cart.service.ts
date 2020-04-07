import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

import { LoginRegistrationService } from '../app/login-registration.service';
import { ProductsService } from './products.service';
import { ProductCartRes } from './models/ProductCartRes.model';
import { ProductCart } from './models/productCart.model';


@Injectable({ providedIn: 'root' })
export class ProductsCartService {

  constructor(private http: HttpClient,
              private route: Router,
              private loginRegistrationService: LoginRegistrationService,
              private productService: ProductsService) { }

  private urlAPI = 'https://localhost:44387/api/user/';
  public cartProducts: ProductCart[];
  private rawArrayOfCartProducts: ProductCartRes[];
  public checkedProducts: ProductCart[];
  public deleteThisCode: string;

  get productsForCode() {
    return this.productService.searchResults;
  }

  public async GetItemsAPI() {
    return this.http
    .get<ProductCartRes[]>(this.urlAPI + this.loginRegistrationService.userInfo.id + '/cart/cartitem')
    .subscribe(data => {
      if (data.length > 0) {
        this.rawArrayOfCartProducts = data;
        this.GetAllCartProducts();
      }
 });
  }

  public async DeleteProductFromCart(Name, Quantity): Promise<ProductCart[]> {
    this.productsForCode.forEach(element => {
      if (element.name === Name) {
        this.deleteThisCode = element.code;
      }
    });
    return this.http.delete<ProductCartRes[]>(
      this.urlAPI + this.loginRegistrationService.userInfo.id +
      '/cart/cartitem/' + this.deleteThisCode)
    .toPromise().then(data => {
      this.rawArrayOfCartProducts = data;
      this.GetAllCartProducts();
    }).then();
}

public async GetAllCartProducts() {
  this.cartProducts = [];
  this.rawArrayOfCartProducts.forEach(element => {
    const prod: ProductCart = {
      name : element.product.name,
      price: element.product.price + element.product.shippingPrice,
      quantity : element.quantity,
      imagePath : element.product.image,
      isChecked: false
    };
    this.cartProducts.push(prod);
  });
}
public GetAllCheckedProducts(): ProductCart[]{
  this.checkedProducts = [];
  this.cartProducts.forEach(element => {
    if (element.isChecked) {
      this.checkedProducts.push(element);
    }
  });
  return this.checkedProducts;
}

}
