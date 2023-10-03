import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';//provides the serives and dirctives for navigation throught the application view
import { Routes } from '@angular/router'; 
import { CartComponent } from './app/cart/cart.component';
import { CategoryComponent } from './app/category/category.component';
//import { RouterModule } from '@angular/core';//Allows us to create a NgModule
import { HomePageComponent } from './app/home-page/home-page.component';
import { LoginComponent } from './app/login/login.component';
import { ProductsComponent } from './app/products/products.component';
import { SignUpComponent } from './app/sign-up/sign-up.component';
import { AboutpageComponent } from './app/aboutpage/aboutpage.component';
import { ForgotPasswordComponent } from './app/forgot-password/forgot-password.component';
import { CheckoutComponent } from './app/checkout/checkout.component';
import { AdminViewComponent } from './app/admin-view/admin-view.component';



const routes: Routes = [
  { path: '', component: HomePageComponent },//default lamding page
  { path: 'home-page', component: HomePageComponent },
  { path: 'products', component: ProductsComponent },
  { path: 'login', component: LoginComponent },
  { path: 'cart', component: CartComponent },
  { path: 'signup', component: SignUpComponent },
  { path: 'category', component: CategoryComponent },
  { path: 'aboutpage', component: AboutpageComponent },
  { path: 'forgotPassword', component: ForgotPasswordComponent },
  { path: 'checkout', component: CheckoutComponent },
  { path: 'adminview', component: AdminViewComponent },
  { path: '**', redirectTo: '', pathMatch: 'full' }//full for the eniter url if a bad url is called
 // { path: '**', component: PageNotFoundComponent } // Wildcard route for a 404 page
  ]; //declared to to store all the routes

@NgModule({

  imports: [RouterModule.forRoot(routes)],//, { useHash: true }
  exports: [RouterModule]
})

//export const routing: ModuleWithProviders = RouterModule.forRoot(routes);
export class AppRoutingModule { }
export const routingComponents = [HomePageComponent, ProductsComponent]
