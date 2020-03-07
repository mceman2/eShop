import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { ProductCart } from '../app/productCart.model';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { LoginRegistrationService } from '../app/login-registration.service';
import { ProductCartRes } from '../app/models/ProductCartRes.model';
import { ProductsService } from '../app/products.service';



@Injectable({
  providedIn: 'root'
})
export class ProductsCartService {

  constructor(private http: HttpClient, private route: Router, private loginRegistrationService: LoginRegistrationService, private productService: ProductsService) { }

  private urlAPI = 'https://localhost:44387/api/user/';
  public cartProducts: ProductCart[];
  private rawArrayOfCartProducts: ProductCartRes[];
  public checkedProducts: ProductCart[];
  public deleteThisCode: string;

  get productsForCode() {return this.productService.searchResults;}

  public async GetItemsAPI(): Promise<ProductCart[]> {

  return this.http.get<ProductCartRes[]>(this.urlAPI + this.loginRegistrationService.userInfo.id + '/cart/cartitem')
  .toPromise().then(data => {this.rawArrayOfCartProducts = data; this.GetAllCartProducts();}).then();
}
public async DeleteProductFromCart(Name, Quantity): Promise<ProductCart[]> {
  this.productsForCode.forEach(element => {
    if(element.name == Name) 
      this.deleteThisCode = element.code;
  });
   return this.http.delete<ProductCartRes[]>(this.urlAPI + this.loginRegistrationService.userInfo.id + '/cart/cartitem/'+ this.deleteThisCode)
  .toPromise().then(data => {this.rawArrayOfCartProducts = data; this.GetAllCartProducts();}).then();
}

public async GetAllCartProducts(){
    this.cartProducts = [];
  for (let index = 0; index < this.rawArrayOfCartProducts.length; index++) {
    const prod: ProductCart = {name : this.rawArrayOfCartProducts[index].product.name,
                                      price: this.rawArrayOfCartProducts[index].product.price + this.rawArrayOfCartProducts[index].product.shippingPrice,
                                      quantity : this.rawArrayOfCartProducts[index].quantity,
                                      imagePath : this.rawArrayOfCartProducts[index].product.image,
                                      isChecked: false
                                       };
    this.cartProducts.push(prod);
  }
}
public GetAllCheckedProducts(): ProductCart[]{
  this.checkedProducts = [];
  for (let index = 0; index < this.cartProducts.length; index++) {
    if(this.cartProducts[index].isChecked)
      this.checkedProducts.push(this.cartProducts[index]);
  }
  return this.checkedProducts;
}

}
