import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { FilterInfo, ConditionTypes, CategoryTypes, SearchBy, GenderTypes, ColorTypes } from '../app/SearchBy.model';



import { Product } from '../app/product.model';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {



  // private products: Product[] = [
  //   new Product(
  //     1, 'A Test Recipe', 'Description of recipe', '30$', 'Recipe', 'radi',
  //     'https://upload.wikimedia.org/wikipedia/commons/1/15/Recipe_logo.jpeg'),
  //   new Product(
  //     2, 'BMW 320d', 'BMW 320d Diesel M Sport ', '30,000$', 'Cars', 'radi',
  //     'https://s1.cdn.autoevolution.com/images/testdrive/gallery/bmw-320d-xdrive-review-2016_56.jpg'),
  //   new Product(
  //     3, 'BMW 320d', 'BMW 320d Diesel M Sport ', '30,000$', 'Cars', 'radi',
  //     'https://s1.cdn.autoevolution.com/images/testdrive/gallery/bmw-320d-xdrive-review-2016_56.jpg'),
  // ];

// public GetProducts() {
//  // return this.products;
// }
  constructor(private http: HttpClient, private route: Router) { }

public searchResults: Product[];
private rawArrayOfProducts: Product[];
searchBy: SearchBy = {Search : '', Category: CategoryTypes.All, Gender: GenderTypes.All, 
Condition: ConditionTypes.All, PriceRange: {fromPrice: 0 , toPrice: 0 } , FreeShipping: false };


  private urlAPI = 'https://localhost:44387/api/product';
public async GetItemsAPI(): Promise<Product[]> {

  return this.http.get<Product[]>(this.urlAPI + '?SearchText=' + this.searchBy.Search + '&categoryId=' 
  + this.searchBy.Category + '&condition=' + this.searchBy.Condition + 
   '&PriceFrom=' + this.searchBy.PriceRange.fromPrice + '&PriceTo=' + this.searchBy.PriceRange.toPrice + '&FreeShipping=' 
   + this.searchBy.FreeShipping).toPromise()
   .then(data => {this.rawArrayOfProducts = data; this.GetAllProducts(); }).then();
}



public async GetAllProducts(){
    this.searchResults = [];
  //console.log(this.rawArrayOfProducts);
  for (let index = 0; index < this.rawArrayOfProducts.length; index++) {
    const prod: Product = {id : this.rawArrayOfProducts[index].id,
                                      code: this.rawArrayOfProducts[index].code,
                                      name : this.rawArrayOfProducts[index].name,
                                      image : this.rawArrayOfProducts[index].image,
                                      shortDescription : this.rawArrayOfProducts[index].shortDescription,
                                      price : this.rawArrayOfProducts[index].price,
                                      shippingPrice : this.rawArrayOfProducts[index].shippingPrice };
    this.searchResults.push(prod);
  }
  //return this.searchResults;
  }
}