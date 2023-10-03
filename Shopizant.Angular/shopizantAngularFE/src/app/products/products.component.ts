import { Component, OnInit } from '@angular/core';
import { IProduct } from 'src/app/Shopizant-interfaces/product';
import { ICategory } from 'src/app/Shopizant-interfaces/category'; //path or parent folder of the class
import { Router } from '@angular/router';
import { ProductService } from '../Shopizant-services/ProductServices/product.service';
import { UserService } from '../Shopizant-services/UserServices/user.service';

//import { ProductService } from 'src/app/Shopizant-services/ProductServices/product.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  products: IProduct[] | any;
  categories: ICategory[] | undefined;
  showMessage: boolean = false;
  userName: string | any;
  error: string | any;

  //imageCart: string | any;


  constructor(private product_Service: ProductService, private _userServices: UserService, private router: Router) { }   //(private product_Service: ProductService)instance of product services


  ngOnInit(): void {



    if (this.products == null) {
      this.showMessage = true;
    }
    this.getProducts();
    /* this.getCatgories();*/


    
  }



  getProducts() {
    this.product_Service.getProducts().subscribe(
      responseProductData => {
        this.products = responseProductData;
        /* this.showMessage = false;*/
      }
    );
  }
  addtoCart(prod: IProduct) {
    if (this.userName != null) {
      this.router.navigate(['/login']); //the router will navigate user back to login page to login
    }
    else {
      this._userServices.addToCart(prod.ProductId, this.userName)
        .subscribe(
          productResponse => {
            if (productResponse) {
              alert("Added to cart")
            }
          },
          productResponse => {
            this.error = productResponse,
              console.log(this.error),
              alert("Invalid Entry, try again!");
          },
        );

    }
  }
}

    
    //getCatgories() {
    //  this.product_Service.getCategories().subscribe(
    //    responseProductData => {
    //    this.categories = responseProductData;
       
    //  }
    //  );
    //}



