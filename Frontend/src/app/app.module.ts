import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';



import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { ProductsSearchComponent } from './home-page/products-search/products-search.component';
import { ProductsListComponent } from './home-page/products-list/products-list.component';
import { SignInPageComponent } from './sign-in-page/sign-in-page.component';
import { RegisterPageComponent } from './register-page/register-page.component';
import { HomePageComponent } from './home-page/home-page.component';
import { CartPageComponent } from './cart-page/cart-page.component';
import { ProductDetailsPageComponent } from './product-details-page/product-details-page.component';
import { CartProductListComponent } from './cart-product-list/cart-product-list.component';
import { CheckoutPageComponent } from './checkout-page/checkout-page.component';
import { LoginRegistrationService } from './login-registration.service';


const appRoutes: Routes = [
  { path: '', component: HomePageComponent},
  { path: 'SignIn', component: SignInPageComponent},
  { path: 'Register', component: RegisterPageComponent},
  { path: 'Cart', component: CartPageComponent},
  { path: 'ProductDetails/:id', component: ProductDetailsPageComponent},
  { path: 'Checkout', component: CheckoutPageComponent}
];

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    ProductsSearchComponent,
    ProductsListComponent,
    SignInPageComponent,
    RegisterPageComponent,
    HomePageComponent,
    CartPageComponent,
    ProductDetailsPageComponent,
    CartProductListComponent,
    CheckoutPageComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(appRoutes),
    HttpClientModule,
    FormsModule
  ],
  providers: [
    LoginRegistrationService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
