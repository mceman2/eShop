import { Component, OnInit } from '@angular/core';
import { ProductDetail } from '../productDetail.model';

import { ProductDetailService } from '../product-detail.service';
import { ActivatedRoute } from '@angular/router';
import { CartItemToPost } from '../models/CartItemToPost.model';

@Component({
  selector: 'app-product-details-page',
  templateUrl: './product-details-page.component.html',
  styleUrls: ['./product-details-page.component.css']
})
export class ProductDetailsPageComponent implements OnInit {

  public id;
  public quantity;

  constructor(private product: ProductDetailService, private route: ActivatedRoute) { }

  get productDetail() { return this.product.detailProduct; }

  ngOnInit() {
    this.id = this.route.snapshot.params.id;
    this.product.GetProductDetailsAPI(+this.id);
  }

  PostItemToCart() {
    const cartItem: CartItemToPost = {
      quantity: this.quantity,
      code: this.product.code
    };
    this.product.PostItemToCartAPI(cartItem).then();
  }
}
