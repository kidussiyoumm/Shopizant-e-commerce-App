import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';//to create a Template driven form in login page
import { ReactiveFormsModule } from '@angular/forms'; ////to create the reactive sign up form page
/*import { REACTIVE_FORM_DIRECTIVES } from '@angular/forms'*/

import { AppComponent } from './app.component';
import { ProductsComponent } from './products/products.component';
import { LoginComponent } from './login/login.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { ProductService } from './Shopizant-services/ProductServices/product.service';
import { HttpClientModule } from '@angular/common/http';


import { HomePageComponent } from './home-page/home-page.component';
import { Router, RouterModule, Routes } from '@angular/router';
import { AppRoutingModule , routingComponents } from '../app.routing';
import { CartComponent } from './cart/cart.component';
import { CategoryComponent } from './category/category.component';
import { AboutpageComponent } from './aboutpage/aboutpage.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { AdminViewComponent } from './admin-view/admin-view.component';
import { CheckoutComponent } from './checkout/checkout.component';






@NgModule({ //All added component will be decorated with a @NgModules
  declarations: [
    AppComponent,
    ProductsComponent,
    LoginComponent,
    SignUpComponent,
    CartComponent,
    HomePageComponent,
    CategoryComponent,
    AboutpageComponent,
    ForgotPasswordComponent,
    AdminViewComponent,
    CheckoutComponent,
   
/*    routingComponents, */
  ],
 // exports: [RouterModule],
  imports: [
    BrowserModule,
    FormsModule, //so it can be used any componts of the application for login page 
    ReactiveFormsModule, //sign up page
    HttpClientModule, //to connect with our API
    AppRoutingModule,
   
  ],
  providers: [ProductService],
  bootstrap: [AppComponent]
})
export class AppModule { }
