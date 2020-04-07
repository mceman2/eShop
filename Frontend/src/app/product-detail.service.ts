import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';

import { LoginRegistrationService } from '../app/login-registration.service';
import { FullProductRes } from '../app/models/FullProductRes.model';
import { ProductDetail } from './models/productDetail.model';


@Injectable({
  providedIn: 'root'
})
export class ProductDetailService {

  constructor(private http: HttpClient, private route: Router, private loginRegistrationService: LoginRegistrationService) { }
  private urlAPI = 'https://localhost:44387/api/';
  public detailProduct: ProductDetail = new ProductDetail ();
  public code = '';
  private rawFullProduct: FullProductRes;

  public async GetProductDetailsAPI(id): Promise<ProductDetail[]> {
  return this.http.get<FullProductRes>(this.urlAPI + 'DetailedProduct/' + id)
  .toPromise().then(data => {this.rawFullProduct = data; this.GetInDetailProduct(); }).then();
}

  public async GetInDetailProduct() {
    this.detailProduct = {
      id: this.rawFullProduct.product.id,
      name: this.rawFullProduct.product.name,
      datePublished: this.rawFullProduct.details.datePublished,
      condition: this.rawFullProduct.details.condition,
      gender: this.rawFullProduct.details.gender,
      color: this.rawFullProduct.details.color,
      model: this.rawFullProduct.details.model,
      publishedBy: this.rawFullProduct.details.publishedBy,
      shortDescription: this.rawFullProduct.product.shortDescription,
      productPrice: this.rawFullProduct.product.price,
      shippingPrice: this.rawFullProduct.product.shippingPrice,
      shippingFrom: this.rawFullProduct.details.shippingFrom,
      totalPrice: this.rawFullProduct.product.price + this.rawFullProduct.product.shippingPrice,
      imagePath: this.rawFullProduct.product.image
    };
    this.code = this.rawFullProduct.product.code;
  }
    public PostItemToCartAPI(cartItem) {
    const headerHttp = {
      headers: new HttpHeaders({
        'Content-Type':  'text'
      })
    };

    return this.http
    .post(this.urlAPI + 'User/' + this.loginRegistrationService.userInfo.id +
     '/cart', cartItem);

  }
}