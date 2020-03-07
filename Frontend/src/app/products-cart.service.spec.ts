import { TestBed } from '@angular/core/testing';

import { ProductsCartService } from './products-cart.service';

describe('ProductsCartService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ProductsCartService = TestBed.get(ProductsCartService);
    expect(service).toBeTruthy();
  });
});
